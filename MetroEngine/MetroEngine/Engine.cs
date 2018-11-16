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
        GameForm gameForm;
        //Timer for all loops
        Stopwatch loopTimer;
        //Logic looping task
        CancellationTokenSource logicExitTokenSource;
        CancellationToken logicExitToken;
        Task logicTask;
        LogicLoop logicLoop;
        float logicLoopInterval;

        //Objekti- ja komponentttilistat
        List<UpdateComponent> updateComponents;
        Dictionary<String, GameObject> gameObjects;

        //Unique gameobject names
        long gameObjectNameCounter;

        public Engine(ref GameForm inputGameForm)
        {
            gameForm = inputGameForm;
            StartUp();
            updateComponents = new List<UpdateComponent>();
            gameObjects = new Dictionary<String, GameObject>();
        }

        void StartUp()
        {
            gameObjects = new Dictionary<string, GameObject>();
            updateComponents = new List<UpdateComponent>();

            gameObjectNameCounter = 0;

            Testaus();

            InitializeLogicLoop();
            InitializeDrawLoop();
            

            StartLoops();
        }

        void InitializeLogicLoop()
        {
            loopTimer = new Stopwatch();

            logicExitTokenSource = new CancellationTokenSource();
            logicExitToken = logicExitTokenSource.Token;
            logicLoop = new LogicLoop(ref gameObjects, ref updateComponents);
            logicLoopInterval = 16.6667f;

            logicTask = new Task(() => logicLoop.Infinite(ref loopTimer, logicLoopInterval), logicExitToken, TaskCreationOptions.LongRunning);

            Console.WriteLine("Starting up logic loop.");
        }

        void InitializeDrawLoop()
        {

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

        string AddGameObject(GameObject gameObject)
        {
            string newName = "GO_" + (gameObjectNameCounter++).ToString();
            return AddGameObject(gameObject, newName);
        }

        string AddGameObject(GameObject gameObject, string name)
        {
            if(gameObjects.ContainsKey(name)) {
                string newName = name + "_1";
                return AddGameObject(gameObject, newName);
            }
            gameObjects.Add(name, gameObject);
            return name;
        }
        //TESTAUSTA
        void Testaus()
        {
            GameObject peliobjekti1 = new GameObject();
            UpdateComponent testiKomponentti = new TestBehaviour("Hello world!");
            peliobjekti1.AddComponent(testiKomponentti);
            updateComponents.Add(testiKomponentti);
            AddGameObject(peliobjekti1);
        }
    }
}
