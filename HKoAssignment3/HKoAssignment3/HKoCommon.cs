/*
 * PROG1815-Programming Concept II
 * Prof. Harry Scanlan
 * Heuijin Ko(8187452) 
 * HKoAssignment3
 * Collecting the messages.
 */

 using System;
using System.Collections.Generic;
using System.Linq;

namespace HKoAssignment3
{
    class HKoCommon
    {        
        public object ShowMessage(int iKindOfMsg,
            string sHeader = "Error",
            string sMsg = "")
        {
            switch (iKindOfMsg)
            {
                case 1:
                    sMsg = "Enter the transaction number you want to delete.";
                    break;
                case 2:
                    sMsg = "File doesn't exists.";
                    break;
                case 3:
                    sMsg = "Enter the filename.";
                    break;
                case 4:
                    sMsg = "No files to display.";
                    break;
                case 5:
                    sMsg = "File was opened already.";
                    break;
                case 6:
                    sMsg = "Please select either create or open first.";
                    break;
                case 7:
                    sMsg = $"{sMsg} - A file with the same name has already been opened." +
                        "\nDo you want to ignore it and create a new one?";
                    break;
                case 8:
                    sMsg = "No data to display.\nYou can write a new record.";
                    break;
                case 9:
                    sMsg = $"Do you want to delete {sMsg} file?";
                    break;
                default:
                    break;
            }

            System.Windows.Forms.DialogResult msgResult;

            if (sHeader == "Question")
            {
                msgResult = System.Windows.Forms.MessageBox.Show(sMsg,
                  "Question",
                  System.Windows.Forms.MessageBoxButtons.YesNo,
                  System.Windows.Forms.MessageBoxIcon.Question); 
            }
            else
            {
                msgResult = System.Windows.Forms.MessageBox.Show(sMsg,
                   sHeader, System.Windows.Forms.MessageBoxButtons.OK,
                   (sHeader == "Error") ? System.Windows.Forms.MessageBoxIcon.Error :
                   System.Windows.Forms.MessageBoxIcon.Information);
            }
            
            return msgResult;
        }
    }
}
