/*
 * Midterm
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452)
 * Question #1 and Questionn #2
 **/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKMidterm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Question #1 - Validate phone number.
         * When chenged text event is occured.
         */
        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                string sPattern = @"^\((\d{3})\)( )(\d{3})\-(\d{4})$";
                
                Regex rx = new Regex(sPattern, RegexOptions.IgnoreCase);

                if (rx.IsMatch(txtPhoneNumber.Text))
                {
                    lblText4Q1.ForeColor = Color.Blue;
                    lblText4Q1.Text = "Valide phone number you enterd.";
                }
                else
                {
                    lblText4Q1.ForeColor = Color.Red;
                    lblText4Q1.Text = "InValide phone number you enterd.";
                }

            }
        }
        /*
        * Question #2 - Validate palindrome number. 
        */
        private void btnCheck_Click(object sender, EventArgs e)
        {
            bool isError = false;
            try
            {
                if (string.IsNullOrEmpty(txtNumber.Text))
                {
                    lblText4Q2.ForeColor = Color.Red;
                    lblText4Q2.Text = "Enter the number.";
                    isError = true;
                }

                if (!Int64.TryParse(txtNumber.Text, out long lNumber))
                {
                    lblText4Q2.ForeColor = Color.Red;
                    lblText4Q2.Text = "Enter only numeric, try again.";
                    isError = true;
                }

                if (lNumber < 99 || lNumber > 999999999)
                {
                    lblText4Q2.ForeColor = Color.Red;
                    lblText4Q2.Text = "Number should greater than 2 digits and less than 10 digits.";
                    isError = true;
                }

                if (!isError)
                {
                    char[] cVal = txtNumber.Text.ToCharArray();

                    int iLen = txtNumber.Text.Length - 1;
                    int iHalfPos = iLen / 2;
                    for (int i = 0; i < iHalfPos; i++)
                    {
                        if (cVal[i] != cVal[iLen - i])
                        {
                            lblText4Q2.ForeColor = Color.Red;
                            lblText4Q2.Text = "The number is a not palindrome number.";
                            throw new Exception("The number is a not palindrome number.");
                        }
                    }

                    lblText4Q2.ForeColor = Color.Blue;
                    lblText4Q2.Text = "The number is a palindrome number";
                }

            }
            catch (Exception ex)
            {
                lblText4Q2.ForeColor = Color.Red;
                lblText4Q2.Text = ex.Message;
            }
        }
    }
}
