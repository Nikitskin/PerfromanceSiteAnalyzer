
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAnalyzer
    {
        List<string> ReturnSiteMap(string url);

        Task SetupSitemapUrls(string url);
    }
}
