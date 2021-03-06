﻿using System;
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
        /// <summary>Input manager</summary>
        InputManager input;
        /// <summary>Game window</summary>
        GameForm gameForm;
        ///<summary>Timer for all loops</summary>
        Stopwatch loopTimer;
        ///<summary>Object and component lists etc.</summary>
        GameData data;

        ///Logic looping task
        CancellationTokenSource logicExitTokenSource;
        CancellationToken logicExitToken;
        Task logicTask;
        LogicLoop logicLoop;

        ///Drawing looping taks
        CancellationTokenSource drawExitTokenSource;
        CancellationToken drawExitToken;
        Task drawTask;
        DrawLoop drawLoop;


        
        public Engine(ref GameForm inputGameForm)
        {
            gameForm = inputGameForm;
            StartUp();
        }

        void StartUp()
        {
            data = new GameData();

            Testaus();

            loopTimer = new Stopwatch();

            InitializeLogicLoop();
            InitializeDrawLoop();

            StartLoops();
        }

        void InitializeLogicLoop()
        {
            logicExitTokenSource = new CancellationTokenSource();
            logicExitToken = logicExitTokenSource.Token;
            logicLoop = new LogicLoop(ref data);

            logicTask = new Task(() => logicLoop.Infinite(ref loopTimer, 16.6667f), logicExitToken, TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up logic loop.");
        }

        void InitializeDrawLoop()
        {
            drawExitTokenSource = new CancellationTokenSource();
            drawExitToken = drawExitTokenSource.Token;
            drawLoop = new DrawLoop(ref data);

            drawTask = new Task(() => drawLoop.Infinite(ref loopTimer, 16.6667f), drawExitToken, TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up drawing loop.");
        }

        void ShutDown()
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

        
        //TESTAUSTA
        void Testaus()
        {
            GameObject peliobjekti1 = new GameObject();
            UpdateComponent testiKomponentti = new TestBehaviour("Hello world!");
            peliobjekti1.AddComponent(testiKomponentti);
            data.AddGameObject(peliobjekti1);
        }
    }
}
