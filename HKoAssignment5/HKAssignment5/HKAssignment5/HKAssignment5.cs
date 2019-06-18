/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment5
 * Utility Classes
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HKAssignment5.HKUtilityClasses;

namespace HKAssignment5
{
    public partial class HKAssignment5 : Form
    {
        public HKAssignment5()
        {
            InitializeComponent();
        }

        private void txtValidFill_Click(object sender, EventArgs e)
        {
            btnReset_Click(this, e);
            txtFirstName.Text = "Jim";
            txtLastName.Text = "Carrey";
            txtPostalCode.Text = "n2j2w2";
            txtUSZip.Text = "123456789";
            txtPhoneNumber.Text = "1234567890";

            txtNumric.Text = "-123.456";
            txtInteger.Text = "123456";
            txtPunctuation.Text = "$12345,23 456-";
            txtExtract.Text = "2.34h3,435-612$%";
            txtCapital.Text = "108 university Ave";
        }

        private void txtInvalidFill_Click(object sender, EventArgs e)
        {
            btnReset_Click(this, e);
            txtFirstName.Text = "Jim,";
            txtLastName.Text = "-Carrey";
            txtPostalCode.Text = "a2d af8";
            txtUSZip.Text = "1234567890000";
            txtPhoneNumber.Text = "12345678";

            txtNumric.Text = "-123,456";
            txtInteger.Text = "123.456";
            txtPunctuation.Text = "$12345,23 456-";
            txtExtract.Text = "2.34h3,435-612$%";
            txtCapital.Text = "108 university Ave";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPostalCode.Text = "";
            txtUSZip.Text = "";
            txtPhoneNumber.Text = "";

            txtNumric.Text = "";
            txtInteger.Text = "";
            txtPunctuation.Text = "";
            txtExtract.Text = "";
            txtCapital.Text = "";

            lblErrFName.Text = "";
            lblErrLName.Text = "";
            txtFullName.Text = "";
            lblErrPostalCode.Text = "";
            lblErrUSZip.Text = "";
            lblErrPhoneNumber.Text = "";

            lblErrNumeric.Text = "";
            lblErrInteger.Text = "";
            lblErrExtract.Text = "";
            lblErrPunc.Text = "";
            lblErrCap.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = HKStringUtilities.NoPunctuationString(txtFirstName.Text);
            txtLastName.Text = HKStringUtilities.NoPunctuationString(txtLastName.Text);

            txtFullName.Text = HKStringUtilities.FullName(txtFirstName.Text, txtLastName.Text);

            if (HKNumericUtilities.IsInteger(txtInteger.Text))
            {
                lblErrInteger.Text = "";
            }
            else
            {
                lblErrInteger.Text = "Not allow ',/./-'";
                txtInteger.Focus();
            }

            if (HKNumericUtilities.IsNumeric(txtNumric.Text))
            {
                lblErrNumeric.Text = "";
            }
            else
            {
                lblErrNumeric.Text = "Invalid number(not allow ',').";
                txtNumric.Focus();
            }

            if (HKValidations.validatePhoneNumber(txtPhoneNumber.Text))
            {
                txtPhoneNumber.Text = HKStringUtilities.setPhoneMask(txtPhoneNumber.Text);
                lblErrPhoneNumber.Text = "";
            }
            else
            {
                lblErrPhoneNumber.Text = "Invalid Phone Number(10 digits).";
                txtPhoneNumber.Focus();
            }

            if (HKValidations.valideUSZipCode(txtUSZip.Text))
            {
                txtUSZip.Text = HKStringUtilities.setUSZipCodeFormat(txtUSZip.Text);
                lblErrUSZip.Text = "";
            }
            else
            {
                lblErrUSZip.Text = "Invalid zip code(len 5 or 9).";
                txtUSZip.Focus();
            }

            if (HKValidations.validatePostalCode(txtPostalCode.Text))
            {
                txtPostalCode.Text = HKStringUtilities.setPostalCode(txtPostalCode.Text);
                lblErrPostalCode.Text = "";
            }

            else
            {
                lblErrPostalCode.Text = "Invalid postal code.";
                txtPostalCode.Focus();
            }

            if(txtPunctuation.Text == "")
                lblErrPunc.Text = "";
            else
            {
                txtPunctuation.Text = HKNumericUtilities.NoPunctuationString(txtPunctuation.Text);
                lblErrPunc.Text = "No punctuation, changed the value.";
            }

            if (txtExtract.Text == "")
                lblErrExtract.Text = "";
            else
            {
                txtExtract.Text = HKStringUtilities.getOnlyDigitals(txtExtract.Text);
                lblErrExtract.Text = "Extracted only digital numbers.";
            }


            if (txtCapital.Text == "")
                lblErrCap.Text = "";
            else
            {
                txtCapital.Text = HKStringUtilities.setCapitalizedString(txtCapital.Text);
                lblErrCap.Text = "Changed that the first letter is capitalized letter.";
            }
        }

        private void txtOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            HKNumericUtilities.KeyPressEventHandler(e);
        }
    }
}
