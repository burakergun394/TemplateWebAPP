using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using ImageProcessor.Imaging;
using Microsoft.AspNetCore.Hosting;

namespace Core.Utilities.Helpers
{
    public static class ImageSaver
    {
        public static string SaveImage(IWebHostEnvironment hostingEnvironment, byte[] imageData, string imageFolder,string extension, int w = 0, int h = 0, bool dontGenerateName = false)
        {
            int ImageQuality = 80;
            string fileName = dontGenerateName == true ? imageFolder : imageFolder + "/" + Guid.NewGuid() + "." + extension;
            System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(imageData));
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
            {
                var saveFileName = hostingEnvironment.WebRootFileProvider.GetFileInfo(fileName).PhysicalPath;

                imageFactory.Load(img)
                    .Quality(ImageQuality)
                    .Resize(new ResizeLayer(new Size(img.Width,  img.Height), ResizeMode.Pad, AnchorPosition.Center))
                    .BackgroundColor(Color.Transparent)
                    .Save(saveFileName);
                return fileName;

            }
        }

       

    }
}
