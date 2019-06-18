namespace HKoAssignment3
{
    partial class HKoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.txtDelTransact = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelTransactNum = new System.Windows.Forms.Button();
            this.btnWriteRecord = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.GroupBox();
            this.rtbMsgDisplay = new System.Windows.Forms.RichTextBox();
            this.amount = new System.Windows.Forms.GroupBox();
            this.toolPurchased = new System.Windows.Forms.GroupBox();
            this.txtToolPurchased = new System.Windows.Forms.TextBox();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.qty = new System.Windows.Forms.GroupBox();
            this.price = new System.Windows.Forms.GroupBox();
            this.serialNumber = new System.Windows.Forms.GroupBox();
            this.date = new System.Windows.Forms.GroupBox();
            this.txtTransactNum = new System.Windows.Forms.TextBox();
            this.transactNumber = new System.Windows.Forms.GroupBox();
            this.btnCreateOpenFile = new System.Windows.Forms.Button();
            this.rbOpenExisting = new System.Windows.Forms.RadioButton();
            this.rbCreateNew = new System.Windows.Forms.RadioButton();
            this.file = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.enterFileName = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbDataDisplay = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTransactNum = new System.Windows.Forms.Label();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblToolPurchased = new System.Windows.Forms.Label();
            this.lblOpenedFile = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.message.SuspendLayout();
            this.amount.SuspendLayout();
            this.toolPurchased.SuspendLayout();
            this.qty.SuspendLayout();
            this.price.SuspendLayout();
            this.serialNumber.SuspendLayout();
            this.date.SuspendLayout();
            this.transactNumber.SuspendLayout();
            this.file.SuspendLayout();
            this.enterFileName.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFile.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnDeleteFile.Location = new System.Drawing.Point(272, 461);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(118, 23);
            this.btnDeleteFile.TabIndex = 34;
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnClose.Location = new System.Drawing.Point(148, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 23);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close File";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnDisplay.Location = new System.Drawing.Point(24, 461);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(118, 23);
            this.btnDisplay.TabIndex = 32;
            this.btnDisplay.Text = "Display Data";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtDelTransact
            // 
            this.txtDelTransact.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelTransact.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDelTransact.Location = new System.Drawing.Point(6, 21);
            this.txtDelTransact.Name = "txtDelTransact";
            this.txtDelTransact.Size = new System.Drawing.Size(95, 23);
            this.txtDelTransact.TabIndex = 0;
            this.txtDelTransact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDelTransact);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(331, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 53);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transact #";
            // 
            // btnDelTransactNum
            // 
            this.btnDelTransactNum.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelTransactNum.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnDelTransactNum.Location = new System.Drawing.Point(148, 181);
            this.btnDelTransactNum.Name = "btnDelTransactNum";
            this.btnDelTransactNum.Size = new System.Drawing.Size(177, 23);
            this.btnDelTransactNum.TabIndex = 29;
            this.btnDelTransactNum.Text = "Delete a record by transact #";
            this.btnDelTransactNum.UseVisualStyleBackColor = true;
            this.btnDelTransactNum.Click += new System.EventHandler(this.btnDelTransactNum_Click);
            // 
            // btnWriteRecord
            // 
            this.btnWriteRecord.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteRecord.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnWriteRecord.Location = new System.Drawing.Point(24, 181);
            this.btnWriteRecord.Name = "btnWriteRecord";
            this.btnWriteRecord.Size = new System.Drawing.Size(118, 23);
            this.btnWriteRecord.TabIndex = 28;
            this.btnWriteRecord.Text = "Write a Record";
            this.btnWriteRecord.UseVisualStyleBackColor = true;
            this.btnWriteRecord.Click += new System.EventHandler(this.btnWriteRecord_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrice.Location = new System.Drawing.Point(6, 22);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(83, 23);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtQty.Location = new System.Drawing.Point(6, 22);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(67, 23);
            this.txtQty.TabIndex = 0;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAmount.Location = new System.Drawing.Point(6, 22);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(95, 23);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // message
            // 
            this.message.Controls.Add(this.rtbMsgDisplay);
            this.message.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.MediumBlue;
            this.message.Location = new System.Drawing.Point(24, 500);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(804, 76);
            this.message.TabIndex = 35;
            this.message.TabStop = false;
            this.message.Text = "Message Display";
            // 
            // rtbMsgDisplay
            // 
            this.rtbMsgDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMsgDisplay.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMsgDisplay.ForeColor = System.Drawing.Color.Red;
            this.rtbMsgDisplay.Location = new System.Drawing.Point(7, 23);
            this.rtbMsgDisplay.Name = "rtbMsgDisplay";
            this.rtbMsgDisplay.Size = new System.Drawing.Size(791, 47);
            this.rtbMsgDisplay.TabIndex = 0;
            this.rtbMsgDisplay.Text = "";
            // 
            // amount
            // 
            this.amount.Controls.Add(this.txtAmount);
            this.amount.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.ForeColor = System.Drawing.Color.MediumBlue;
            this.amount.Location = new System.Drawing.Point(721, 93);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(107, 53);
            this.amount.TabIndex = 27;
            this.amount.TabStop = false;
            this.amount.Text = "Amount";
            // 
            // toolPurchased
            // 
            this.toolPurchased.Controls.Add(this.txtToolPurchased);
            this.toolPurchased.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolPurchased.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolPurchased.Location = new System.Drawing.Point(363, 93);
            this.toolPurchased.Name = "toolPurchased";
            this.toolPurchased.Size = new System.Drawing.Size(166, 53);
            this.toolPurchased.TabIndex = 24;
            this.toolPurchased.TabStop = false;
            this.toolPurchased.Text = "Tool Purchased";
            // 
            // txtToolPurchased
            // 
            this.txtToolPurchased.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToolPurchased.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtToolPurchased.Location = new System.Drawing.Point(6, 22);
            this.txtToolPurchased.MaxLength = 20;
            this.txtToolPurchased.Name = "txtToolPurchased";
            this.txtToolPurchased.Size = new System.Drawing.Size(154, 23);
            this.txtToolPurchased.TabIndex = 0;
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSerialNum.Location = new System.Drawing.Point(6, 22);
            this.txtSerialNum.MaxLength = 4;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(95, 23);
            this.txtSerialNum.TabIndex = 0;
            this.txtSerialNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // qty
            // 
            this.qty.Controls.Add(this.txtQty);
            this.qty.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qty.ForeColor = System.Drawing.Color.MediumBlue;
            this.qty.Location = new System.Drawing.Point(636, 93);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(79, 53);
            this.qty.TabIndex = 26;
            this.qty.TabStop = false;
            this.qty.Text = "Qty";
            // 
            // price
            // 
            this.price.Controls.Add(this.txtPrice);
            this.price.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.MediumBlue;
            this.price.Location = new System.Drawing.Point(535, 93);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(95, 53);
            this.price.TabIndex = 25;
            this.price.TabStop = false;
            this.price.Text = "Price";
            // 
            // serialNumber
            // 
            this.serialNumber.Controls.Add(this.txtSerialNum);
            this.serialNumber.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber.ForeColor = System.Drawing.Color.MediumBlue;
            this.serialNumber.Location = new System.Drawing.Point(250, 93);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(107, 53);
            this.serialNumber.TabIndex = 23;
            this.serialNumber.TabStop = false;
            this.serialNumber.Text = "Serial Number";
            // 
            // date
            // 
            this.date.Controls.Add(this.dtDate);
            this.date.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.MediumBlue;
            this.date.Location = new System.Drawing.Point(137, 93);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(107, 53);
            this.date.TabIndex = 22;
            this.date.TabStop = false;
            this.date.Text = "Date";
            // 
            // txtTransactNum
            // 
            this.txtTransactNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTransactNum.Location = new System.Drawing.Point(6, 22);
            this.txtTransactNum.Name = "txtTransactNum";
            this.txtTransactNum.Size = new System.Drawing.Size(95, 23);
            this.txtTransactNum.TabIndex = 0;
            this.txtTransactNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // transactNumber
            // 
            this.transactNumber.Controls.Add(this.txtTransactNum);
            this.transactNumber.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactNumber.ForeColor = System.Drawing.Color.MediumBlue;
            this.transactNumber.Location = new System.Drawing.Point(24, 93);
            this.transactNumber.Name = "transactNumber";
            this.transactNumber.Size = new System.Drawing.Size(107, 53);
            this.transactNumber.TabIndex = 21;
            this.transactNumber.TabStop = false;
            this.transactNumber.Text = "Transact #";
            // 
            // btnCreateOpenFile
            // 
            this.btnCreateOpenFile.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOpenFile.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCreateOpenFile.Location = new System.Drawing.Point(473, 28);
            this.btnCreateOpenFile.Name = "btnCreateOpenFile";
            this.btnCreateOpenFile.Size = new System.Drawing.Size(125, 40);
            this.btnCreateOpenFile.TabIndex = 20;
            this.btnCreateOpenFile.Text = "Create / Open File";
            this.btnCreateOpenFile.UseVisualStyleBackColor = true;
            this.btnCreateOpenFile.Click += new System.EventHandler(this.btnCreateOpenFile_Click);
            // 
            // rbOpenExisting
            // 
            this.rbOpenExisting.AutoSize = true;
            this.rbOpenExisting.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpenExisting.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbOpenExisting.Location = new System.Drawing.Point(110, 20);
            this.rbOpenExisting.Name = "rbOpenExisting";
            this.rbOpenExisting.Size = new System.Drawing.Size(102, 19);
            this.rbOpenExisting.TabIndex = 1;
            this.rbOpenExisting.TabStop = true;
            this.rbOpenExisting.Text = "Open Existing";
            this.rbOpenExisting.UseVisualStyleBackColor = true;
            // 
            // rbCreateNew
            // 
            this.rbCreateNew.AutoSize = true;
            this.rbCreateNew.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCreateNew.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbCreateNew.Location = new System.Drawing.Point(6, 20);
            this.rbCreateNew.Name = "rbCreateNew";
            this.rbCreateNew.Size = new System.Drawing.Size(91, 19);
            this.rbCreateNew.TabIndex = 0;
            this.rbCreateNew.TabStop = true;
            this.rbCreateNew.Text = "Create New";
            this.rbCreateNew.UseVisualStyleBackColor = true;
            // 
            // file
            // 
            this.file.Controls.Add(this.rbOpenExisting);
            this.file.Controls.Add(this.rbCreateNew);
            this.file.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file.ForeColor = System.Drawing.Color.MediumBlue;
            this.file.Location = new System.Drawing.Point(250, 21);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(217, 47);
            this.file.TabIndex = 19;
            this.file.TabStop = false;
            this.file.Text = "Flie";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFileName.Location = new System.Drawing.Point(6, 17);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(208, 23);
            this.txtFileName.TabIndex = 0;
            // 
            // enterFileName
            // 
            this.enterFileName.Controls.Add(this.txtFileName);
            this.enterFileName.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterFileName.ForeColor = System.Drawing.Color.MediumBlue;
            this.enterFileName.Location = new System.Drawing.Point(24, 21);
            this.enterFileName.Name = "enterFileName";
            this.enterFileName.Size = new System.Drawing.Size(220, 47);
            this.enterFileName.TabIndex = 18;
            this.enterFileName.TabStop = false;
            this.enterFileName.Text = "Enter File Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbDataDisplay);
            this.groupBox2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox2.Location = new System.Drawing.Point(24, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 206);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data display:";
            // 
            // rtbDataDisplay
            // 
            this.rtbDataDisplay.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDataDisplay.Location = new System.Drawing.Point(7, 20);
            this.rtbDataDisplay.Name = "rtbDataDisplay";
            this.rtbDataDisplay.Size = new System.Drawing.Size(790, 180);
            this.rtbDataDisplay.TabIndex = 0;
            this.rtbDataDisplay.Text = "";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDate.ForeColor = System.Drawing.Color.Red;
            this.lblDate.Location = new System.Drawing.Point(132, 149);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(122, 13);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "dd/mm/yyyy (1/3/2019)";
            this.lblDate.Visible = false;
            // 
            // lblTransactNum
            // 
            this.lblTransactNum.AutoSize = true;
            this.lblTransactNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactNum.ForeColor = System.Drawing.Color.Red;
            this.lblTransactNum.Location = new System.Drawing.Point(30, 149);
            this.lblTransactNum.Name = "lblTransactNum";
            this.lblTransactNum.Size = new System.Drawing.Size(95, 13);
            this.lblTransactNum.TabIndex = 39;
            this.lblTransactNum.Text = "Enter the number.";
            this.lblTransactNum.Visible = false;
            // 
            // lblSerialNum
            // 
            this.lblSerialNum.AutoSize = true;
            this.lblSerialNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNum.ForeColor = System.Drawing.Color.Red;
            this.lblSerialNum.Location = new System.Drawing.Point(258, 149);
            this.lblSerialNum.Name = "lblSerialNum";
            this.lblSerialNum.Size = new System.Drawing.Size(95, 13);
            this.lblSerialNum.TabIndex = 40;
            this.lblSerialNum.Text = "Enter the number.";
            this.lblSerialNum.Visible = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Red;
            this.lblPrice.Location = new System.Drawing.Point(538, 149);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(95, 13);
            this.lblPrice.TabIndex = 41;
            this.lblPrice.Text = "Enter the number.";
            this.lblPrice.Visible = false;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Red;
            this.lblQty.Location = new System.Drawing.Point(632, 149);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(95, 13);
            this.lblQty.TabIndex = 42;
            this.lblQty.Text = "Enter the number.";
            this.lblQty.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Location = new System.Drawing.Point(731, 149);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(95, 13);
            this.lblAmount.TabIndex = 43;
            this.lblAmount.Text = "Enter the number.";
            this.lblAmount.Visible = false;
            // 
            // lblToolPurchased
            // 
            this.lblToolPurchased.AutoSize = true;
            this.lblToolPurchased.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolPurchased.ForeColor = System.Drawing.Color.Red;
            this.lblToolPurchased.Location = new System.Drawing.Point(380, 149);
            this.lblToolPurchased.Name = "lblToolPurchased";
            this.lblToolPurchased.Size = new System.Drawing.Size(130, 13);
            this.lblToolPurchased.TabIndex = 44;
            this.lblToolPurchased.Text = "Enter the tool purchased.";
            this.lblToolPurchased.Visible = false;
            // 
            // lblOpenedFile
            // 
            this.lblOpenedFile.AutoSize = true;
            this.lblOpenedFile.Enabled = false;
            this.lblOpenedFile.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenedFile.ForeColor = System.Drawing.Color.Red;
            this.lblOpenedFile.Location = new System.Drawing.Point(645, 22);
            this.lblOpenedFile.Name = "lblOpenedFile";
            this.lblOpenedFile.Size = new System.Drawing.Size(0, 23);
            this.lblOpenedFile.TabIndex = 45;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(6, 22);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(95, 23);
            this.dtDate.TabIndex = 46;
            // 
            // HKoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 588);
            this.Controls.Add(this.lblOpenedFile);
            this.Controls.Add(this.lblToolPurchased);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblSerialNum);
            this.Controls.Add(this.lblTransactNum);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelTransactNum);
            this.Controls.Add(this.btnWriteRecord);
            this.Controls.Add(this.message);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.toolPurchased);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.price);
            this.Controls.Add(this.serialNumber);
            this.Controls.Add(this.date);
            this.Controls.Add(this.transactNumber);
            this.Controls.Add(this.btnCreateOpenFile);
            this.Controls.Add(this.file);
            this.Controls.Add(this.enterFileName);
            this.Name = "HKoForm";
            this.Text = "Abc Manufacturing Inc.";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.message.ResumeLayout(false);
            this.amount.ResumeLayout(false);
            this.amount.PerformLayout();
            this.toolPurchased.ResumeLayout(false);
            this.toolPurchased.PerformLayout();
            this.qty.ResumeLayout(false);
            this.qty.PerformLayout();
            this.price.ResumeLayout(false);
            this.price.PerformLayout();
            this.serialNumber.ResumeLayout(false);
            this.serialNumber.PerformLayout();
            this.date.ResumeLayout(false);
            this.transactNumber.ResumeLayout(false);
            this.transactNumber.PerformLayout();
            this.file.ResumeLayout(false);
            this.file.PerformLayout();
            this.enterFileName.ResumeLayout(false);
            this.enterFileName.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtDelTransact;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelTransactNum;
        private System.Windows.Forms.Button btnWriteRecord;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox message;
        private System.Windows.Forms.GroupBox amount;
        private System.Windows.Forms.GroupBox toolPurchased;
        private System.Windows.Forms.TextBox txtToolPurchased;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.GroupBox qty;
        private System.Windows.Forms.GroupBox price;
        private System.Windows.Forms.GroupBox serialNumber;
        private System.Windows.Forms.GroupBox date;
        private System.Windows.Forms.TextBox txtTransactNum;
        private System.Windows.Forms.GroupBox transactNumber;
        private System.Windows.Forms.Button btnCreateOpenFile;
        private System.Windows.Forms.RadioButton rbOpenExisting;
        private System.Windows.Forms.RadioButton rbCreateNew;
        private System.Windows.Forms.GroupBox file;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.GroupBox enterFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbDataDisplay;
        private System.Windows.Forms.RichTextBox rtbMsgDisplay;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTransactNum;
        private System.Windows.Forms.Label lblSerialNum;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblToolPurchased;
        private System.Windows.Forms.Label lblOpenedFile;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}

