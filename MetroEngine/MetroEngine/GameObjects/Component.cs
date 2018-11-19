using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MetroEngine
{
    class Component
    {
        GameObject owner;
        public GameObject Owner { get { return owner; } }

        public void SetOwner(GameObject newOwner)
        {
            owner = newOwner;
        }
    }
}
