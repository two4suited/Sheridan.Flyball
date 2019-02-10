using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;
using Sheridan.Flyball.UI.Web.Api.Configuration;

namespace Sheridan.Flyball.UI.Web.Api.Controllers
{
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClub(int id)
        {
            return new OkObjectResult(await _clubService.GetById(id));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateClub(UpdateClubModel club)
        {
            return new OkObjectResult(await _clubService.Update(club));
        }

     
    }
}