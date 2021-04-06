using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static string Base64ToImage(IWebHostEnvironment hostEnvironment,string path, string base64String)
        {
            string convert = "";
            string extension = "";
            if (base64String.Contains("data:image/jpeg;base64,"))
            {
                convert = base64String.Replace("data:image/jpeg;base64,", String.Empty);
                extension = "jpg";
            }

            if (base64String.Contains("data:image/png;base64,"))
            {
                convert = base64String.Replace("data:image/png;base64,", String.Empty);
                extension = "png";
            }

            if (extension == "") extension = "png";

            byte[] imageBytes = Convert.FromBase64String(convert);
          
            return ImageSaver.SaveImage(hostEnvironment, imageBytes, path, extension);
        }

        private static string ByteArrayToImage(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
        }
       
    }
}
