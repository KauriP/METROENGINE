using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace MetroEngine
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer aTimer;
        private static DateTime previous;
        private static Stopwatch stopwatch = new Stopwatch();
        private static Stopwatch loopTimer;
        private float interval = 10f;
        public delegate void doTestUpdate();
        public doTestUpdate delegateTU;
        Task taskA;
        CancellationTokenSource exitSource;
        CancellationToken exitToken;
        public Form1()
        {
            InitializeComponent();
            Application.Idle += new EventHandler(Application_Idle);
            delegateTU = new doTestUpdate(TestUpdate);
            exitSource = new CancellationTokenSource();
            exitToken = exitSource.Token;
            //StartLoop();
            //SetTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                Application.Exit();
            }
        }

        private void Application_Idle(Object sender, EventArgs e)
        {

        }

        private void StartLoop()
        {
            loopTimer = new Stopwatch();
            loopTimer.Start();
            taskA = Task.Run(() => Infinite(exitToken));
            label1.Text = "Toimii";
        }

        private void Infinite(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelled");
                    return;
                }
                Console.WriteLine("TC:" + (cancellationToken.IsCancellationRequested).ToString());
                Invoke(delegateTU);
                Thread.Sleep((int)(interval - loopTimer.ElapsedMilliseconds % interval));
            }
        }

        private void TestUpdate()
        {
            label1.Text += ".";
            CheckElapsedTime();
        }

        private static void OnTimedEvent(Object source, EventArgs e)
        {
            CheckElapsedTime();
        }

        private static void CheckElapsedTime()
        {
            stopwatch.Stop();
            Console.WriteLine("Aikaa kului {0} ms", (stopwatch.ElapsedMilliseconds));
            stopwatch.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartLoop();
            label1.Text = "Nappi painettu!";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing...");
            exitSource.Cancel();
            Application.DoEvents();
            taskA.Wait();
        }
    }
}