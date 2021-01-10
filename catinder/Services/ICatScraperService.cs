using System.Threading.Tasks;

namespace catinder.Services
{
    public interface ICatScraperService
    {
        public Task ScrapePage(string url);
    }
}