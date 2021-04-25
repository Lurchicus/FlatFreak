using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlatFreak
{
    /// <summary>
    /// This program is used to create a "frequency" report on a flat file
    /// column. This effectively aggregates the column as a percentage.
    /// </summary>
    public partial class FlatFreak : Form
    {
        /// <summary>
        /// This is a counter that records the number of flat file records
        /// that have been read by the stream reader to be processed
        /// </summary>
        public Int32 RecordCount = 0;

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
        private void btnFile_Click(object sender, EventArgs e)
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
        private void tsbRun_Click(object sender, EventArgs e)
        {
            SInfo("Running...");
            Reader(txtFilename.Text, Column.Value.ToString(), Length.Value.ToString(), CliMode);
            SInfo("Idle...");
        }

        /// <summary>
        /// Loads the print/document setup dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void tsbPrintSetup_Click(object sender, EventArgs e)
        {
            prdSetup.ShowDialog();
        }

        /// <summary>
        /// Loads the print preview dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void tsbPrintPreview_Click(object sender, EventArgs e)
        {
            prdPreview.ShowDialog();
        }

        /// <summary>
        /// Loads the print dialog
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void tsbPrint_Click(object sender, EventArgs e)
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
        private void tsbDone_Click(object sender, EventArgs e)
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
        private void prdDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CheckPrint = 0;
        }

        /// <summary>
        /// Indicates printing the current page has started
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void prdDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            //CLI test parameters:
            // -fC:\\Users\danrh\Documents\FlatTestFile.txt -c5 -l3 -nState3 -oC:\Users\danrh\Documents\FlatTestFileRpt.txt -h
            Int32 iLen = 0;
            string Arg = string.Empty;
            string Argument = string.Empty;
            string[] Cmd = Environment.GetCommandLineArgs();
            if (Cmd[0].Length > 0 & Cmd.Length > 1)
            {
                for (Int32 i = 1; i < Cmd.Length; i++)
                {
                    //If we have a command line, parse it
                    Arg = string.Empty;
                    Argument = Cmd[i];
                    iLen = 0;

                    // -fFullPath - "-f\\Server\Path\File.ext "
                    if (Argument.ToLower().StartsWith("-f"))
                    {
                        Arg = Argument.Trim();
                        iLen = Arg.Length;
                        if (iLen >= 3)
                        {
                            CliFilename = Arg.Substring(2, iLen - 2);
                        }
                    }

                    // -cColumn - "-c32 "
                    if (Argument.ToLower().StartsWith("-c"))
                    {
                        Arg = Argument.Trim();
                        iLen = Arg.Length;
                        if (iLen >= 3)
                        {
                            CliColumn = Arg.Substring(2, iLen - 2);
                        }
                    }

                    // -lLength - "-l12 "
                    if (Argument.ToLower().StartsWith("-l"))
                    {
                        Arg = Argument.Trim();
                        iLen = Arg.Length;
                        if (iLen >= 3)
                        {
                            CliLength = Arg.Substring(2, iLen - 2);
                        }
                    }

                    // -nName - "-nTelephoneNumber "
                    if (Argument.ToLower().StartsWith("-n"))
                    {
                        Arg = Argument.Trim();
                        iLen = Arg.Length;
                        if (iLen >= 3)
                        {
                            CliName = Arg.Substring(2, iLen - 2);
                        }
                    }

                    // -oOutPath - "-o\\Server\Path\File.ext "
                    if (Argument.ToLower().StartsWith("-o"))
                    {
                        Arg = Argument.Trim();
                        iLen = Arg.Length;
                        if (iLen >= 3)
                        {
                            CliOut = Arg.Substring(2, iLen - 2);
                        }
                    }

                    // -h - "-h "
                    if (Argument.ToLower().StartsWith("-h"))
                    {
                        CliHelp = "FlatFreak CLI mode commands:" + nl +
                            "-fFullPath - '-f\\\\Server\\Path\\File.ext '" + nl +
                            "-cColumn   - '-c32 '" + nl +
                            "-lLength   - '-l12 '" + nl +
                            "-nName     - '-nFieldName '" + nl +
                            "-oOutPath  - '-o\\\\Server\\Path\\File.ext '" + nl +
                            "-h         - (this help screen)";
                    }
                }
                if (CliFilename.Length > 0 & CliColumn.Length > 0 &
                    CliLength.Length > 0 & CliName.Length > 0 &
                    CliOut.Length > 0)
                {
                    CliMode = true;
                }
                else
                {
                    CliMode = false;
                }
            }
            else
            {
                CliMode = false;
            }
            if (CliMode)
            {
                Reader(CliFilename, CliColumn, CliLength, CliMode);
            }
            else
            {
                DoE();
            }
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

            for (Int32 i = 0; i < Freaks.Items; i++)
            {
                TxtApp("Item " + i.ToString() + " is " +
                    Freaks.GetCellItem(i) + " count is " +
                    Freaks.GetCellCount(i).ToString() + nl);
            }

            TxtApp(nl + "*sorting*" + nl + nl);
            Freaks.Sort();

            for (Int32 i = 0; i < Freaks.Items; i++)
            {
                TxtApp("Item " + i.ToString() + " is " +
                    Freaks.GetCellItem(i) + " count is " +
                    Freaks.GetCellCount(i).ToString() + nl);
            }

            TxtApp(nl + "Test complete. Expect:" + nl +
                "2 Jovians" + nl +
                "1 Manticoran" + nl +
                "3 Progenitors" + nl +
                "1 Solarian" + nl +
                "2 Vogons" + nl + nl +
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
        /// <param name="CLIMode">Boolean CLI mode flag</param>
        public void Reader(string Filename, string Column, string Length, bool CLIMode)
        {
            string Message = string.Empty;
            string Caption = "FlatFreak.Reader()";
            TextReader Inp;
            string Line = string.Empty;
            string Chunk = string.Empty;
            Int32 Col = 0;
            Int32 Wid = 0;
            Int32 AltWid = 0;

            if (!CliMode)
            {
                SInfo("Processing input file...");
                RText1.Clear();
            }
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
                    Inp = null;
                    if (!CliMode)
                    {
                        SInfo("Sorting frequency list...");
                    }
                    Freaks.Sort();
                    if (!CliMode)
                    {
                        SInfo("Creating frequency report...");
                    }
                    FreakOut();
                    if (CliMode)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        tsbPrintSetup.Enabled = true;
                        tsbPrintPreview.Enabled = true;
                        tsbPrint.Enabled = true;
                        tsbRun.Enabled = false;
                        Button1.Enabled = false;
                    }
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
            Int32 MaxItemLen = 0;
            Int32 TotalCount = 0;
            Int32 Count = 0;
            Int32 CumulativeCount = 0;
            double Percent = 0.0;
            double CumulativePercent = 0.0;
            Int32 Index = 0;
            string Item = string.Empty;
            Int32 LineLen = 0;
            StringBuilder oLine;
            string Message = string.Empty;
            string Caption = "FlatFreak.FreakOut()";

            if (!CliMode)
            {
                SInfo("Frequency report generation...");
            }
            MaxItemLen = Freaks.GetMaxItemLength();
            if (MaxItemLen < "Value".Length)
            {
                MaxItemLen = "Value".Length;
            }

            //Build the Header
            try
            {
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
                LineLen = oLine.Length - 3;
                if (!CliMode)
                {
                    RText1.AppendText(nl + oLine.ToString() + nl);
                }
                else
                {
                    CliText += nl + oLine.ToString() + nl;
                }
            }
            catch { }
            finally
            {
                oLine = null;
            }

            //Create the body of the report
            TotalCount = Freaks.AddedItem;
            for (Index = 0; Index < Freaks.Items; Index++)
            {
                try
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
                    if (!CliMode)
                    {
                        TxtApp(oLine.ToString());
                    }
                    else
                    {
                        CliText += oLine.ToString();
                    }
                }
                catch { }
                finally
                {
                    oLine = null;
                }
            }
            if (!CliMode)
            {
                SInfo("Frequency report done...");
            }
            else
            {
                try
                {
                    FileInfo OldFile = new FileInfo(CliOut);
                    OldFile.Delete();
                    OldFile = null;
                }
                catch { }

                TextWriter Out = new StreamWriter(CliOut, true);
                try
                {
                    Out.Write(CliText + nl + CliHelp);
                    Out.Flush();
                    Out.Close();
                }
                catch (Exception Ex)
                {
                    Message = "Error in StreamWrite writing report to file" + nl +
                        Ex.Message + nl + Ex.StackTrace;
                    MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (Out != null)
                    {
                        Out.Dispose();
                    }
                    CliText = string.Empty;
                    CliHelp = string.Empty;
                }
            }
        }

        /// <summary>
        /// Builds a CLI or GUI Header record
        /// </summary>
        private void HeadFreak()
        {
            string Line;
            Line = "FlatFreak version: " +
                Application.ProductVersion +
                " on " + DateTime.Now.ToString() + nl +
                "Input file: " + CliFilename + nl +
                "Record count: " + RecordCount.ToString() + nl +
                "Frequency: " + CliColumn +
                " columns, " + CliLength + " length." + nl +
                "Label: " + CliName + nl +
                "Output: " + (CliOut ?? "n/a") + nl +
                "Mode: CLI" + nl + nl;
            if (!CliMode)
            {
                TxtApp(Line);
                SInfo("Header generated...");
            }
            else
            {
                CliText += Line;
            }
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
    }
}