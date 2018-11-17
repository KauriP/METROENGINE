using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroEngine
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public void DebugDraw(Bitmap bitmap)
        {
            this.BackgroundImage = bitmap;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
