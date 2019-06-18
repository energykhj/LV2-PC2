using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKAssignment5.HKUtilityClasses
{
    class HKNumericUtilities
    {
        /// <summary>
        /// Regular expression
        /// </summary>
        public static bool IsMatchRX(string sPattern, Object oVal)
        {
            Regex rx = new Regex(sPattern, RegexOptions.IgnoreCase);
            return rx.IsMatch(oVal.ToString());
        }
        /// <summary>
        /// Accept string parameter.
        /// Can contain '-': leading dash, '.': single decimal, anywhere
        /// Return true if the parameter contains only a number.
        /// </summary>
        public static bool IsNumeric(string sVal)
        {
            return IsMatchRX(@"^[-]?\d*[.]?\d+$", sVal);
        }
        /// <summary>
        /// Accepts object parameter
        /// Can contain '-': leading dash, '.': single decimal, anywhere
        /// </summary>
        public static bool IsNumeric(Object oVal)
        {
            return IsMatchRX(@"^[-]?\d*[.]?\d+$", oVal); 
        }
        /// <summary> 
        /// Cannot accept decimal. 
        /// Return true if the parameter contains only a number.
        /// IsInteger with string parameter
        /// </summary>
        public static bool IsInteger(string sVal)
        {
            return IsMatchRX(@"^\d*$", sVal);
        }
        /// <summary>
        /// IsInteger with object parameter
        /// </summary>
        public static bool IsInteger(double dVal)
        {
            return IsMatchRX(@"^\d*$", dVal);
        }
        /// <summary>
        /// IsInteger with object parameter
        /// </summary>
        public static bool IsInteger(Object oVal)
        {
            return IsMatchRX(@"^\d*$", oVal);
        }
      
        /// <summary>
        /// Only accept digits, decimal place and dash.
        /// Cannot allow ',', '$', spaces, and trailing dashes.
        /// Numeric check.
        /// </summary>
        public static string NoPunctuationString(string sVal)
        {
            string sNewVal = sVal.Replace(",", "").Replace("$", "").Replace(" ", "");

            if (sNewVal.EndsWith("-"))
                sNewVal = "-" + sNewVal.Substring(0, sNewVal.Length - 1);

            return (IsNumeric(sNewVal))? sNewVal : null;
        }
        /// <summary>
        /// Only allow numeric
        /// </summary>
        /// <param name="e"></param>
        public static void KeyPressEventHandler(KeyPressEventArgs e)
        {
            e.Handled = (IsNumeric(e.KeyChar)) ? false : true;
        }
    }
}
