
using System.Collections.Generic;
using BusinessLayer.Models;

namespace SitemapPerormanceAnalyzer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<PerformanceModel> PerformanceModels { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
