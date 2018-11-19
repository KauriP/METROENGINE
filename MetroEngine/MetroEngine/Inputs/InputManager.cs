using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetroEngine
{
    public class InputManager
    {

        class InputAxis
        {
            private bool down;
            private bool up;
            private float value;
            private bool positiveheld;
            private bool negativeheld;
            public Key positive;
            public Key negative;

            public float Value { get; }
            public bool Up { get; }
            public bool Down { get; }

            public InputAxis(Key positive, Key negative)
            {
                this.positive = positive;
                this.negative = negative;
            }
            
            public void RDown(bool positive)
            {
                Console.WriteLine("Axis pressed");
                down = true;

                if (positive)
                {
                    value += 1;
                    positiveheld = true;
                }
                else
                {
                    value -= 1;
                    negativeheld = true;

                }
            }

            public void RUp(bool positive)
            {
                Console.WriteLine("Axis released");
                up = true;

                if (positive)
                {
                    positiveheld = false;
                    value -= 1;

                }
                else
                {
                    negativeheld = false;
                    value += 1;

                }
            }
        }
        Dictionary<string, InputAxis> axes = new Dictionary<string, InputAxis>();

        public void AddAxis(string name, Key positive, Key negative = Key.None)
        {
            axes.Add(name, new InputAxis(positive, negative));
        }

        public void ReactDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;

            foreach (InputAxis axis in axes.Values)
            {
                if (axis.positive == (e.Key)) axis.RDown(true);
                if (axis.negative == (e.Key)) axis.RDown(false);
            }
        }

        public void ReactUp(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;

            foreach (InputAxis axis in axes.Values)
            {
                if (axis.positive == (e.Key)) axis.RUp(true);
                if (axis.negative == (e.Key)) axis.RUp(false);
            }

        }
    }
}
