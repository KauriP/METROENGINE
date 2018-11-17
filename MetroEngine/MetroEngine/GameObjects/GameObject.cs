using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class GameObject
    {
        GameObject parent;
        List<Component> components;
        Transform transform;

        public GameObject()
        {
            components = new List<Component>();
        }

        public IEnumerable<Component> GetComponentsEnumerable()
        {
            foreach(Component component in components)
            {
                yield return component;
            }
        }
        
        public void AddComponent(Component component)
        {
            components.Add(component);

        }
    }
}
