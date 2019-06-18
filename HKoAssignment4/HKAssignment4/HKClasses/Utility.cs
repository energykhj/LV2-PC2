/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment4
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.HKClasses
{
    class Utility
    {
        /*
        * Changes null value to empty string
        **/
        public static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString().Trim();
        }

        /*
         * Trim leading & trailing spaces of incoming string,
         * Null or whitespace is converted to empty,
         * convert to lower case and then capitalise each word in the string. 
         **/
        public static string HKoCapitalize(string sOrigin)
        {
            if (string.IsNullOrEmpty(sOrigin)) return sOrigin;

            string sCapital = "";
            string[] sArry = sOrigin.Trim().ToLower().Split(' ');

            for (int i = 0; i < sArry.Length; i++)
            {
                string sTemp = (i == sArry.Length - 1) ?
                    sArry[i] : sArry[i] + ' ';

                if (string.IsNullOrWhiteSpace(sTemp))
                {
                    sTemp = sTemp.Replace(sTemp, string.Empty);
                }
                else
                {
                    sCapital += sTemp.Substring(0, 1).ToUpper() +
                        sTemp.Substring(1);
                }
            }
            return sCapital;
        }
    }
}
