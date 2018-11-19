using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Controls;

namespace MetroEngine
{
    public class Engine
    {
        /// <summary>Game window</summary>
        MainWindow mainWindow;
        /// <summary>Input manager</summary>
        public InputManager input;
        ///<summary>Timer for all loops</summary>
        Stopwatch loopTimer;
        ///<summary>Object and component lists etc.</summary>
        GameData data;

        ///Logic looping task
        CancellationTokenSource logicExitTokenSource;
        CancellationToken logicExitToken;
        Task logicTask;
        LogicLoop logicLoop;

        /////Drawing looping taks
        //CancellationTokenSource drawExitTokenSource;
        //CancellationToken drawExitToken;
        //Task drawTask;
        DrawLoop drawLoop;

        //Siirretään piirtäminen LogicLooppiin

        
        public Engine(MainWindow outImage)
        {
            this.mainWindow = outImage;
            StartUp();
        }

        void StartUp()
        {
            data = new GameData();
            input = new InputManager();

            Testaus();

            loopTimer = new Stopwatch();

            InitializeDrawLoop();
            InitializeLogicLoop();

            StartLoops();
        }

        void InitializeLogicLoop()
        {
            logicLoop = new LogicLoop(ref data, ref drawLoop);

            logicExitTokenSource = new CancellationTokenSource();
            logicExitToken = logicExitTokenSource.Token;
            logicTask = new Task(() => logicLoop.Infinite(ref loopTimer, 16.6667f, logicExitToken), logicExitToken, TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up logic loop.");
        }

        void InitializeDrawLoop()
        {
            drawLoop = new DrawLoop(ref data, ref mainWindow);

            //drawExitTokenSource = new CancellationTokenSource();
            //drawExitToken = drawExitTokenSource.Token;
            //drawTask = new Task(() => drawLoop.Infinite(ref loopTimer, 16.6667f, drawExitToken), drawExitToken, TaskCreationOptions.LongRunning);

            //Console.WriteLine("Starting up drawing loop.");
        }

        public void ShutDown()
        {
            StopLoops();
        }

        void StartLoops()
        {
            loopTimer.Start();

            logicTask.Start();
            //drawTask.Start();
        }

        //pitäis implementoida
        void StopLoops()
        {
            logicExitTokenSource.Cancel();
            //drawExitTokenSource.Cancel();
        }

        
        //TESTAUSTA
        void Testaus()
        {
            GameObject peliobjekti1 = new GameObject();
            UpdateComponent testiKomponentti = new TestBehaviour("Hello world!");
            peliobjekti1.AddComponent(testiKomponentti);
            data.AddGameObject(peliobjekti1);
            input.AddAxis("Testiakseli", System.Windows.Input.Key.B);
        }
    }
}
