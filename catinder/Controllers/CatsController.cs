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
        public IEnumerable<Cat> Get()
        {
            _catScraperService.ScrapePage("https://www.adoptapet.com/pet-search?clan_id=2&geo_range=50&location=Richardson,%20TX&page=1");
            return new[] {new Cat {Age = 1, Name = "Hyde"}, new Cat {Age = 1, Name = "Iris"} };
        }
        
    }
}