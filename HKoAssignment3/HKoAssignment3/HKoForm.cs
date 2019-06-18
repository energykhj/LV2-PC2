/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment3
 * File streamming
 * 
 * revise 
 * Date control change to the DateTimePicker[6 Mar 2019]
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
using System.IO;
using System.Collections;

namespace HKoAssignment3
{
    public partial class HKoForm : Form
    {
        // Stores from streamed data.
        ArrayList sArryRecord = new ArrayList();

        // Class for the error handling
        HKoCommon hk = new HKoCommon();

        // Number of data validation errors
        int ERROR_CNT = 0;                   

        public HKoForm()
        {
            InitializeComponent();
            txtFileName.Text = @"SampleData.txt";

            // cannot write a new record before open/created file.
            CanWirte(false);

            // Set default datetime format.
            dtDate.CustomFormat = "dd MMM yyyy";

        }
        
        private void btnCreateOpenFile_Click(object sender, EventArgs e)
        {
            if(string.Equals(txtFileName.Text, ""))
            {
                // 3: Enter the filename.
                hk.ShowMessage(3);
            }
            else
            {
                FileInfo file = new FileInfo(txtFileName.Text);

                // When checked file create
                if (rbCreateNew.Checked)
                {
                    CreateFile();
                    CanWirte(true);
                    txtTransactNum.Focus();
                }

                // When checked file open
                else if (rbOpenExisting.Checked)
                {
                    // If the file is already open, prevent re-open.
                    if (sArryRecord.Count > 0)
                    {
                        // 5: File was opened already.
                        hk.ShowMessage(5, "Information");
                    }
                    else
                    {
                        ReadFile(txtFileName.Text);
                    }
                    txtTransactNum.Focus();
                }
                else
                {
                    // 6: Please select either create or open first.
                    hk.ShowMessage(6);
                }
            }            
        }

