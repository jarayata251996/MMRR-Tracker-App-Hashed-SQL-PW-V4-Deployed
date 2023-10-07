using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace MMRR_Tracker
{
    public class requiredObjects
    {


        public void ChangeControlsBackgroundColors(Control[] controls, Color color)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }

        public void ChangeControlsBackgroundColor(Control controls, Color color)
        {

            controls.BackColor = color;
            
        }

    }

    public class requiredTenLengthNoSpecialChar
    {


        public static bool check(string text)
        {
            string pattern = @"^[a-zA-Z0-9]{10}$";


            if (Regex.IsMatch(text, pattern))
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        

        
    }
}
