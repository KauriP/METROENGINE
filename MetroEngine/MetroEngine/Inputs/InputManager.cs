﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroEngine
{
    /*class InputManager
    {

        class InputAxis
        {
            private bool down;
            private bool positiveheld;
            private bool negativeheld;
            private bool up;
            private static float value;
            public Keys positive;
            public Keys negative;

            

            public static float GetValue()
            {
                float result = 0;
                result = InputAxis.value;
                return result;


            }
            public void RDown(bool positive)
            {
                down = true;
                
                if(positive)
                {
                    value += 1;
                    positiveheld = true;
                } else
                {
                    value -= 1;
                    negativeheld = true;

                }
            }
            public void RUp(bool positive)
            {
                up = true;

                if (positive)
                {
                    positiveheld = false;
                    value -= 1;

                }else
                {
                    negativeheld = false;
                    value += 1;

                }


            }
        }
        Dictionary<string, InputAxis> axes = new Dictionary<string, InputAxis>();

        public void AddAxes()
        {
            axes.Add("nimi", new InputAxis());
        
        
        
        }
        public void ReactDown(object sender, KeyEventArgs e)
        {
            foreach ( InputAxis axis in axes.Values)
            {
                if (axis.positive == (e.KeyCode)) axis.RDown(true);
                if (axis.negative == (e.KeyCode)) axis.RDown(false);
            }
        }
        public void ReactUp(object sender, KeyEventArgs e)
        {
            foreach (InputAxis axis in axes.Values)
            {
                if (axis.positive == (e.KeyCode)) axis.RUp(true);
                if (axis.negative == (e.KeyCode)) axis.RUp(false);
            }

        }
    }*/
}
