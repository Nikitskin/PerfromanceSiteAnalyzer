using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using SitemapPerormanceAnalyzer.Models;

namespace SitemapPerormanceAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private IAnalyzer _analyzer;
        private IPerformanceDiagostics _performanceDiagostics;
        private IStore _store;

        public HomeController()
        {
            //todo create IOC 
            _analyzer = new UrlSiteMapParser();
            _performanceDiagostics = new PerformanceDiagnostics();
            _store = new Store();
        }

        public IActionResult Index()
        {
            return View();
        }

        public RedirectToActionResult Index(RequestModel model)
        {
            var listOfUrls = _analyzer.ReturnSiteMap(model.UrlToGetSitemap);
            ViewBag.ListOfUrls = listOfUrls;
            return RedirectToAction("PerformanceResult","Home", new { _listOfUrls = listOfUrls });
        }

        public IActionResult PerformanceResult(int page = 1)
        {

            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = await _performanceDiagostics.AsyncGetUrlsToCallBackTime();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Users = items
            };
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
