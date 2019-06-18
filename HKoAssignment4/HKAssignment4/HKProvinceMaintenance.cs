/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment4
 * OOP: Encapsulatition
 */
using System;
using System.Windows.Forms;
using Assignment4.HKClasses;

namespace Assignment4
{
    public partial class HKProvinceMaintenance : Form
    {
        public HKProvinceMaintenance()
        {
            InitializeComponent();
            DisplayList();
        }

        // lists all province codes currently on file 
        private void DisplayList()
        {
            HKProvince pv = new HKProvince();
            lbProvince.Items.Clear();

            foreach (HKProvince pvItem in pv.HKGetProvinces())
            {
                lbProvince.Items.Add(pvItem.ProvinceCode);
            }
            btnDelete.Enabled = false;
        }
        // Selected recored is set to the textbox when index changes
        private void lbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbProvince.SelectedIndex != -1) {
                btnDelete.Enabled = true;
                txtProvinceCode.ReadOnly = true;

                HKProvince pv = new HKProvince();
                pv = pv.HKGetByProvinceCode(lbProvince.SelectedItem.ToString());

                txtProvinceCode.Text = pv.ProvinceCode;
                txtName.Text = pv.Name;
                txtCountryCode.Text = pv.CountryCode;
                txtTaxCode.Text = pv.TaxCode;
                txtTaxRate.Text = pv.TaxRate.ToString();
                cbFederalTax.Checked = pv.IncludesFederalTax;
                btnDelete.Enabled = true;
            }
        }
        /* 
         *  When click new record
         *   - all control clear
         *   - Delete button unenable : cannot delete
         */
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            lbProvince.SelectedIndex = -1;
            txtProvinceCode.Text = "";
            txtName.Text = "";
            txtCountryCode.Text = "";
            txtTaxCode.Text = "";
            txtTaxRate.Text = "";
            cbFederalTax.Checked = false;
            txtProvinceCode.ReadOnly = false;
            btnDelete.Enabled = false;
            txtProvinceCode.Focus();
        }

        /* 
         * When click save button
         *    - check from a new record or update         
         */
        private void btnSave_Click(object sender, EventArgs e)
        {
            HKProvince pv = new HKProvince();
            try
            {
                pv.ProvinceCode = txtProvinceCode.Text.ToUpper().Trim();
                pv.Name = txtName.Text.ToUpper().Trim();
                pv.CountryCode = txtCountryCode.Text.ToUpper().Trim();
                pv.TaxCode = txtTaxCode.Text.ToUpper().Trim();

                double dTaxRate;
                if (string.IsNullOrEmpty(txtTaxRate.Text))
                    dTaxRate = 0;
                else if (double.TryParse(txtTaxRate.Text, out dTaxRate))
                {
                    pv.TaxRate = dTaxRate;
                }

                pv.IncludesFederalTax = cbFederalTax.Checked ? true : false;

                // lbProvince.SelectedIndex
                //   - -1 : no selected item, can add, cannot edit
                //   - > -1  : have selected item , can edit
                if (lbProvince.SelectedIndex > -1)
                {
                    pv.HKUpdate(pv);
                    MessageBox.Show(string.Format("{0} [{1}] has been updated.", pv.Name, pv.ProvinceCode));
                }

                else
                {
                    pv.HKAdd(pv);
                    MessageBox.Show(string.Format("{0} [{1}] has been added.", pv.Name, pv.ProvinceCode));
                }

                DisplayList();

                lbProvince.SelectedItem = pv.ProvinceCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
        /* 
         * When click delete button
         *    - call HKDelete of HKProvince class.       
         */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            HKProvince pv = new HKProvince();
            try
            {
                string sCode = lbProvince.SelectedItem.ToString();

                pv.HKDelete(lbProvince.SelectedItem.ToString());

                DisplayList();
                lbProvince.SelectedIndex = -1;
                MessageBox.Show(string.Format("{0} has been deleted.", sCode));

                btnNewRecord_Click(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Window form close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
