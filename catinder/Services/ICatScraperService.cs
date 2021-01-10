using System.Collections.Generic;
using System.Threading.Tasks;
using catinder.Models;

namespace catinder.Services
{
    public interface ICatScraperService
    {
        public Task<List<Cat>> ScrapePage(string url);
    }
}