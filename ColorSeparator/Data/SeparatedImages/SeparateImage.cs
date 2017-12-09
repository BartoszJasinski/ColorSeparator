using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSeparator.Data.SeparatedImages
{
    abstract class SeparateImage
    {
        Image firstChannelImage { get; set; }
        Image secondChannelImage { get; set; }
        Image thirdChannelImage { get; set; }

        public abstract List<Image> SeparateChannels(Image image);
    }
}
