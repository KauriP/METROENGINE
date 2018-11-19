using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MetroEngine
{
    struct Vector2Int
    {
        public int X, Y;
        public Vector2Int(int p1, int p2)
        {
            X = p1;
            Y = p2;
        }

        public static Vector2Int Zero { get { return new Vector2Int(0, 0); } }
    }

    class Transform
    {
        public Vector2Int position;
        /// <summary>
        /// Float 0-1; position within pixel
        /// </summary>
        public Vector2 subPosition;

        /// <summary>
        /// %4= 0 - up, 1 - right, 2 - down, 3 - left 
        /// </summary>
        int rotation;

        public Transform(double xf, double yf)
        {
            position.X = (int)xf;
            position.Y = (int)yf;
            subPosition.X = (float)(xf - position.X);
            subPosition.Y = (float)(yf - position.Y);
        }
    }
}
