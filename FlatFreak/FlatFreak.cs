using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlatFreak
{
    /// <summary>
    /// This program is used to create a "frequency" report on a flat file
    /// column of variable width. This effectively aggregates the column as 
    /// a percentage.
    /// The program is unique(ish) as it works in CLI and GUI modes (it did
    /// so more cleanly in VB.NET, but whatever).
    /// </summary>
    public partial class FlatFreak : Form
    {
        /// <summary>
        /// This is a counter that records the number of flat file records
        /// that have been read by the stream reader to be processed
        /// </summary>
        public int RecordCount = 0;

        private string CliFilename = string.Empty;
        private string CliColumn = string.Empty;
        private string CliLength = string.Empty;
        private string CliName = string.Empty;
        private bool CliMode = false;
        private string CliText = string.Empty;
        private string CliOut = string.Empty;
        private string CliHelp = string.Empty;

        /// <summary>
        /// a newline character to keep from having to type Environmet.Newline
        /// all the time
        /// </summary>
        public string nl = Environment.NewLine;

        internal FreakList Freaks { get; set; } = new FreakList { };

        /// <summary>
        /// A global flag used to coordinate printing multiple pages
        /// </summary>
        public int CheckPrint { get; set; }

        /// <summary>
        /// Class constructor for the Windows form
        /// </summary>
        public FlatFreak()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Call code to test the FreakList and FreakCell classes (GUI mode only)
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            TestClass();
        }

        /// <summary>
        /// Opens a dialog to locate the input file
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void BtnFile_Click(object sender, EventArgs e)
        {
            SInfo("Get input file...");
            txtFilename.Clear();
            SInfo("Waiting for file dialog...");
            dlgOpen.ShowDialog();
            if (dlgOpen.FileName.Length > 0)
            {
                txtFilename.AppendText(dlgOpen.FileName);
            }
            btnFile.Enabled = false;
            tsbRun.Enabled = true;
            SInfo("Waiting...");
        }

        /// <summary>
        /// Starts the report once all of the parameters have been supplied on the
        /// GUI interface
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TsbRun_Click(object sender, EventArgs e)
        {
            SInfo("Running...");
            Reader(txtFilename.Text, Column.Value.ToString(), Length.Value.ToString());
            SInfo("Idle...");
        }

        /// <summary>
        /// Loads the print/document setup dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TsbPrintSetup_Click(object sender, EventArgs e)
        {
            prdSetup.ShowDialog();
        }

        /// <summary>
        /// Loads the print preview dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TsbPrintPreview_Click(object sender, EventArgs e)
        {
            prdPreview.ShowDialog();
        }

        /// <summary>
        /// Loads the print dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TsbPrint_Click(object sender, EventArgs e)
        {
            DialogResult ret = printDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                prdDocument.Print();
            }
        }

        /// <summary>
        /// Closes the current application
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TsbDone_Click(object sender, EventArgs e)
        {
            if (Freaks != null)
            {
                Freaks = null;
            }
            Application.Exit();
        }

        /// <summary>
        /// Indicates printing current document has started
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PrdDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) => CheckPrint = 0;

        /// <summary>
        /// Indicates printing the current page has started
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PrdDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            CheckPrint = RText1.Print(CheckPrint, RText1.TextLength, e);
            if (CheckPrint < RText1.TextLength)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        /// <summary>
        /// Windows form load even (manages CLI interface if present)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlatFreak_Load(object sender, EventArgs e)
        {
                DoE();
        }

        /// <summary>
        /// Used to test the FreakList and FreakCell classes                                   
        /// </summary>
        private void TestClass()
        {
            SInfo("Running class test...");
            Freaks.Add("Vogons");
            TxtApp("Added Vogons!" + nl);
            Freaks.Add("Progenitors");
            TxtApp("Added Progenitors!" + nl);
            Freaks.Add("Jovians");
            TxtApp("Added Jovians!" + nl);
            Freaks.Add("Progenitors");
            TxtApp("Added Progenitors!" + nl);
            Freaks.Add("Solarians");
            TxtApp("Added Solarians!" + nl);
            Freaks.Add("Progenitors");
            TxtApp("Added Progenitors!" + nl);
            Freaks.Add("Vogons");
            TxtApp("Added Vogons!" + nl);
            Freaks.Add("Jovians");
            TxtApp("Added Jovians!" + nl);
            Freaks.Add("Manticorans");
            TxtApp("Added Manticorans!" + nl + nl);

            TxtApp("Items added is " + Freaks.AddedItem.ToString() + nl);
            TxtApp("Items stored is " + Freaks.Items.ToString() + nl + nl);

            for (int i = 0; i < Freaks.Items; i++)
            {
                TxtApp("Item " + i.ToString() + " is " +
                    Freaks.GetCellItem(i) + " count is " +
                    Freaks.GetCellCount(i).ToString() + nl);
            }

            TxtApp(nl + "*sorting*" + nl + nl);
            Freaks.Sort();

            for (int i = 0; i < Freaks.Items; i++)
            {
                TxtApp("Item " + i.ToString() + " is " +
                    Freaks.GetCellItem(i) + " count is " +
                    Freaks.GetCellCount(i).ToString() + nl);
            }

            TxtApp(nl + "Test setup complete. Expect:" + nl +
                "22.22% 2 Jovians" + nl +
                "11.11% 1 Manticoran" + nl +
                "33.33% 3 Progenitors" + nl +
                "11.11% 1 Solarian" + nl +
                "22.22% 2 Vogons" + nl + nl +
                "Use test data as input to a report..." + nl + nl);

            CliColumn = "1";
            CliLength = "1";
            CliFilename = "(internal: test data)";
            RecordCount = Freaks.AddedItem;
            CliName = "Race";
            CliOut = "Internal";
            FreakOut();
            tsbPrintSetup.Enabled = true;
            tsbPrintPreview.Enabled = true;
            tsbPrint.Enabled = true;
            Button1.Enabled = false;
            SInfo("Idle...");
        }

        /// <summary>
        /// This procedure reads in a flat file and creates a frequency report
        /// on an indicated files (position and length)
        /// </summary>
        /// <param name="Filename">Flat file path and filename to be processed</param>
        /// <param name="Column">The column the field to process starts in (1 based)</param>
        /// <param name="Length">The length of the field to process</param>
        public void Reader(string Filename, string Column, string Length)
        {
            string Message;
            string Caption = "FlatFreak.Reader()";
            TextReader Inp;
            string Line;
            string Chunk;
            int Col = 0;
            int Wid = 0;
            int AltWid;

            SInfo("Processing input file...");
            RText1.Clear();

            Freaks = new FreakList { };

            if (Column.Length > 0) { Col = Convert.ToInt32(Column) - 1; }
            if (Length.Length > 0) { Wid = Convert.ToInt32(Length); }

            if (Filename.Length > 0 & Col >= 0 & Wid >= 0)
            {
                try
                {
                    Inp = new StreamReader(Filename);
                    do
                    {
                        Line = Inp.ReadLine();
                        if (Line != null)
                        {
                            if (Line.Length > 0)
                            {
                                RecordCount++;
                                if (Col + Wid - 1 > Line.Length)
                                {
                                    AltWid = Line.Length - Col;
                                    Chunk = Line.Substring(Col, AltWid);
                                }
                                else
                                {
                                    Chunk = Line.Substring(Col, Wid);
                                }
                                Freaks.Add(Chunk);
                            }
                        }
                    } while (Line != null);
                }
                catch (Exception Ex)
                {
                    Message = "Error while reading input stream: " + nl + nl +
                            Ex.Message + nl + nl + Ex.StackTrace + nl;
                    if (CliMode)
                    {
                        TxtApp(Message);
                    }
                    else
                    {
                        MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                finally
                {
                    SInfo("Sorting frequency list...");
                    Freaks.Sort();
                    SInfo("Creating frequency report...");
                    FreakOut();
                    tsbPrintSetup.Enabled = true;
                    tsbPrintPreview.Enabled = true;
                    tsbPrint.Enabled = true;
                    tsbRun.Enabled = false;
                    Button1.Enabled = false;
                }
            }
            else
            {
                tsbPrintSetup.Enabled = false;
                tsbPrintPreview.Enabled = false;
                tsbPrint.Enabled = false;
            }
        }

        /// <summary>
        /// Outputs the frequency report to a file for CLI or a Rich text box
        /// for GUI
        /// </summary>
        private void FreakOut()
        {
            int MaxItemLen;
            int TotalCount;
            int Count;
            int CumulativeCount = 0;
            double Percent;
            double CumulativePercent;
            int Index;
            string Item;
            StringBuilder oLine;

            SInfo("Frequency report generation...");
            MaxItemLen = Freaks.GetMaxItemLength();
            if (MaxItemLen < "Value".Length)
            {
                MaxItemLen = "Value".Length;
            }

            //Build the Header
            HeadFreak();
            oLine = new StringBuilder();
            oLine.Append("Value" + new String(' ', MaxItemLen - "Value".Length));
            oLine.Append(" ");
            oLine.Append(new String(' ', 10 - "Count".Length) + "Count");
            oLine.Append(" ");
            oLine.Append(new String(' ', 10 - "Percent".Length) + " Percent");
            oLine.Append(" ");
            oLine.Append("Cum. Count");
            oLine.Append(" ");
            oLine.Append(new String(' ', 10 - "Cum. %".Length) + "Cum. %");
            RText1.AppendText(nl + oLine.ToString() + nl);

            //Create the body of the report
            TotalCount = Freaks.AddedItem;
            for (Index = 0; Index < Freaks.Items; Index++)
            {
                Count = Freaks.GetCellCount(Index);
                CumulativeCount += Count;
                Item = Freaks.GetCellItem(Index);
                Percent = (Convert.ToDouble(Count) / Convert.ToDouble(TotalCount)) * 100.0;
                CumulativePercent = (Convert.ToDouble(CumulativeCount) / Convert.ToDouble(TotalCount)) * 100.0;

                oLine = new StringBuilder();
                oLine.Append(Item.PadRight(MaxItemLen));
                oLine.Append(" ");
                oLine.Append(Count.ToString().PadLeft(10));
                oLine.Append(" ");
                oLine.AppendFormat("{0,10:F2}", Percent);
                oLine.Append("% ");
                oLine.Append(CumulativeCount.ToString().PadLeft(10));
                oLine.Append(" ");
                oLine.AppendFormat("{0,9:F2}", CumulativePercent);
                oLine.Append("%" + nl);
                TxtApp(oLine.ToString());
            }
        }

        /// <summary>
        /// Builds a CLI or GUI Header record
        /// </summary>
        private void HeadFreak()
        {
            CliFilename = txtFilename.Text; 
            CliColumn = Column.Value.ToString(); 
            CliLength = Length.Value.ToString(); 
            CliName = txtFieldname.Text; 
            string Line = "FlatFreak version: " +
                Application.ProductVersion +
                " on " + DateTime.Now.ToString() + nl +
                "Input file: " + CliFilename + nl +
                "Record count: " + RecordCount.ToString() + nl +
                "Frequency: " + CliColumn +
                " columns, " + CliLength + " length." + nl +
                "Label: " + CliName + nl +
                "Output: " + ((CliOut.Length == 0) ? "n/a" : CliOut) + nl +
                "Mode: " + ((CliMode) ? "CLI" : "GUI") + nl + nl;
                TxtApp(Line);
                SInfo("Header generated...");
        }

        /// <summary>
        /// Appends a line of text to RichTextBox and does a do events
        /// </summary>
        /// <param name="msg"></param>
        public void TxtApp(string msg)
        {
            RText1.AppendText(msg);
            DoE();
        }

        /// <summary>
        /// Updates the text on the status bar and does a do events
        /// </summary>
        /// <param name="msg"></param>
        public void SInfo(string msg)
        {
            stxInfo1.Text = msg;
            DoE();
        }

        /// <summary>
        /// Runs a do events (updates UI)
        /// </summary>
        public void DoE()
        {
            Application.DoEvents();
        }

        public string CliFilename1 { get => CliFilename; set => CliFilename = value; }
        public string CliColumn1 { get => CliColumn; set => CliColumn = value; }
        public string CliLength1 { get => CliLength; set => CliColumn = value; }
        public string CliName1 { get => CliName; set => CliName = value; }
        public bool CliMode1 { get => CliMode; set => CliMode = value; }
        public string CliText1 { get => CliText; set => CliText = value; }
        public string CliOut1 { get => CliOut; set => CliOut = value; }
        public string CliHelp1 { get => CliHelp; set => CliHelp = value; }
    }
}