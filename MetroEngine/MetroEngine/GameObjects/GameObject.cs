using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class GameObject
    {
        List<Component> components;
        public GameObject()
        {
            components = new List<Component>();
            Transform transform;
        }
    }
}
