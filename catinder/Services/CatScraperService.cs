using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;


namespace catinder.Services
{
    public class CatScraperService : ICatScraperService
    {
        private readonly ILogger<CatScraperService> _logger;

        public CatScraperService(ILogger<CatScraperService> logger)
        {
            _logger = logger;
        }

        public async Task ScrapePage(string url)
        {
            var options = new LaunchOptions {Headless = true};
            _logger.LogInformation("Downloading chromium");
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            _logger.LogInformation("Navigating to google.com");

            await using var browser = await Puppeteer.LaunchAsync(options);
            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            await page.WaitForSelectorAsync("div.pet__name");
            const string jsSelectAllAnchors = @"Array.from(document.querySelectorAll('a')).map(a => a.href);";
            var urls = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);
            _logger.LogInformation($"Length: {urls.Count()}");
            foreach (var item in urls)
            {
                // _logger.LogInformation($"Url: {item}");
            }
        }
    }
}