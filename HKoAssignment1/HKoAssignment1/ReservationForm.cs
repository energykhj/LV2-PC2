/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment1
 * Airline Reservation System
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

namespace HKoAssignment1
{
    public partial class Form1 : Form
    {
        string[,] sArryReserved = new string[5, 3]; // store reserved seat
        string[] sArryWaitList = new string[10];    // store waiting info.
        int iRow = -1;       // current selected row index
        int iCol = -1;       // current selected col index
        int iBookCnt = 0;   // current count of booking
        int iWaitCnt = 0;   // current count of waiting
        
        public Form1()
        {
            InitializeComponent();
        }
        // Button event check status 
        // if status is avaiable, can process to the next step for reservation
        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (iRow < 0 || iCol < 0)
            {
                ShowOKMessage("Please select a seat.", "Information");
                return;
            }
            if (IsAvailableSeat())
            {
                if (txtName.Text != "")
                {
                    DialogResult msgResult = MessageBox.Show(
                    "The seat is available.\r\n" +
                    "Do you want to reservate?",
                    "Reservation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        ReserveSeat();
                    }
                }
            }
        }
        // Button event to reservate 
        // iBookCnt : count of booked so far.
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Reserved")
            {
                if (sArryReserved[iRow, iCol] != null)
                {
                    ShowOKMessage("The seat is not available.", "Error");
                    this.btnReset_Click(this, e);
                    return;
                }
            }
            if (txtName.Text == "")
            {
                ShowOKMessage("Please enter the passenger's name.", 
                    "Information");
                txtName.Focus();
            }
            else
            {
                if (iBookCnt < 15) // can book
                {
                    if (iRow < 0 || iCol < 0)
                    {
                        ShowOKMessage("Please select a seat.", "Information");
                        return;
                    }
                    else
                    {
                        ReserveSeat();
                    }
                }
                else // can add to waiting list
                {
                    DialogResult msgResult = MessageBox.Show(
                       "No seat is available.\r\n" +
                       "Do you want to add waiting list?",
                       "Reservation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        AddWaitList();
                    }
                }
            }
        }
        
        // Display reserved seat on the screen.
        private void SetSeat(string sMode = "normal")
        {
            int k = 0;
            for (int i = 0; i <= sArryReserved.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= sArryReserved.GetUpperBound(1); j++)
                {
                    k++;
                    if (sMode == "debug")
                    {
                        this.Controls.Find("button" + k, true).FirstOrDefault().Text = "TestName"+k;
                        this.Controls.Find("button" + k, true).FirstOrDefault().BackColor = Color.Red;
                        sArryReserved[i, j] = lbSeatRow.Items[i].ToString() + j + ", TestName" + k;
                        iBookCnt++;
                        rtbShowAll.Clear();

                    }
                    else
                    {
                        if (i == iRow && j == iCol)
                        {
                            this.Controls.Find("button" + k, true)
                                .FirstOrDefault().Text = txtName.Text;
                            // this.Controls["button" + k].Text = txtName.Text;
                        }
                    }
                }
            }     
        }
        // Add waiting list
        // Check that the currently selected seat is available.
        // References : ReserveSeat, btnStatus_Click.
        public bool IsAvailableSeat()
        {
            if (sArryReserved[iRow, iCol] == null)
            {
                txtStatus.Text = "Available";
                return true;
            }
            else
            {
                txtStatus.Text = "Not Available";
                return false;
            }
        }
        
        private void btnDebug_Click(object sender, EventArgs e)
        {
            iBookCnt = 0;
            SetSeat("debug");
        }
        // Add waiting list
        // Called when books are full and when add wait button is click
        // References : btnAddWaitingList_Click, btnBook_Click.
        private void AddWaitList()
        {
            lbSeatCol.ClearSelected();
            lbSeatRow.ClearSelected();

            if(iWaitCnt >= 10)
            {
                ShowOKMessage("Cannot add to waiting list.\r\n" +
                    "The waitlist is full.", "Error");
                return;
            }

            if (txtName.Text == "")
            {
                ShowOKMessage(
                    "Please enter the passenger's name.", "Error");
                txtName.Focus();
            }
            else
            {
                for(int i = 0; i < sArryWaitList.Length; i++)
                {
                    if(sArryWaitList[i] == null)
                    {
                        sArryWaitList[i] = txtName.Text;
                        break;
                    }
                }
                iWaitCnt++;
                if (String.IsNullOrEmpty(rtbWaitList.Text))
                    rtbWaitList.AppendText(iWaitCnt + ": " + txtName.Text);
                else  rtbWaitList.AppendText(
                    Environment.NewLine + iWaitCnt + ": " + txtName.Text);

                ShowOKMessage(txtName.Text +
                    " has been added to waiting list.", "Success");
                txtName.Text = "";
                txtName.Focus();
            }
        }
        // To reserve a seat
        // Called when status is available or when book button is click
        // References : btnStatus_Click, btnBook_Click.
        private void ReserveSeat()
        {
            if (IsAvailableSeat())
            {
                if (txtName.Text != "")
                {                    
                    sArryReserved[iRow, iCol] = 
                        lbSeatRow.Items[iRow].ToString() + 
                        iCol + ", " + txtName.Text;
                    iBookCnt++;
                        
                    ShowOKMessage(txtName.Text + ", " +
                        "seat [" + lbSeatRow.SelectedItem +
                        iCol + "] " +
                        "is reserved.", "Success");
                    
                    SetSeat();
                    this.btnReset_Click(this, null);
                }
            }
            else
            {
                ShowOKMessage("The seat is not available.", "Error");
            }
        }
        // Button event to show reserved list
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string sShowList = "";
            rtbShowAll.Clear();
            for (int i = 0; i <= sArryReserved.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= sArryReserved.GetUpperBound(1); j++)
                {
                    if(sArryReserved[i, j] != null)
                    {
                        string[] sSeat = sArryReserved[i, j]
                            .ToString().Split(',');
                        sShowList = sSeat[0] + ": " + sSeat[1];

                        if (String.IsNullOrEmpty(rtbShowAll.Text))
                            rtbShowAll.AppendText(sShowList);
                        else rtbShowAll.AppendText(Environment.NewLine + 
                            sShowList);

                        rtbShowAll.ScrollToCaret();
                    }
                }
            }
        }
        // Button event to Add waiting list 
        // iBookCnt : count of booked so far.
        private void btnAddWaitingList_Click(object sender, EventArgs e)
        {
            if (iBookCnt >= 15)   
            {
                if(txtStatus.Text != "")
                {
                    this.btnReset_Click(this, e);
                }
                AddWaitList();
            }
            else
            {                
                ShowOKMessage("Seats are available.\n\r" +
                    "Cannot add to waiting list.", "Error");
            }
        }
        // Cancels selected seat
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (iRow < 0 || iCol < 0)
            {
                ShowOKMessage("Please select a seat ", "Information");
                return;
            }

            if (sArryReserved[iRow, iCol] == null)
            {
                ShowOKMessage("Cannot be canceled\r\n" +
                    "Please check the seat number.", "Error");
            }
            else
            {
                DialogResult msgResult = MessageBox.Show(
                   "Do you want to cancel?",
                   "Cancelation",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    string[] sSeat = 
                        sArryReserved[iRow, iCol].ToString().Split(',');
                
                    ShowOKMessage(sSeat[1] + ", " + "seat [" + sSeat[0] + 
                        "] is cancelled.", "Success");

                    iBookCnt--;
                    sArryReserved[iRow, iCol] = null;
                    txtName.Text = "";
                    SetSeat();

                    if (sArryWaitList[0] != null)
                    {
                        sArryReserved[iRow, iCol] = 
                            lbSeatRow.Items[iRow].ToString() +
                            iCol + ", " + sArryWaitList[0];

                        iBookCnt++;
                        txtName.Text = sArryWaitList[0];
                        iWaitCnt--;
                        SetSeat();
                        txtName.Text = "";

                        ShowOKMessage(sArryWaitList[0] +
                                    ", is moved from waiting list to a recently " +
                                    "cancelled seat [" + lbSeatRow.Items[iRow].ToString() + 
                                    iCol+"]", "Information");

                        for (int i = 0; i < sArryWaitList.Length - 1; i++)
                        {
                            if (sArryWaitList[i] != null)
                            {
                                sArryWaitList[i] = sArryWaitList[i + 1];                                
                            }
                        }
                        sArryWaitList[sArryWaitList.Length - 1] = null;
                        rtbWaitList.Clear();
                    }
                    this.btnReset_Click(this, e);
                }
            }
        }
        // Display waiting list on the screen
        private void btnShowWaitingList_Click(object sender, EventArgs e)
        {
            rtbWaitList.Clear();
            if (sArryWaitList[0] == null)
            {
                ShowOKMessage("No waiting list", "Information");
                return;
            }
            for (int i = 1; i <= sArryWaitList.Length; i++)
            {
                if (sArryWaitList[i-1] == null) break;
                if (String.IsNullOrEmpty(rtbWaitList.Text))
                    rtbWaitList.AppendText(i + ": " + sArryWaitList[i-1]);
                else rtbWaitList.AppendText(Environment.NewLine + i + ": " + 
                    sArryWaitList[i-1]);

                rtbWaitList.ScrollToCaret();
            }
        }
        private void ShowOKMessage(string sMsg, string sHeader)
        {
            MessageBox.Show(sMsg,
                            sHeader, MessageBoxButtons.OK,
                            (sHeader == "Error")? MessageBoxIcon.Error :
                            MessageBoxIcon.Information);
        }
        // Save selected row-index of listbox
        private void lbSeatRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSeatRow.SelectedIndex != -1)
            {
                iRow = lbSeatRow.SelectedIndex;
                lblSeatNum.Text = lbSeatRow.SelectedItem.ToString();
                lbSeatCol.ClearSelected();
                txtStatus.Text = "";
                txtName.Text = "";
            }
        }
        // Save selected column-index of listbox 
        private void lbSeatCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSeatRow.SelectedIndex != -1
                && lbSeatCol.SelectedIndex != -1)
            {
                iCol = lbSeatCol.SelectedIndex;
                lblSeatNum.Text = "";
                txtName.Text = "";
                lblSeatNum.Text = lbSeatRow.SelectedItem.ToString();
                lblSeatNum.Text += lbSeatCol.SelectedIndex;

                if (sArryReserved[iRow, iCol] != null)
                {
                    string[] sSeat = sArryReserved[iRow, iCol].Split(',');
                    txtName.Text = sSeat[1];
                    txtStatus.Text = "Reserved";
                }
            }
        }      
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtStatus.Text = "";
            lblSeatNum.Text = "";
            iRow = -1;
            iCol = -1;
            txtName.Focus();
            rtbShowAll.Clear();
            lbSeatCol.ClearSelected();
            lbSeatRow.ClearSelected();
        }
    }
}
