
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAnalyzer
    {
        List<string> ReturnSiteMap(string url);

        List<string> GetSitemap(string url);
    }
}
