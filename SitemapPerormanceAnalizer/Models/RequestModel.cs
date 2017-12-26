using System.ComponentModel.DataAnnotations;

namespace SitemapPerormanceAnalyzer.Models
{
    public class RequestModel
    {
        [Required(ErrorMessage = "Url should be set")]
        [RegularExpression(@"^(https?:\/\/)?([\w\.]+)\.([a-z]{2,6}\.?)(\/[\w\.]*)*\/?$", ErrorMessage = "Invalid url inputed")]
        public virtual string UrlToGetSitemap { get; set; }

        public virtual string PageSize { get; set; }
    }
}