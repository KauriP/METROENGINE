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
        //Timer for all loops1
        static Stopwatch loopTimer;
        //Logic looping task
        static CancellationTokenSource logicExitTokenSource;
        static CancellationToken logicExitToken;
        static Task logicTask;
        static LogicLoop logicLoop;
        static float logicLoopInterval;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            nosing = new TestNosing();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartUp();
            //Application.Run(new GameForm());
            //Application.Run(new Form1());
        }

        static void StartUp()
        {
            loopTimer = new Stopwatch();


            logicExitTokenSource = new CancellationTokenSource();
            logicExitToken = logicExitTokenSource.Token;
            logicLoop = new LogicLoop();
            logicLoopInterval = 16.6667f;

            logicTask = new Task(() => logicLoop.Infinite(ref loopTimer, logicLoopInterval),logicExitToken,TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up");
            StartLoops();
            Application.Run(new GameForm());
        }

        static public void ShutDown()
        {
            StopLoops();
        }

        static void StartLoops()
        {
            loopTimer.Start();
            logicTask.Start();
        }

        //pitäis implementoida
        static void StopLoops()
        {

        }
    }
}
