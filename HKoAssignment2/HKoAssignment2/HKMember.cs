/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment2
 * Member validation.
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
using System.Net.Mail;

namespace HKoAssignment2
{
    public partial class HKMemberForm : Form
    {
        int FIXED_ERROR = 0;
        HKoValidation hk = new HKoValidation();
        public HKMemberForm()
        {
            InitializeComponent();
        }
        // Button for loads the form with data.
        private void btnPreFill_Click(object sender, EventArgs e)
        {
            ResetErrorMessages();
            txtMemFName.Text = "  shaNia    ";
            txtMemLName.Text = "    tWain";
            txtSpouseFName.Text = "russell";
            txtSpouseLName.Text = "cRowe";
            txtStreetAddress.Text = "299    doon valley drive";
            txtCity.Text = "kitchener ontario";
            txtProvince.Text = "on";
            txtPostCode.Text = "n2g 4m4";
            txtPhone.Text = "1234567890";
            txtEmail.Text = "test@aaa";
            txtFee.Text = "111";
        }
        // Button for edits and reformats the fields.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FIXED_ERROR = 0;
            // check fee
            // 1. Allow numerics only
            // 2. Display the fee with two decimal places(rounded)
            if (!string.IsNullOrEmpty(txtFee.Text))
            {
                if (!hk.HkoIsNumeric(txtFee.Text))
                {
                    SetFocus("Fee");
                }
                else
                {
                    if (double.Parse(txtFee.Text) < 0)
                    {
                        SetFocus("Fee");
                    }
                    else
                    {
                        txtFee.Text = double.Parse(txtFee.Text.Trim()).
                            ToString("F"); // ("F"): express two decimal point 
                        errFee.Visible = false;
                    }
                }
            }

            // if email is provided
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!hk.IsValidEmail(txtEmail.Text))
                {
                    SetFocus("Email");
                }
                else
                {
                    txtEmail.Text = txtEmail.Text.ToLower();
                    errEmail.Visible = false;
                }

                // no need to check the postal information.
                // simply, replace the first letter to the capital letter. 
                txtStreetAddress.Text
                    = hk.HKoCapitalize(txtStreetAddress.Text);
                txtCity.Text = hk.HKoCapitalize(txtCity.Text);

                errStreetAddress.Visible = false;
                errCity.Visible = false;
                errPostCode.Visible = false;
            }
            // if an email is not provided,
            // it needs the postal information
            else
            {
                IsBlank("PostCode");
                IsBlank("City");
                IsBlank("StreetAddress");
                errEmail.Visible = false;
            }
            //  validate phone number
            if (!String.IsNullOrEmpty(txtPhone.Text))
            {
                if (!hk.HKoPhoneNumberValidation(txtPhone.Text))
                {
                    SetFocus("Phone");
                }
                else
                {
                    // make a phone number format with a dash
                    if (txtPhone.Text.Length == 10) {
                        txtPhone.Text = String.Format("{0:###-###-####}", 
                            Convert.ToInt64(txtPhone.Text));
                    }
                    errPhone.Visible = false;
                }
            }
            else errPhone.Visible = false;

            //  validate postal code      
            if (!string.IsNullOrEmpty(txtPostCode.Text))
            {
                txtPostCode.Text = txtPostCode.Text.Trim();
                if (!hk.HKoPostalCodeValidation(txtPostCode.Text))
                {
                    errPostCode.Visible = true;
                    errPostCode.Text = 
                        "Enter a valid Postal code (e.g.A2A 2A2).";
                    FIXED_ERROR++;
                    txtPostCode.Focus();
                }
                else
                {
                    // make a postal code with space in the middle.
                    // then convert to uppercase
                    txtPostCode.Text = (txtPostCode.Text.Length == 6) ?
                        txtPostCode.Text.Insert(3, " ").ToUpper() :
                        txtPostCode.Text.ToUpper();
                    errPostCode.Visible = false;
                }
            }
            // check province
            // Returns to uppercase.
            if (!string.IsNullOrEmpty(txtProvince.Text))
            {
                if (!hk.HKoProvinceValidation(txtProvince.Text))
                {
                    SetFocus("Province");
                }
                else
                {
                    txtProvince.Text = txtProvince.Text.Trim().ToUpper();
                    errProvince.Visible = false;
                }
            }
            else
            {
                errProvince.Visible = false;
            }
            lblFullName.Text = "";
            IsBlank("MemLName");
            IsBlank("MemFName");
            txtSpouseFName.Text = hk.HKoCapitalize(txtSpouseFName.Text);
            txtSpouseLName.Text = hk.HKoCapitalize(txtSpouseLName.Text);
                       
            if (FIXED_ERROR <= 0)
            {
                MakeFullName();
                MessageBox.Show("Validated!!");
            }
        }
        /*
         * Make Full name with member and spouse's name
         */
        private void MakeFullName()
        {
            // no spouse
            if (String.IsNullOrEmpty(txtSpouseFName.Text)
                && String.IsNullOrEmpty(txtSpouseLName.Text))
            {
                lblFullName.Text = txtMemLName.Text +
                    ", " + txtMemFName.Text;
            }
            // same the last name with Members and Spouse's
            // if spouse's last and first name is empty, 
            // not displayed the link signal like '&'
            else if (txtMemLName.Text.Equals(txtSpouseLName.Text))
            {
                lblFullName.Text = txtMemLName.Text +
                   ", " + txtMemFName.Text;
                lblFullName.Text +=
                    !string.IsNullOrEmpty(txtSpouseFName.Text) ? " && " : "";
                lblFullName.Text += txtSpouseFName.Text;
            }
            // different the last name with Members and Spouse's
            else if (!txtMemLName.Text.Equals(txtSpouseLName.Text))
            {
                lblFullName.Text = txtMemLName.Text + ", " + 
                    txtMemFName.Text + " && " + 
                    txtSpouseLName.Text + ", " +
                    txtSpouseFName.Text;
            }
        }
        // When an error occurs, set focus and show error messages
        private bool SetFocus(string sCtn)
        {
            Control ctnBtn = this.Controls["txt" + sCtn];
            Control ctnErr = this.Controls["err" + sCtn];

            ctnErr.Visible = true;
            FIXED_ERROR++;
            ctnBtn.Focus();
            return true;
        }
        // button for close
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Check the blank and make capitalize
        private bool IsBlank(string sCtn)
        {
            string sVal = "";
            try
            {
                Control ctnBtn = this.Controls["txt" + sCtn];
                Control ctnErr = this.Controls["err" + sCtn];
                sVal = ctnBtn.Text.Trim();
                if (string.IsNullOrEmpty(sVal))
                {
                    return SetFocus(sCtn);
                }
                else
                {
                    ctnErr.Visible = false;
                    ctnBtn.Text = hk.HKoCapitalize(sVal);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                return true;
            }
            return false;
        }
        // cleare error message for resubmission
        private void ResetErrorMessages()
        {
            errMemFName.Visible = false;
            errMemLName.Visible = false;
            errStreetAddress.Visible = false;
            errCity.Visible = false;
            errProvince.Visible = false;
            errPostCode.Visible = false;
            errPhone.Visible = false;
            errEmail.Visible = false;
            errFee.Visible = false;
        }
    }
}
