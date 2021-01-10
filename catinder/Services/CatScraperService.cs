using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catinder.Models;
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

        public async Task<List<Cat>> ScrapePage(string url)
        {
            var cats = new List<Cat>();

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            _logger.LogInformation($"Navigating to {url}");
            
            await using var browser = await Puppeteer.ConnectAsync(new ConnectOptions {BrowserURL = "wss://chrome.browserless.io/"});

            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            
            // wait for all cat data to come in
            await page.WaitForSelectorAsync("div.pet__item");
            
            // this snatches up all the divs that have cat data in them
            const string jsSelectAllAnchors = @"Array.from(document.querySelectorAll('.search__result')).map(a => a.innerHTML);";
            var catsData = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);

            foreach (var rawCatData in catsData)
            {
                // wrapping the HTML in a div so I can use .descendents on it later
                var newCat = PullCatDataFromHtml("<div>" + rawCatData + "</div>");
                cats.Add(newCat);
            }

            return cats;
        }
        
        private Cat PullCatDataFromHtml(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlNodes = htmlDoc.DocumentNode.Descendants().ToList();

            var catLink = "https://www.adoptapet.com" + htmlNodes[2].GetAttributeValue("href", "href");
            var catImage = htmlNodes[4].GetAttributeValue("src", "src");
            var catName = htmlNodes[9].InnerText.Trim();
            var catAge = htmlNodes[18].InnerText.Trim();

            var cat = new Cat {Age = catAge, Image = catImage, Name = catName, Link = catLink};
            return cat;
        }
    }
}