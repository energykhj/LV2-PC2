/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment4
 * OOP: Encapsulated Class
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment4.HKClasses
{
    class HKProvince
    {
        private StreamReader SR;
        private StreamWriter SW;
        private string FILENAME = "C:\\PROG1815data\\Province.txt";
        private bool IsEdit = false;    // false : Province code is not exist

        public string ProvinceCode { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string TaxCode { get; set; }
        public double TaxRate { get; set; }
        public bool IncludesFederalTax { get; set; }

        /* 
        *  Default constructor
        *   - Create directory and file if they do not exist
        */
        public HKProvince()
        {
            try
            {
                if (!File.Exists(FILENAME))
                {
                    string DIR = FILENAME.Substring(0, FILENAME.LastIndexOf("\\"));

                    if (!Directory.Exists(DIR))
                        Directory.CreateDirectory(DIR);
                                       
                    FileStream fs = File.Create(FILENAME);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
         *  Overriding ToString()
         *   - make a data for the record string with the delimiter ,'-'
         */
        public override string ToString()
        {
            return string.Concat(ProvinceCode, "-", Name, "-", 
                CountryCode, "-", TaxCode, "-", 
                TaxRate, "-", IncludesFederalTax);
        }
        /*
         * Called in another method. Parsing the stringl to make each field. 
         *  - sRecord made with the delimiter(-) like this
         *      "ProvinceCode-ProvinceName-CountryCode..."
         *  - return : Province class object
         */
        public HKProvince HKParseProvince(string sRecord)
        {
            string[] sArry = sRecord.Split('-');
            HKProvince pv = new HKProvince();

            if (sArry.Length != 6)
                throw new Exception("Its not a province record.");
            else
            { 
                pv.ProvinceCode = sArry[0];
                pv.Name = sArry[1];
                pv.CountryCode = sArry[2];
                pv.TaxCode = sArry[3];
                pv.TaxRate = Convert.ToDouble(sArry[4]);
                pv.IncludesFederalTax = Convert.ToBoolean(sArry[5]);
            }

            return pv;
        }
        /*
         * Get a province record with the given province code.
         *  - sProvinceCode : province code input by user
         *  - return : Province class object, if found or null
         */
        public HKProvince HKGetByProvinceCode(string sProvinceCode)
        {
            foreach (HKProvince pv in HKGetProvinces())
            {
                if (pv.ProvinceCode == sProvinceCode)
                    return pv;
            }

            return null;
        }
        /*
         * Get a province record with the given province name.
         *  - sProvinceName : province name input by user
         *  - return : Province class object
         */
        public HKProvince HKGetByProvinceName(string sProvinceName)
        {   
            foreach (HKProvince pv in HKGetProvinces())
            {
                if (pv.Name.ToUpper() == sProvinceName.ToUpper())
                    return pv;
            }

            return null;
        }
        /*
         * Get all provinces from the file.
         *  - return : Province list
         */
        public List<HKProvince> HKGetProvinces()
        {
            List<HKProvince> pvList = new List<HKProvince>();

            if (File.Exists(FILENAME))
            {
                using (SR = File.OpenText(FILENAME))
                {
                    while (!SR.EndOfStream)
                    {
                        pvList.Add(HKParseProvince(SR.ReadLine()));
                    }
                    SR.Close();
                }
            }
            return pvList;
        }
        /*
         * Get all provinces from the file. Called from HKAdd or HKUpdate.
         *  - pv : Province class object
         *  - return : Province list
         */
        private void HKEdit(HKProvince pv)
        {
            string sError = "";
            Regex codePattern = new Regex(@"^[a-zA-Z]{2}$");

            if (Utility.NullToString(pv.ProvinceCode) == "")
                sError += "ProvinceCode is required.\n";
            else if (!codePattern.IsMatch(ProvinceCode))
                sError += "Province Code must be 2 letters.\n";

            if (Utility.NullToString(pv.Name) == "")
                sError += "Name is required.\n";

            if (Utility.NullToString(pv.CountryCode) == "")
                sError += "Country Code is required.\n";
            else if (!codePattern.IsMatch(CountryCode))
                sError += "Country Code must be 2 letters.\n";

            IsEdit = (HKGetByProvinceCode(pv.ProvinceCode) == null) ? false : true;
            HKProvince checkPV = HKGetByProvinceName(pv.Name);

            //checkPV != null : already exist the same province code in the record
            // !IsEdit : Current state is can add
            // If the provinceCode retrieved is not the same as the provinceCode entered
            if (checkPV != null)
            {
                if (!IsEdit || checkPV.ProvinceCode != pv.ProvinceCode)
                    throw new Exception(string.Format("Name [{0}] is " +
                        "already on file.\n", pv.Name));
            }
            
            // TaxCode is provided. It can be empty/null
            //  - upper case 
            //  - only letters. 
            if (Utility.NullToString(pv.TaxCode) != "")
            {                
                Regex taxPattern = new Regex(@"^[A-Z]+$");
                if (!taxPattern.IsMatch(pv.TaxCode.ToUpper()))
                    sError += "Tax code must be only in letters.\n";

                // TaxCode is not provided, 
                //  - TaxRate must be zero.  Otherwise, it can be zero to one, inclusive.  
                //  - Tax rate is between 0 and 1 
                //      regardless of whether Taxcode is provided or not
                if (0 > pv.TaxRate || pv.TaxRate > 1)
                    sError += "Tax rate must be 0, otherwise, " +
                    "it can be 0 to 1 inclusively.\n";
            }
            else
            {
                if (0 < pv.TaxRate)
                    sError += "Tax rate must be zero if TaxCode is empty/null.\n";
            }
            

            //  - IncludesFederalTax must be false when TaxRate is zero.
            if (pv.TaxRate == 0 && pv.IncludesFederalTax)
                sError += "Federal Tax cannot be included when tax rate is zero.\n";

            if (sError == "")
            {
                ProvinceCode = pv.ProvinceCode.ToUpper();
                Name = Utility.HKoCapitalize(pv.Name);
                CountryCode = pv.CountryCode.ToUpper();
                TaxCode = pv.TaxCode.ToUpper();
                TaxRate = pv.TaxRate;
                IncludesFederalTax = pv.IncludesFederalTax;
            }
            else
            {
                throw new Exception(sError);
            }


        }
        /*
         * Add a new province into the file.
         *  - pv : Province class object
         */
        public void HKAdd(HKProvince pv)
        {
            try
            {
                // Call HKEdit method to check can edit
                HKEdit(pv);
                if (IsEdit)
                    throw new Exception(string.Format("province code [{0}] " +
                        "already on file.", pv.ProvinceCode));
                else
                {
                    using (SW = new StreamWriter(FILENAME, append: true))
                    {
                        SW.WriteLine(pv.ToString());
                    }

                    SW.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        /*
         * Delele a province from the file.
         *  - pv : Province class object
         */
        public void HKDelete(string sProvinceCode)
        {
            bool isFound = false;
            try
            {
                List<HKProvince> pvs = HKGetProvinces();
                foreach (HKProvince pvItem in pvs)
                {
                    if (pvItem.ProvinceCode == sProvinceCode)
                    {
                        isFound = true;

                        pvs.Remove(pvItem);

                        using (SW = new StreamWriter(FILENAME, append: false))
                        {
                            foreach (HKProvince pvReWriteItem in pvs)
                            {
                                SW.WriteLine(pvReWriteItem);
                            }
                        }
                        break;
                    }
                }

                if(!isFound)
                    throw new Exception(string.Format("Cannot find " +
                        "province code [{0}]", sProvinceCode));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
         * Update a province from the file.
         *  - pv : Province class object
         */
        public void HKUpdate(HKProvince pv)
        {
            try
            {
                // Call HKEdit method to check can edit
                HKEdit(pv);

                if (IsEdit)
                {
                    HKDelete(pv.ProvinceCode);
                    using (SW = new StreamWriter(FILENAME, append: true))
                    {
                        SW.WriteLine(pv.ToString());
                    }

                    SW.Close();
                }
                 
                else
                {
                    throw new Exception(string.Format("province code [{0}] " +
                        "already on file.", pv.ProvinceCode));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
