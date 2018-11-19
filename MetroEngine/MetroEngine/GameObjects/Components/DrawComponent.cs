using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class DrawComponent : Component
    {
        //Bitmap sprite?
        Vector2Int offset;
        /// <summary>
        /// Draw order. 0-999 2foreground; 1000-1999 foreground; 2000-2999 midfore; 3000-3999 midmid(default); 4000-4999 midback; 5000-5999 background; 6000-6999 2background; 7000-7999 3background; 8000-8999 static
        /// </summary>
        int zDepth;

        public DrawComponent(int zDepth = 3500)
        {
            this.zDepth = zDepth;
            offset = Vector2Int.Zero;
        }

        public IEnumerable<DrawLoop.DrawPixel> GetDraw()
        {
            //BGRA
            yield return new DrawLoop.DrawPixel(new byte[] {255,0,255,0}, Vector2Int.Zero);
        }
    }
}
