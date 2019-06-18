using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKAssignment5.HKUtilityClasses
{
    class HKStringUtilities
    {
        /// <summary>
        /// The first letter of each word convert to the capital letter
        /// </summary>
        public static string setCapitalizedString(string sVal)
        {
            if (string.IsNullOrEmpty(sVal)) return null;

            string sNewVal = "";
            string[] sArryVal = sVal.ToLower().Split(' ');
            for(int i = 0; i < sArryVal.Length; i++)
            {
                sNewVal += sArryVal[i].Substring(0, 1).ToUpper() + sArryVal[i].Substring(1) + " ";
            }

            return sNewVal.Trim();
        }
        /// <summary>
        /// Extract only digital number from the string value.
        /// </summary>
        public static string getOnlyDigitals(string sVal)
        {
            string sNewVal = "";
            for(int i = 0; i < sVal.Length; i++)
            {
                if (HKNumericUtilities.IsInteger(sVal[i].ToString()))
                    sNewVal += sVal[i];
            }
            return sNewVal;
        }
        /// <summary>
        /// Set mask of phone number
        /// If the length of the phone number is not 7 or 10, return an error message.
        /// </summary>
        public static string setPhoneMask(string sVal)
        {
            string sNewVal = getOnlyDigitals(sVal);

            if (sNewVal.Length == 7)
                sNewVal = sNewVal.Insert(3, "-");

            else if (sNewVal.Length == 10)
                sNewVal = sNewVal.Insert(3, "-").Insert(7, "-");

            else sNewVal = "The length of the phone number is not appropriate.(" + sVal + ")";

            return sNewVal;
        }
        /// <summary>
        /// set format of postal code with space of the middle
        /// </summary>
        public static string setPostalCode(string sVal)
        {
            if (string.IsNullOrEmpty(sVal)) return null;

            if (sVal.Length == 6) sVal = sVal.ToUpper().Insert(3, " ");

            return sVal;
        }
        /// <summary>
        /// Set format of US zipt code
        /// If the length of the phone number is not 5 or 9, return an error message.
        /// </summary>
        public static string setUSZipCodeFormat(string sVal)
        {
            if (sVal.Length == 5)
                return sVal;

            else if (sVal.Length == 9)
                return sVal.Insert(5, "-");
            
            else 
                return "The length of zip code is not appropriate.(" + sVal + ")";
        }
        /// <summary>
        /// Create a full name
        /// </summary>
        public static string FullName(string sFirstName, string sLastName)
        {
            sFirstName = setCapitalizedString(sFirstName);
            sLastName = setCapitalizedString(sLastName);

            if (sFirstName == null && sLastName == null)
                return null;

            else if (sFirstName == null)
                return sLastName;

            else if (sLastName == null)
                return sFirstName;

            else 
                return sLastName + " " + sFirstName;
        }
        public static string NoPunctuationString(string sVal)
        {
            return sVal.Replace(",", "").Replace("-", "").Replace(" ", "");
        }
    }
}
