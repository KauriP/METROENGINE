using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class Component
    {
        GameObject owner;
        public GameObject Owner { get; }

        public void SetOwner(GameObject newOwner)
        {
            owner = newOwner;
        }
    }
}
