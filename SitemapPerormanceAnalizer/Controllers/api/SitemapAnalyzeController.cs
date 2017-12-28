using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace SitemapPerormanceAnalyzer.Controllers.api
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

        [HttpGet]
        public async Task<IEnumerable<PerformanceModel>> Get(string UrlToGetSitemap)
        {
            await _analyzer.SetupSitemapUrls(UrlToGetSitemap);
            var result = await _performanceDiagostics.AsyncGetPerformanceModelInRange();
            ViewBag.ResultsAmount = _performanceDiagostics.GetTotalAmountOfSitemaps();
            ViewBag.SitemapPerformanceResults = result;
            return result;
        }
    }
}
