using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;
using Sheridan.Flyball.UI.Web.Configuration;

namespace Sheridan.Flyball.UI.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly IClubService _clubService;

        public ClubController(IOptions<AppConfig> appConfig,IClubService clubService)
        {
            _appConfig = appConfig;
            _clubService = clubService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub(CreateClubModel newClub)
        {
            return new OkObjectResult(await _clubService.Create(newClub));
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            return new OkObjectResult(await _clubService.All());
        }
                
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClub(int id)
        {
            return new OkObjectResult(await _clubService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClub(UpdateClubModel club)
        {
            var updateClub = await _clubService.Update(club);

            if(updateClub == null) return new NoContentResult();

            return new OkObjectResult(updateClub);
        }

        [HttpGet("{clubId}/people")]
        public async Task<IActionResult> GetPeople(int clubId)
        {
            var people = await _clubService.GetPeople(clubId);

            if(people == null) return new NoContentResult();
            if(people.Count == 0 ) return new NoContentResult();

            return new OkObjectResult(people);
        }


     
    }
}