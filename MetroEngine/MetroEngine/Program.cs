using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace MetroEngine
{
    static class Program
    {
        static public TestNosing nosing;
        static Engine engine;
        static GameForm gameForm;

        [STAThread]
        static void Main()
        {
            nosing = new TestNosing();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Starting up
            gameForm = new GameForm();
            engine = new Engine(ref gameForm);
            Application.Run(gameForm);
        }
    }
}
