using System.Diagnostics;
using System.Linq;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using SitemapPerormanceAnalyzer.Models;
using System.Threading.Tasks;

namespace SitemapPerormanceAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private IAnalyzer _analyzer;
        private IPerformanceDiagostics _performanceDiagostics;

        public HomeController()
        {
            //todo create IOC 
            _analyzer = new UrlSiteMapParser();
            _performanceDiagostics = new PerformanceDiagnostics();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PerformanceResult(RequestModel model, int page = 1)
        {
            var amount = 10;
            var listOfUrls = _analyzer.ReturnSiteMap(model.UrlToGetSitemap);
            ViewBag.ListOfUrls = listOfUrls;
            PageViewModel pageViewModel = new PageViewModel(listOfUrls.Count, page, amount);
            var result = await _performanceDiagostics.AsyncGetPerformanceModelInRange((page-1)*amount, amount);
            var viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                PerformanceModels = result
            };
            ViewBag.SitemapPerformanceResults = result;
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
