using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static string Base64ToImage(Page page, string path, string base64String)
        {
            string convert = "";
            if (base64String.Contains("data:image/jpeg;base64,"))
            {
                convert = base64String.Replace("data:image/jpeg;base64,", String.Empty);
            }

            if (base64String.Contains("data:image/png;base64,"))
            {
                convert = base64String.Replace("data:image/png;base64,", String.Empty);
            }

            byte[] imageBytes = Convert.FromBase64String(convert);
            //return /*ImageSaver.SaveImage(page, imageBytes, path, 0, 0);*/
            return "";
        }
    }
}
