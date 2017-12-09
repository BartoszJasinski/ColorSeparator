using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSeparator.Data
{
    class GrayscaleModels
    {
        public static Func<Color, Color> averageGrayscale { get; } = pixel =>
          {
              int grayscalePixelColorIntRepresentation = (int)((double)(pixel.R + pixel.G + pixel.B) / 3);
              return Color.FromArgb(grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation);
          };

        public static Func<Color, Color> dispersionGrayscale { get; } = pixel =>
        {
            int grayscalePixelColorIntRepresentation = (int)(((double)(Math.Max(pixel.R, Math.Max(pixel.G, pixel.B))) + Math.Min(pixel.R, Math.Min(pixel.G, pixel.B))) / 2);
            return Color.FromArgb(grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation);
        };

        public static Func<Color, Color> calorimetricGrayscale { get; } = pixel =>
        {
            int grayscalePixelColorIntRepresentation = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
            return Color.FromArgb(grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation, grayscalePixelColorIntRepresentation);
        };

    }
}
