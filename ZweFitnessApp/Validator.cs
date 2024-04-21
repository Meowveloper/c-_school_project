using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweFitnessTrackingAPP
{
    internal class Validator
    {
        //checking validation for one input field
        private bool checkValidationForOne(TextBox textBox)
        {
            float numnum;
           if(textBox.Text.Length == 0 || textBox.Text == "" || textBox.Text == null || !float.TryParse(textBox.Text, out numnum )) 
           {
                return true;     
           } else
           {
                return false;
           }
        }

        //checking validation for multiple input fileds
        public bool checkValidationForAll(params TextBox[] textBoxes) 
        {
            bool notCool = false;

            foreach (TextBox item in textBoxes)
            {   
                if(checkValidationForOne(item))
                {
                    notCool = true;
                    break;
                }
            }

            return notCool;
        }

        //checking if the input value is within validate range
        public bool checkingIfInsideRange(TextBox textBox, float min, float max)
        {
            bool notCool = false;

            if(float.Parse(textBox.Text) < min || float.Parse(textBox.Text) > max)
            {
                notCool = true;
            }
                
            return notCool;
        }
    }
}
