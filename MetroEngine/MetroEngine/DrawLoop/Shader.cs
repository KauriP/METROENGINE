using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class Shader
    {
        Vector2Int ScreenPos;
        Texture texture;
        PixelCanvas canvas;

        public void Shade(PixelCanvas canvas)
        {
            this.canvas = canvas;
        }

        protected virtual void Fragment(Vector2Int ScreenPos, Vector2Int uvPos)
        {

        }

        //EI TODELLAKAAN TOIMI
        protected virtual void Vertex(Vector2Int pos, int rotation = 0, int size = 1)
        {
            switch (rotation%4)
            {
                case 0:
                    for (int x = pos.X; x < pos.X + texture.Size.X*size; x++)
                    {
                        for (int y = pos.Y; y < pos.Y + texture.Size.Y*size; y++)
                        {
                            Fragment(new Vector2Int(x, y), new Vector2Int(x, y));
                        }
                    }
                    break;
            }
        }
    }
}
