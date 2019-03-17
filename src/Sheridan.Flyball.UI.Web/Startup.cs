using FluentValidation.AspNetCore;
using FlyballStatTracker.Data.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Validators.Create;
using Sheridan.Flyball.Data.EFCore;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Sheridan.Flyball.Service;
using Sheridan.Flyball.UI.Web.Configuration;
using Swashbuckle.AspNetCore.Swagger;

namespace Sheridan.Flyball.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateClubModelValidator>()); ;

            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            var serviceProvider = services.BuildServiceProvider();
            var appConfigOptions = serviceProvider.GetService<IOptions<AppConfig>>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Flyball API", Version = "v1" });
            });

            services.AddDbContext<FlyballDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("FlyballDatabase")));

            //Repositories
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IDogRepository, DogRepository>();
            services.AddTransient<ITournamentRepository, TournamentRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IDivisionRepository, DivisionRepository>();
            services.AddTransient<IRaceYearRepository, RaceYearRepository>();

            //Services
            services.AddTransient<ITournamentService, TournamentService>();
            services.AddTransient<IRaceYearService, RaceYearService>();
            services.AddTransient<IClubService, ClubService>();

            services.AddAuthentication("Bearer")
             .AddJwtBearer(options =>
             {
                 options.Audience = appConfigOptions.Value.AppClientId;
                 options.Authority = appConfigOptions.Value.AuthorityURL;
             });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseAuthentication();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flyball Api V1");
            });




            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FlyballDbContext>();
                context.Database.EnsureCreated();
                //This is failing my tests will have to dig more into it #1
                //context.Database.Migrate();
                SeedData.PopulateData(context);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
