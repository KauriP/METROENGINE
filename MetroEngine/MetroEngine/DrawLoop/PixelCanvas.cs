using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetroEngine
{
    class PixelCanvas
    {
        PixelFormat pixelFormat;
        byte bytesPerPixel;
        //RGB
        byte[] subPixels;
        Vector2Int size;

        public PixelCanvas()
        {
            size.X = 300;
            size.Y = size.X * 9 / 16;
            pixelFormat = PixelFormats.Bgr24;

            bytesPerPixel = (byte)(pixelFormat.BitsPerPixel / 8);
            subPixels = new byte[size.X * size.Y * bytesPerPixel];
        }

        Color SP2C(Vector2Int pos)
        {
            return Color.FromRgb(subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 1], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 2]);
        }

        public Color GetPixel(Vector2Int uvPos)
        {
            if (uvPos.IsIn(size)) return SP2C(uvPos);
            else return Colors.Black;
        }
    }
}
