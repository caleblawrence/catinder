using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catinder.Models;
using catinder.Services;

namespace catinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : ControllerBase
    {

        private readonly ILogger<CatsController> _logger;
        private readonly ICatScraperService _catScraperService;

        public CatsController(ILogger<CatsController> logger, ICatScraperService catScraperService)
        {
            _logger = logger;
            _catScraperService = catScraperService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cat>> Get([FromQuery] GetCatsRequest request)
        {
            // TODO: validate state formatting
            // TODO: needs to be like TX not `Texas`
            var apiEndpoint = $"https://www.adoptapet.com/pet-search?clan_id=2&geo_range=50&location={request.City},%20{request.StateCode}&page={request.Page}";
            var cats = await _catScraperService.ScrapePage(apiEndpoint);
            return cats;
        }
        
    }
}