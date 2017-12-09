using ColorSeparator.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSeparator.Data.SeparatedImages
{
    class YCbCrSeparateImage : SeparateImage
    {
        public override List<Image> SeparateChannels(Image image) //TODO REFACTORING    
        {
            Bitmap YBitmap = new Bitmap(image), CbBitmap = new Bitmap(image.Width, image.Height), CrBitmap = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < YBitmap.Width; x++)
                for (int y = 0; y < YBitmap.Height; y++)
                {
                    Color pixelColor = YBitmap.GetPixel(x, y);
                    Color YColor = GrayscaleModels.calorimetricGrayscale(pixelColor);

                    int CbColorIntValue = (int)MathUtils.ConvertRange(0, 1, 0, 255, (MathUtils.ConvertRange(0, 255, 0, 1, pixelColor.B - YColor.B) / 1.772) + 1 / 2) + 128;
                    Color CbColor = Color.FromArgb(127, 255 - CbColorIntValue, CbColorIntValue);

                    int CrColorIntValue = (int)MathUtils.ConvertRange(0, 1, 0, 255, (MathUtils.ConvertRange(0, 255, 0, 1, pixelColor.R - YColor.R) / 1.402) + 1 / 2) + 128;
                    Color CrColor = Color.FromArgb(CrColorIntValue, 255 - CrColorIntValue, 127);

                    YBitmap.SetPixel(x, y, YColor);
                    CbBitmap.SetPixel(x, y, CbColor);
                    CrBitmap.SetPixel(x, y, CrColor);
                }

            

            return new List<Image>(new Image[] { YBitmap, CbBitmap, CrBitmap});

        }
    }
}
