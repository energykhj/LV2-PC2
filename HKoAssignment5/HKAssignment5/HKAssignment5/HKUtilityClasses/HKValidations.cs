using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKAssignment5.HKUtilityClasses
{
    class HKValidations
    {
        /// <summary>
        /// Validates a Canadian Postal Code pattern (A3A 3A3)
        /// 18 letters+[0-9]+20 letters " " [0-9]+20 letters+[0-9]
        /// " " is optional
        /// </summary>
        public static bool validatePostalCode(string sVal)
        {
            if (string.IsNullOrEmpty(sVal))
                return true;
            
            return HKNumericUtilities.IsMatchRX(
                @"[ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ] ?\d[ABCEGHJKLMNPRSTVWXYZ]\d", sVal);
        }
        /// <summary>
        /// Validate USZip Code length
        /// extracts the digits from a string then confirms that length is 5 or 9
        /// </summary>
        public static bool valideUSZipCode(string sVal)
        {
            string sNewVal = HKStringUtilities.getOnlyDigitals(sVal);
            return ((sNewVal.Length == 5) || (sNewVal.Length == 9)) ? true : false;
        }
        /// <summary>
        /// Validates phone number length
        /// extracts the digits from a string then confirms that length is 10
        /// </summary>
        public static bool validatePhoneNumber(string sVal)
        {
            return (HKStringUtilities.getOnlyDigitals(sVal).Length == 10) ? true : false;
        }
    }
}
