﻿using System.Diagnostics;
using System.Threading.Tasks;
using BusinessLayer.Analyzer;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SitemapPerformanceAnalyzer.Models;

namespace SitemapPerformanceAnalyzer.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Index(RequestModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _analyzer.SetupSitemapUrls(model.UrlToGetSitemap);
            return RedirectToAction("PerformanceResult", "Home", new { pageSize = model.PageSize });
        }

        public async Task<IActionResult> PerformanceResult(int page = 1, int pageSize = 10)
        {
            var result = await _performanceDiagostics.AsyncGetPerformanceModelInRange((page-1)* pageSize, pageSize);
            ViewBag.ResultsAmount = _performanceDiagostics.GetTotalAmountOfSitemaps();
            ViewBag.SitemapPerformanceResults = result;

            return View(new IndexViewModel
            {
                PageViewModel = new PageViewModel(_performanceDiagostics.GetTotalAmountOfSitemaps(), page, pageSize),
                PerformanceModels = result
            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