        /*
         * Create file.
         * There are 2 options.
         * 1. If the file exists, ask ignore and create it.
         * 2. If the file does not exist, create a new file.
         * */
        private void CreateFile()
        {
            try
            {
                FileStream fs = null;
                if (File.Exists(txtFileName.Text))
                {
                    // 7: A file with the same name has already been opened." +
                    //    Do you want to ignore it and create a new one?;
                    if ((DialogResult)hk.ShowMessage(7, "Question", txtFileName.Text) == DialogResult.Yes)
                    {
                        // Choose Yes: Ignore exist file and create 
                        //             new with the same filename.
                        File.Delete(txtFileName.Text);
                        fs = File.Create(txtFileName.Text);
                        sArryRecord.Clear();
                        rtbDataDisplay.Clear();
                        FieldClear();
                        lblOpenedFile.Visible = true;
                        lblOpenedFile.Text = txtFileName.Text + "\nis open.";
                        rtbMsgDisplay.Text = "[" + txtFileName.Text + "] has been created.";
                        fs.Close();
                    }
                    else
                    {
                        // Choose No: Read exist file read 
                        ReadFile(txtFileName.Text);
                        rbOpenExisting.Checked = true;
                        DisplayData();
                    }
                }
                else
                {
                    fs = File.Create(txtFileName.Text);
                    sArryRecord.Clear();
                    FieldClear();
                    lblOpenedFile.Visible = true;
                    lblOpenedFile.Text = txtFileName.Text + "\nis open.";
                    rtbMsgDisplay.Text = "[" + txtFileName.Text + "] has been created.";
                    fs.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        // Read File
        private void ReadFile(string sFile)
        {
            try
            {
                if (File.Exists(sFile))
                {
                    int iCnt = 0;
                    using (StreamReader sr = File.OpenText(sFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            sArryRecord.Add(sr.ReadLine());
                            iCnt++;
                        }
                        sr.Close();
                    }                    

                    lblOpenedFile.Visible = true;
                    lblOpenedFile.Text = txtFileName.Text + "\nis open.";
                    rtbMsgDisplay.Text = "The file, [" + 
                        txtFileName.Text + "] has been opened.";
                    CanWirte(true);
                }
                else
                {
                    // 2: "File doesn't exists.
                    hk.ShowMessage(2);
                    txtFileName.Focus();
                }
            }
            catch (Exception ex)
            {
                hk.ShowMessage(0, "Error", ex.Message);
            }
        }
        // Writes a new record into the file.
        private void WriteFile(string sRecord = "")
        {
            
            try
            {
                if (sRecord.Trim() != "")
                {
                    // When the first record is added, make header first.
                    if (sArryRecord.Count == 0)
                    {
                        WriteHeader();
                        sArryRecord.Add(sRecord);
                        sArryRecord.Add($"{ "".PadRight(100, '-')}");
                    }

                    // The new record should be 'inserted' above the line 
                    // because of the last line bar.
                    else
                    {
                        sArryRecord.Insert(sArryRecord.Count - 1, sRecord);
                    }
                }
                // After a new record is created, it is written to the file. 
                using (StreamWriter sw = new StreamWriter(txtFileName.Text, append: false))
                {
                    foreach (string item in sArryRecord)
                        sw.WriteLine(item);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                hk.ShowMessage(0, "Error", ex.Message);
                sArryRecord.RemoveAt(sArryRecord.Count - 1);
            }

        }
        // Display Data.
        private void DisplayData(string sFrom = "Main")
        {
            if (sArryRecord == null ||
                sArryRecord.Count == 0)
            {
                // 4: No files to display. Open the file to display first.
                hk.ShowMessage(4);
                btnCreateOpenFile.Focus();
            }
            else
            {
                rtbDataDisplay.Clear();
                rtbDataDisplay.BackColor = Color.Cornsilk;
                foreach (string item in sArryRecord)
                {
                    rtbDataDisplay.AppendText(item + "\n");
                }

                rtbMsgDisplay.Clear();
                if (sFrom == "Del")
                {
                    rtbMsgDisplay.Text = "Item has been deleted.";
                }
                else if (sFrom == "Main")
                {
                    rtbMsgDisplay.Text = "Items has been displayed " + (sArryRecord.Count - 3);
                }
                else
                {
                    rtbMsgDisplay.Text = "Item has been Added.";
                }
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        // Make the Header and line bar.
        private void WriteHeader()
        {
            string sHeader = $"{"#".PadRight(2)}\t" +
                $"{"Purchase-Date".PadRight(13)}\t\t" +
                $"{"Serial #".PadRight(8)}\t" +
                $"{"Manufacturing Tools".PadRight(20)}\t\t" +
                $"{"Price".PadRight(6)}\t\t" +
                $"{"Qty".PadRight(3)}\t" +
                $"{"Amount".PadRight(6)}";
            
            sArryRecord.Insert(0, sHeader);
            sArryRecord.Insert(1, $"{ "".PadRight(100, '-')}");
        }

        // When click the delete by transaction number.
        private void btnDelTransactNum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDelTransact.Text))
            {
                // 1: Enter the transaction number you want to delete.
                hk.ShowMessage(1);
                txtDelTransact.Focus();
            }
            else
            {
                if (sArryRecord != null && sArryRecord.Count > 0)
                {
                    // Find the same number while looping the array.
                    int iCnt = 0;
                    foreach (string sLine in sArryRecord)
                    {
                        // The first two lines are the header, so, skipped.
                        iCnt++;
                        if (iCnt > 2)
                        {
                            if (!string.IsNullOrEmpty(sLine) &&
                                    sLine.Substring(0, 2).Trim() == 
                                    txtDelTransact.Text.Trim())
                            {
                                sArryRecord.Remove(sLine);
                                WriteFile();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // 4: No files to display. Open the file to display first.
                    hk.ShowMessage(4);
                    btnCreateOpenFile.Focus();
                }
                DisplayData("Del");
            }
        }
    
        // When click the write record.
        private void btnWriteRecord_Click(object sender, EventArgs e)
        {
            // Validate entered data.
            ERROR_CNT = 0;
            if (!IsNumberAndNotEmpty("Qty")) txtQty.Focus();
            if (!IsNumberAndNotEmpty("Price")) txtPrice.Focus();
            if (!IsNotEmpty("ToolPurchased")) txtToolPurchased.Focus();
            if (!IsNumberAndNotEmpty("SerialNum")) txtSerialNum.Focus();
            if (!ValidTransactNum()) txtTransactNum.Focus();

            if (ERROR_CNT == 0)
            {                           
                try
                {
                    // Make a new record
                    string sNewRecord = $"{txtTransactNum.Text.PadRight(2)}\t" +
                    $"{dtDate.Value.Date.ToString("dd MMM yyyy").PadRight(13)}\t\t" +
                    $"{txtSerialNum.Text.PadRight(8)}\t" +
                    $"{txtToolPurchased.Text.PadRight(20)}\t\t" +
                    $"{string.Format("{0:C2}", Convert.ToDouble(txtPrice.Text)).PadRight(6)}\t\t" +
                    $"{txtQty.Text.PadRight(3)}\t{txtAmount.Text.PadRight(6)}";

                    // Wirte into the file. 
                    WriteFile(sNewRecord);
                    DisplayData("Add");
                    FieldClear();
                    txtTransactNum.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        // Field clear to write a new record
        private void FieldClear()
        {
            txtTransactNum.Text = "";
            dtDate.Text = "";
            txtSerialNum.Text = "";
            txtToolPurchased.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
        }
        // Controls are toggled depending on whether 
        // write is enabled or not.
        private void CanWirte(bool bVal)
        {
            txtTransactNum.Enabled = bVal;
            dtDate.Enabled = bVal;
            txtSerialNum.Enabled = bVal;
            txtToolPurchased.Enabled = bVal;
            txtPrice.Enabled = bVal;
            txtQty.Enabled = bVal;
            txtAmount.Enabled = bVal;
            btnWriteRecord.Enabled = bVal;
            lblOpenedFile.Visible = bVal;
        }
        // Validate the entered transact number.
        // 1. Check empty or not.
        // 2. Check duplicate transact number.
        private bool ValidTransactNum()
        {
            int iCnt = 0;

            if (!IsNumberAndNotEmpty("TransactNum"))
            {
                lblTransactNum.Text = "Entered the number.";
                lblTransactNum.Visible = true;

                // The ERROR_CNT increases when an error occurs.
                ERROR_CNT++;
                return false;
            }
            else
            {
                // Duplicate check
                foreach (string sLine in sArryRecord)
                {
                    iCnt++;
                    if (iCnt > 2)
                    {
                        if (!string.IsNullOrEmpty(sLine) &&
                            sLine.Substring(0, 2).Trim() == txtTransactNum.Text)
                        {
                            lblTransactNum.Text = "Entered number\nis exist.";
                            lblTransactNum.Visible = true;
                            ERROR_CNT++;
                            return false;
                        }
                    }
                }

                lblTransactNum.Visible = false;
                return true;
            }
        }
              
        // Check entered data is number and not empty
        private bool IsNumberAndNotEmpty(string sCtn)
        {
            Control ctnBtn = this.Controls.Find("txt" + sCtn, true).FirstOrDefault();
            Control ctnErr = this.Controls.Find("lbl" + sCtn, true).FirstOrDefault();

            if (string.IsNullOrEmpty(ctnBtn.Text) ||
                !double.TryParse(ctnBtn.Text, out double iVal))
            {
                ctnErr.Visible = true;
                ERROR_CNT++;
                return false;
            }
            ctnErr.Visible = false;
            return true;
        }
        // Check the entered data is empty.
        private bool IsNotEmpty(string sCtn)
        {
            Control ctnBtn = this.Controls.Find("txt" + sCtn, true).FirstOrDefault();
            Control ctnErr = this.Controls.Find("lbl" + sCtn, true).FirstOrDefault();
            if (string.IsNullOrEmpty(ctnBtn.Text))
            {
                ctnErr.Visible = true;
                ERROR_CNT++;
                return false;
            }
            ctnErr.Visible = false;
            return true;
        }
        // Automatically calculate the amount  
        // by the price * qyt when lose focus from the price controls
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (IsNumberAndNotEmpty("Price") &&
                IsNumberAndNotEmpty("Qty"))
            {
                txtAmount.Text = string.Format("{0:C2}",
                    Convert.ToDouble(txtPrice.Text) * 
                    Convert.ToDouble(txtQty.Text));
            }
        }
        // Automatically calculate the amount  
        // by the price * qyt when lose focus from the price controls
        private void txtQty_Leave(object sender, EventArgs e)
        {
            if(IsNumberAndNotEmpty("Price") && 
                IsNumberAndNotEmpty("Qty"))
            {
                txtAmount.Text = string.Format("{0:C2}",
                    Convert.ToDouble(txtPrice.Text) *
                    Convert.ToDouble(txtQty.Text));
            }
        }
        // File close.
        private void btnClose_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(txtFileName.Text);
            if (File.Exists(txtFileName.Text))
            {
                sArryRecord.Clear();
                rtbDataDisplay.Clear();
                FieldClear();
                CanWirte(false);
                rtbMsgDisplay.Text = "[" + txtFileName.Text + "] has been closed.";
            }
            else
            {
                // 2: File doesn't exists.
                hk.ShowMessage(2);
            }
        }
        // File delete.
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {  
                //9: "Do you want to delete file?"
                if ((DialogResult)hk.ShowMessage(9, 
                    "Question", txtFileName.Text) == DialogResult.Yes)
                {
                    // Choose Yes: Ignore exist file and 
                    // create new with the same filename.
                    try
                    {
                        File.Delete(txtFileName.Text);
                        sArryRecord.Clear();
                        rtbDataDisplay.Clear();
                        rtbMsgDisplay.Text = "[" + txtFileName.Text + "] has been deleted.";
                        FieldClear();
                        txtFileName.Text = "";
                        CanWirte(false);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                }
            }
            else
            {
                // 2: File doesn't exists.
                hk.ShowMessage(2);
            }
        }
        // When the date gets focus, it notices the data format.
        protected void mTxtDate_GotFocus(object sender, EventArgs e)
        {
            lblDate.Visible = true;
        }
    }
}
