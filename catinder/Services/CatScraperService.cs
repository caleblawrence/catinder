using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using catinder.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            var options = new LaunchOptions {Headless = true};
            _logger.LogInformation("Downloading chromium");
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            _logger.LogInformation($"Navigating to {url}");

            await using var browser = await Puppeteer.LaunchAsync(options);
            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            
            // wait for all cat data to come in (without this it doesn't work
            await page.WaitForSelectorAsync("div.pet__item");
            const string jsSelectAllAnchors = @"Array.from(document.querySelectorAll('.pet__item')).map(a => a.innerHTML);";
            var urls = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);
            _logger.LogInformation($"Length: {urls.Count()}");
            foreach (var item in urls)
            {
                var newCat = ParseHtml("<div>" + item + "</div>");
                cats.Add(newCat);
            }

            return cats;
        }
        
        private Cat ParseHtml(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlNodes = htmlDoc.DocumentNode.Descendants().ToList();
            
            var catImage = htmlNodes[1].OuterHtml;
            var catName = htmlNodes[7].InnerText.Trim();
            var catAge = htmlNodes[15].InnerText.Trim();

            var cat = new Cat {Age = catAge, Image = catImage, Name = catName};
            return cat;
        }
    }
}