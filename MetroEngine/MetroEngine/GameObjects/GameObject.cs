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
        public Transform transform;

        public GameObject(Transform transform = null, GameObject parent = null, List<Component> components = null)
        {
            this.parent = parent;
            this.transform = transform ?? new Transform(0,0);
            this.components = components ?? new List<Component>();
        }

        public void AddComponent(Component component)
        {
            component.SetOwner(this);
            components.Add(component);
        }

        public Component GetComponentByType<T>()
        {
            foreach(Component component in components)
            {
                if (component is T) return component;
            }
            return null;
        }

        public IEnumerable<Component> GetComponentsEnumerable()
        {
            foreach (Component component in components)
            {
                yield return component;
            }
        }
    }
}
