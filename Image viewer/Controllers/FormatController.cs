using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    internal class FormatController
    {
        string targetImagePath;
        ImageFormat targetImageFormat;
        public void Convert(string filePath, string targetFormat)
        {

            if(targetFormat == Path.GetExtension(filePath))
            {
                MessageBox.Show($"Can't convert {targetFormat} to {targetFormat}.");
                return;
            }


            Image sourceImage = Image.FromFile(filePath);


            if(targetFormat == ".png") { targetImageFormat = ImageFormat.Png; }
            else if (targetFormat == ".jpeg") { targetImageFormat= ImageFormat.Jpeg; }
            else if (targetFormat == ".bmp") { targetImageFormat = ImageFormat.Bmp; }


            targetImagePath = filePath.Remove(filePath.Length - new FileInfo(filePath).Name.Length ) + Path.GetFileNameWithoutExtension(filePath) + targetFormat;

            // Конвертация изображения
            sourceImage.Save(targetImagePath, targetImageFormat);
            sourceImage.Dispose();
        }
    }
}
