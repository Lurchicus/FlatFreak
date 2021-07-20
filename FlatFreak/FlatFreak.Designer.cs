namespace FlatFreak
{
    partial class FlatFreak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlatFreak));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintSetup = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDone = new System.Windows.Forms.ToolStripButton();
            this.Button1 = new System.Windows.Forms.ToolStripButton();
            this.RText1 = new RichTextBoxAndPrint.RichTextPrint();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stxInfo1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.prdDocument = new System.Drawing.Printing.PrintDocument();
            this.prdPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.prdSetup = new System.Windows.Forms.PageSetupDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFieldname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Length = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Column = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Column)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRun,
            this.toolStripSeparator1,
            this.tsbPrintSetup,
            this.tsbPrintPreview,
            this.tsbPrint,
            this.toolStripSeparator2,
            this.tsbDone,
            this.Button1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(616, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRun
            // 
            this.tsbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRun.Enabled = false;
            this.tsbRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbRun.Image")));
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(23, 22);
            this.tsbRun.Text = "tsbRun";
            this.tsbRun.ToolTipText = "Run";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrintSetup
            // 
            this.tsbPrintSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintSetup.Enabled = false;
            this.tsbPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintSetup.Image")));
            this.tsbPrintSetup.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tsbPrintSetup.Name = "tsbPrintSetup";
            this.tsbPrintSetup.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintSetup.Text = "Print setup";
            this.tsbPrintSetup.Click += new System.EventHandler(this.tsbPrintSetup_Click);
            // 
            // tsbPrintPreview
            // 
            this.tsbPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintPreview.Enabled = false;
            this.tsbPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintPreview.Image")));
            this.tsbPrintPreview.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tsbPrintPreview.Name = "tsbPrintPreview";
            this.tsbPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintPreview.Text = "Print preview";
            this.tsbPrintPreview.Click += new System.EventHandler(this.tsbPrintPreview_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDone
            // 
            this.tsbDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDone.Image = ((System.Drawing.Image)(resources.GetObject("tsbDone.Image")));
            this.tsbDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDone.Name = "tsbDone";
            this.tsbDone.Size = new System.Drawing.Size(23, 22);
            this.tsbDone.Text = "Done";
            this.tsbDone.Click += new System.EventHandler(this.tsbDone_Click);
            // 
            // Button1
            // 
            this.Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button1.Image = ((System.Drawing.Image)(resources.GetObject("Button1.Image")));
            this.Button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(23, 22);
            this.Button1.Text = "toolStripButton1";
            this.Button1.ToolTipText = "Internal classes test";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RText1
            // 
            this.RText1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RText1.DetectUrls = false;
            this.RText1.EnableAutoDragDrop = true;
            this.RText1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RText1.Location = new System.Drawing.Point(6, 19);
            this.RText1.Name = "RText1";
            this.RText1.Size = new System.Drawing.Size(579, 239);
            this.RText1.TabIndex = 1;
            this.RText1.Text = "";
            this.RText1.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stxInfo1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stxInfo1
            // 
            this.stxInfo1.Name = "stxInfo1";
            this.stxInfo1.Size = new System.Drawing.Size(35, 17);
            this.stxInfo1.Text = "Idle...";
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.prdDocument;
            this.printDialog1.PrintToFile = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // prdDocument
            // 
            this.prdDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prdDocument_BeginPrint);
            this.prdDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdDocument_PrintPage);
            // 
            // prdPreview
            // 
            this.prdPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prdPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prdPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.prdPreview.Document = this.prdDocument;
            this.prdPreview.Enabled = true;
            this.prdPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("prdPreview.Icon")));
            this.prdPreview.Name = "prdPreview";
            this.prdPreview.Visible = false;
            // 
            // prdSetup
            // 
            this.prdSetup.Document = this.prdDocument;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input file";
            // 
            // btnFile
            // 
            this.btnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.Location = new System.Drawing.Point(556, 14);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(28, 28);
            this.btnFile.TabIndex = 2;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(39, 19);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(511, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtFieldname);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Length);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Column);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // txtFieldname
            // 
            this.txtFieldname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFieldname.Location = new System.Drawing.Point(346, 19);
            this.txtFieldname.Name = "txtFieldname";
            this.txtFieldname.Size = new System.Drawing.Size(238, 20);
            this.txtFieldname.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Field name:";
            // 
            // Length
            // 
            this.Length.Location = new System.Drawing.Point(193, 20);
            this.Length.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.Length.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(80, 20);
            this.Length.TabIndex = 3;
            this.Length.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length:";
            // 
            // Column
            // 
            this.Column.Location = new System.Drawing.Point(58, 20);
            this.Column.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.Column.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(80, 20);
            this.Column.TabIndex = 1;
            this.Column.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Column:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.RText1);
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 264);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report";
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "txt";
            this.dlgOpen.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.dlgOpen.FilterIndex = 2;
            // 
            // FlatFreak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 429);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FlatFreak";
            this.Text = "Flat Freak";
            this.Load += new System.EventHandler(this.FlatFreak_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Column)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrintSetup;
        private System.Windows.Forms.ToolStripButton tsbPrintPreview;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDone;
        private RichTextBoxAndPrint.RichTextPrint RText1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument prdDocument;
        private System.Windows.Forms.PrintPreviewDialog prdPreview;
        private System.Windows.Forms.PageSetupDialog prdSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFieldname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Length;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Column;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripButton Button1;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripStatusLabel stxInfo1;
    }
}

