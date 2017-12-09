using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ColorSeparator.Utils
{
    class ImageAlgorithms
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public static Bitmap Convert2Grayscale(Image image, Func<Color, Color> grayscaleModel) //TODO maybe i can add different grayscale computing methods
        {
            Bitmap grayscaleBitmap = new Bitmap(image);

            for(int x = 0; x < grayscaleBitmap.Width; x++)
                for(int y = 0; y < grayscaleBitmap.Height; y++)
                {
                    Color pixelColor = grayscaleBitmap.GetPixel(x, y);
                    //int grayscalePixelColorIntRepresentation = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    //Color grayscalePixelColor = Color.FromArgb(grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation);
                    //grayscaleBitmap.SetPixel(x, y, grayscalePixelColor);

                    grayscaleBitmap.SetPixel(x, y, grayscaleModel(pixelColor));

                }

            return grayscaleBitmap;
        }
    }
}
