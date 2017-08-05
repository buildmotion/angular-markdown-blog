using System.Collections.Generic;

namespace BuildMotion.HybridMobileApp.Web.Models
{
    public class HttpPostedData
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpPostedData" /> class.
        /// </summary>
        /// <param name="files">The files.</param>
        public HttpPostedData(List<HttpPostedFile> files)
        {
            Files = files;
        }

        /// <summary>
        ///     Gets the files.
        /// </summary>
        /// <value>
        ///     The files.
        /// </value>
        public List<HttpPostedFile> Files { get; private set; }
    }
}