/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment2
 * Collecting the validation functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HKoAssignment2
{
    class HKoValidation
    {
        /*
         * Trim leading & trailing spaces of incoming string,
         * Null or whitespace is converted to empty,
         * convert to lower case and then capitalise each word in the string. 
         **/
        public string HKoCapitalize(string sOrigin)
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
        // Making regular expressions for postal code.
        // Allow pattern A2V 2A2.
        public bool HKoPostalCodeValidation(string sPC)
        {
            if (string.IsNullOrEmpty(sPC)) return true;
            //if postcode length is 6, insert the space into the middle of them.
            if(sPC.Length == 6)
            {
                sPC = sPC.Insert(3, " ");
            }

            string sPattern = @"^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]" +
                "{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";
            return Validate(sPattern, sPC);
        }
        // Making regular expressions for province code.
        // Allow two letters.
        public bool HKoProvinceValidation(string sProvince)
        {            
            string sPattern = @"^[A-Z]{2}$";
            return Validate(sPattern, sProvince);
        }
        // Making regular expressions for phone numbers.
        // Allow pattern 123-123-1234, with or without the dashes.
        public bool HKoPhoneNumberValidation(string sPhone)
        {
            if (sPhone.IndexOf('-') < 0 && sPhone.Length > 10) return false;
            //string sPattern = @"^\d{10}$";
            string sPattern = @"^\d{10}|\d{3}-\d{3}-\d{4}$";
            return Validate(sPattern, sPhone);
        }

        // Making regular expressions for numeric.  
        // Allows only numbers and '.'.
        public bool HkoIsNumeric(string sValue)
        {
            if (sValue.Length < 2) return false;
            return Validate(@"^[0-9.]+$", sValue);
        }
        
        // Validate with a regular pattern.
        private bool Validate(string sPattern, string sValue)
        {
            try
            {                
                if (string.IsNullOrEmpty(sValue) ||
                    string.IsNullOrEmpty(sPattern)) return false;

                Regex reg = new Regex(sPattern, 
                    RegexOptions.IgnoreCase | 
                    RegexOptions.IgnorePatternWhitespace);
                return reg.IsMatch(sValue);
            }
            catch
            {
                return false;
            }
        }
        // Validate an email.
        // Allows aaa@aaa, aaa@aaa.aa.
        public bool IsValidEmail(string email)
        {
            try
            {   
                var addr = new System.Net.Mail.MailAddress(email.Trim());
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void aa()
        {
            string sPhone =@"^\(?(\d{3})\)?[.- *]?(\d{3})[.- *]?(\d{4})$";
            string sZip = @"([ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}( )?[0-9][[ABCEGHJ-NPRSTV-Z]][0-9])";
            string eMail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w{2,3})+)$";

            Regex rx = new Regex(sPhone, RegexOptions.IgnoreCase);
            rx.IsMatch("ddd.Text");

        }
    }
}
