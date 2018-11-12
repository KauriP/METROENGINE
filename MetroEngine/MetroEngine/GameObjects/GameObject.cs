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
        Transform transform;

        public GameObject()
        {
            components = new List<Component>();
        }
        
        public void AddComponent(Component component)
        {
            components.Add(component);
        }
    }
}
