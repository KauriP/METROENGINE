using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MetroEngine
{
    class TestBehaviour : UpdateComponent
    {
        string message;
        public TestBehaviour(String message)
        {
            this.message = message;
        }

        override public void Update()
        {
            Console.WriteLine("TestBehaviour update1 done! It said \"{0}\"",message);
            Owner.transform.Translate(new Vector2(0.6f, 0.7f));
        }
    }
}
