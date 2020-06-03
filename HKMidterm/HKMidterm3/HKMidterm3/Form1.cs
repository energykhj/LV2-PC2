/*
 * Midterm
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452)
 * Question #3
 **/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKMidterm3
{   
    public partial class Form1 : Form
    {
        ArrayList arryStudent = new ArrayList();
        public Form1()
        {
            InitializeComponent();

            DrawHeader();
        }
        /*
        * Data Add when button click event is occured.
        */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (arryStudent.Count >= 5)
            {
                MessageBox.Show("The list is enough");
            }
            else
            {
                //Validate user entered text.
                if (ValidateMark() &&
                    ValidateName() &&
                    ValidateID())
                {

                    Students student = new Students();
                    student.ID = txtStudentID.Text;
                    student.LastName = txtLastName.Text;
                    student.Mark = Convert.ToDouble(txtMark.Text);

                    // add to student array.
                    arryStudent.Add(student);

                    // display on the listbox
                    DisplayData();

                    // clear textbox
                    TextClear();
                }
            }
        }
        /*
         * Duplication check.
         * Check whether entered ID is exist or not
         * */
        private bool CheckDuplicateID(string sID)
        {
            bool bVal = false;
            foreach (Students item in arryStudent)
            {
                if (item.ID == sID)
                    bVal = true; ;
            }
            return bVal;
        }

        // Display data in the list
        private void DisplayData()
        {
            lbList.Items.Clear();
            if (arryStudent.Count > 0)
            {
                DrawHeader();
            }
            foreach (Students item in arryStudent)
            {
                lbList.Items.Add(setFormat(item));
            }
        }

        // String formatting
        private string setFormat(Students sItem)
        {
            string fullString = $"{sItem.ID.ToString().PadRight(7, ' ')}" +
                  $"{sItem.LastName.ToString().PadRight(20, ' ')}" +
                  $"{string.Format("{0:F2}", sItem.Mark).PadLeft(5, ' ')}";
            return fullString;
        }

        private void TextClear()
        {
            txtLastName.Text = "";
            txtStudentID.Text = "";
            txtMark.Text = "";
        }

        private void DrawHeader()
        {
            string sHeader = $"{"ID".PadRight(7, ' ')}" +
                  $"{"Last Name".PadRight(20, ' ')}" +
                  $"{"Mark".PadLeft(5, ' ')}";

            lbList.Items.Add(sHeader);
            lbList.Items.Add($"{ "".PadRight(60, '-')}");
        }
        // Validate ID
        private bool ValidateID()
        {           
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                lblID.Text = "Enter the student ID";
                txtStudentID.Focus();
                return false;
            }

            if (txtStudentID.Text.Trim().Length != 5)
            {
                lblID.Text = "The length of ID is too short or long.(Max 5 digits)";
                return false;
            }

            try
            {
                if (!Int64.TryParse(txtStudentID.Text, out Int64 iID))
                {
                    lblID.Text = "The student ID should the numbers.";
                    txtStudentID.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblID.Text = "ID error.";
                txtStudentID.Focus();
                return false;
            }

            if (CheckDuplicateID(txtStudentID.Text))
            {
                lblID.Text = txtStudentID.Text + " is already exist. try other number.";
                txtStudentID.Focus();
                return false;
            }
            lblID.Text = "";
            return true;
        }
        // Validate student name
        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                lblName.Text = "Enter the name";
                txtLastName.Focus();
                return false;
            }
            lblName.Text = "";
            return true;

        }
        // Validate Mark
        private bool ValidateMark()
        {
            if (string.IsNullOrEmpty(txtMark.Text))
            {
                lblMark.Text = "Enter the Mark";
                txtMark.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (!double.TryParse(txtMark.Text, out double dMark))
                    {
                        lblMark.Text = "Only allow the numeric.";
                        txtMark.Focus();
                        return false;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtMark.Text) < 0 ||
                                Convert.ToDouble(txtMark.Text) > 100)
                        {
                            lblMark.Text = "Mark should be between 0 and 100.";
                            txtMark.Focus();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lblMark.Text = "Mark Error";
                    txtMark.Focus();
                    return false;
                }
            }
            lblMark.Text = "";
            return true;

        }
        // When mouse click event is occured.
        private void lbList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = lbList.SelectedIndex;
            lblName.Text = "";
            lblID.Text = "";
            lblMark.Text = "";
            txtSearchID.Text = "";
            showData(index - 2);
        }

        private void showData(int index)
        {
            Students st = (Students)arryStudent[index];

            txtStudentID.Text = st.ID.ToString();
            txtLastName.Text = st.LastName.ToString();
            txtMark.Text = st.Mark.ToString();
        }
        // When search button click event is occured.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchID.Text))
            {
                lblMsg.Text = "Enter the student ID you want to search.";
                txtSearchID.Focus();
            }
            int iCnt = -1;
            foreach(Students st in arryStudent)
            {
                iCnt++;
                if(st.ID == txtSearchID.Text.Trim())
                {
                    showData(iCnt);
                    lblMsg.Text = txtSearchID.Text + " was found.";
                    break;
                }
                else
                {
                    lblMsg.Text = txtSearchID.Text + " was not found. try to enter other ID.";
                    txtSearchID.Focus();
                }
            }
        }
        // When update button click event is occured.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = lbList.SelectedIndex - 2;
            Students st = (Students)arryStudent[index];
            string oldID = st.ID; ;
            string oldName = st.LastName;

            if (ValidateMark())
            {
                Students newST = (Students)arryStudent[index];
                newST.Mark = Convert.ToDouble(txtMark.Text);
                newST.LastName = oldName;
                newST.ID  = oldID;

                arryStudent.RemoveAt(index);
                arryStudent.Insert(index, st);

                lblMsg.Text = "The mark of " + oldID + " has been Updated.";
                DisplayData();
                TextClear();
            }
        }
    }
}
