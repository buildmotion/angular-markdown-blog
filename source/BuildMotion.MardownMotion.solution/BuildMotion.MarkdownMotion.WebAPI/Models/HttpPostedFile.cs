namespace BuildMotion.HybridMobileApp.Web.Models
{
    public class HttpPostedFile
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpPostedFile" /> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="fileBytes">The file.</param>
        public HttpPostedFile(string filename, byte[] fileBytes)
        {
            Filename = filename;
            FileBytes = fileBytes;
        }

        public string Filename { get; private set; }
        public byte[] FileBytes { private set; get; }
    }
}