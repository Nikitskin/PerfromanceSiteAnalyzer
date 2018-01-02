using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace SitemapPerformanceAnalyzer.Controllers.api
{
    [Route("api/[controller]")]
    public class SitemapAnalyzeController : Controller
    {
        private IAnalyzer _analyzer;
        private IPerformanceDiagostics _performanceDiagostics;

        public SitemapAnalyzeController()
        {
            //todo DI
            _analyzer = new UrlSiteMapParser();
            _performanceDiagostics = new PerformanceDiagnostics();
        }

        [HttpPost]
        public async Task<IEnumerable<PerformanceModel>> Post([FromBody]string urlToGetSitemap)
        {
            await _analyzer.SetupSitemapUrls(urlToGetSitemap);
            var result = await _performanceDiagostics.AsyncGetPerformanceModelInRange();
            ViewBag.ResultsAmount = _performanceDiagostics.GetTotalAmountOfSitemaps();
            ViewBag.SitemapPerformanceResults = result;
            return result;
        }
    }

}
