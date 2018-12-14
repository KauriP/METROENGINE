using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetroEngine
{
    class Texture
    {
        PixelFormat pixelFormat;
        byte bytesPerPixel;
        //int width, height;
        Vector2Int size;
        public Vector2Int Size { get; }
        //SubPixels RGB(A)/V
        byte[] subPixels;

        public Texture()
        {
            pixelFormat = PixelFormats.Bgra32;
            bytesPerPixel = (byte)(pixelFormat.BitsPerPixel/8);
        }

        //SubPixels to color
        Color SP2C(Vector2Int pos)
        {
            if (bytesPerPixel == 3) return Color.FromRgb(subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 1], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 2]);
            if (bytesPerPixel == 4) return Color.FromArgb(subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 3], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 1], subPixels[(pos.X + size.X * pos.Y) * bytesPerPixel + 2]);

            else return Colors.HotPink;
        }

        Color GetPixel(Vector2Int uvPos)
        {
            if (uvPos.IsIn(size)) return SP2C(uvPos);
            else return Colors.Black;
        }
    }
}
