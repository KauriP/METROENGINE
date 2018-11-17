using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class GameData
    {
        public List<UpdateComponent> updateComponents;
        public Dictionary<String, GameObject> gameObjects;
        
        public GameData()
        {
            gameObjects = new Dictionary<string, GameObject>();
            updateComponents = new List<UpdateComponent>();
        }
    }
}
