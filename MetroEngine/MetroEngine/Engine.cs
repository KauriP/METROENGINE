using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace MetroEngine
{
    public class Engine
    {
        /*
         Input input;
         Luokka, josta voisi saada näppäinten, näppäimistä tehtyjen akselien(, ja mahdollisesti vielä niistä prosessoitujen toimintojen) arvot
         +hiiri
             */
        GameForm gameForm;
        //Timer for all loops
        Stopwatch loopTimer;
        //Logic looping task
        CancellationTokenSource logicExitTokenSource;
        CancellationToken logicExitToken;
        Task logicTask;
        LogicLoop logicLoop;
        float logicLoopInterval;

        public Engine(ref GameForm inputGameForm)
        {
            gameForm = inputGameForm;
            StartUp();
        }

        void StartUp()
        {
            loopTimer = new Stopwatch();


            logicExitTokenSource = new CancellationTokenSource();
            logicExitToken = logicExitTokenSource.Token;
            logicLoop = new LogicLoop();
            logicLoopInterval = 16.6667f;

            logicTask = new Task(() => logicLoop.Infinite(ref loopTimer, logicLoopInterval), logicExitToken, TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up");
            StartLoops();
        }

        public void ShutDown()
        {
            StopLoops();
        }

        void StartLoops()
        {
            loopTimer.Start();
            logicTask.Start();
        }

        //pitäis implementoida
        void StopLoops()
        {

        }
    }
}
