using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BuildMotion.HybridMobileApp.Web.Models;

namespace BuildMotion.HybridMobileApp.Web.Controllers
{
    public static class ControllerExtensions
    {
        public static async Task<HttpPostedData> ParseMultipartAsync(this HttpContent postedContent)
        {
            var provider = await postedContent.ReadAsMultipartAsync();
            var files = new List<HttpPostedFile>();

            foreach (var content in provider.Contents)
            {
                if (!string.IsNullOrEmpty(content.Headers.ContentDisposition.FileName))
                {
                    var file = await content.ReadAsByteArrayAsync();
                    var fileName = content.Headers.ContentDisposition.FileName.Trim('"');
                    files.Add(new HttpPostedFile(fileName, file));
                }
            }
            return new HttpPostedData(files);
        }
    }
}