using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    class TestBehaviour : UpdateComponent
    {
        string message;
        public TestBehaviour(String message)
        {
            this.message = message;
        }

        override public void Update1()
        {
            Console.WriteLine("TestBehaviour update1 done! It said \"{0}\"",message);
        }
    }
}
