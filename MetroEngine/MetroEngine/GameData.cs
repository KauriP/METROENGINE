using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class GameData
    {
        private Dictionary<String, GameObject> gameObjects;

        ///<summary>Unique gameobject names</summary>
        long gameObjectNameCounter;

        public GameData()
        {
            gameObjects = new Dictionary<string, GameObject>();
            //updateComponents = new List<UpdateComponent>();
        }

        public IEnumerable<UpdateComponent> GetUpdateComponents()
        {
            foreach (GameObject gameObject in gameObjects.Values)
            {
                foreach(Component component in gameObject.GetComponentsEnumerable())
                {
                    if(component is UpdateComponent)
                    {
                        yield return (UpdateComponent)component;
                    }
                }
            }
        }

        public string AddGameObject(GameObject gameObject)
        {
            string newName = "GO_" + (gameObjectNameCounter++).ToString();
            return AddGameObject(gameObject, newName);
        }

        public string AddGameObject(GameObject gameObject, string name)
        {
            if (gameObjects.ContainsKey(name))
            {
                string newName = name + "_1";
                return AddGameObject(gameObject, newName);
            }
            gameObjects.Add(name, gameObject);
            return name;
        }
    }
}
