using System;
using System.IO;
using System.Text;

namespace FlatFreak
{
    static class Program
    {
        static private string nl = Environment.NewLine;

        static public int RecordCount = 0;

        static private string CliFilename = string.Empty;
        static private string CliColumn = string.Empty;
        static private string CliLength = string.Empty;
        static private string CliName = string.Empty;
        static private bool CliMode = false;
        static private string CliText = string.Empty;
        static private string CliOut = string.Empty;
        static private string CliHelp = string.Empty;

        static internal FreakList Freaks { get; set; } = new FreakList { };

        static public int CheckPrint { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Cmd)
        {
            //CLI test parameters:
            // -fC:\Users\danrh\Documents\FlatTestFile.txt -c5 -l3 -nState3 -oC:\Users\danrh\Documents\FlatTestFileRpt.txt -h
            // or
            //  -fC:\Users\danrh\Documents\FlatTestFile.txt -c5 -l3 -nState3 -h
            if (Cmd.Length == 0)
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new FlatFreak());
            }
            else
            {
                int iLen;
                string Arg;
                string Argument;
                CliMode = false;
                if (Cmd[0].Length > 0 & Cmd.Length > 1)
                {
                    for (int i = 0; i < Cmd.Length; i++)
                    {
                        //If we have a command line, parse it
                        Argument = Cmd[i];

                        // FlatFreak.exe
                        if (Argument.ToLower().StartsWith("flatfreak"))
                        {
                            // Just here to suck up the argument if present
                        }

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
                }
                Reader(CliFilename, CliColumn, CliLength);
            }
            //System.Windows.Forms.Application.Exit();
            Console.Write("Press a key to exit...");
            System.ConsoleKeyInfo HoldHere = Console.ReadKey();
        }

        /// <summary>
        /// This procedure reads in a flat file and creates a frequency report
        /// on an indicated files (position and length)
        /// </summary>
        /// <param name="Filename">Flat file path and filename to be processed</param>
        /// <param name="Column">The column the field to process starts in (1 based)</param>
        /// <param name="Length">The length of the field to process</param>
        static public void Reader(string Filename, string Column, string Length)
        {
            string Message;
            TextReader Inp;
            string Line;
            string Chunk;
            int Col = 0;
            int Wid = 0;
            int AltWid;

            Wl("Processing input file...");
            
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
                    Wl(Message);

                }
                finally
                {
                    Wl("Sorting frequency list...");
                    Freaks.Sort();
                    Wl("Creating frequency report...");
                    FreakOut();
                }
            }
            else
            {
                Wl("Filename not supplied." + nl);
            }
        }

        /// <summary>
        /// Outputs the frequency report to a file for CLI or a Rich text box
        /// for GUI
        /// </summary>
        static private void FreakOut()
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
            string Message;

            Wl("Frequency report generation...");
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
            
            CliText += nl + oLine.ToString() + nl;

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
                CliText += oLine.ToString();
            }

            if (CliOut.Length > 0)
            {
                FileInfo OldFile = new FileInfo(CliOut);
                OldFile.Delete();

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
                    Wl(Message + nl);
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
            else
            {
                Wl(CliText + nl + CliHelp);
            }
        }

        /// <summary>
        /// Builds a CLI or GUI Header record
        /// </summary>
        static private void HeadFreak()
        {
            string Line;
            Line = "FlatFreak version: " +
                System.Windows.Forms.Application.ProductVersion +
                " on " + DateTime.Now.ToString() + nl +
                "Input file: " + CliFilename + nl +
                "Record count: " + RecordCount.ToString() + nl +
                "Frequency: " + CliColumn +
                " columns, " + CliLength + " length." + nl +
                "Label: " + CliName + nl +
                "Output: " + ((CliOut.Length == 0) ? "n/a" : CliOut) + nl +
                "Mode: CLI" + nl + nl;
                Wl("Header generated...");
                CliText += Line;
        }

        /// <summary>
        /// Helper method to simplify calling Console.WriteLine()
        /// </summary>
        /// <param name="Message">Text message to send to StdOut</param>
        static private void Wl(string Message)
        {
            Console.WriteLine(Message + nl);
        }

        static public string CliFilename1 { get => CliFilename; set => CliFilename = value; }
        static public string CliColumn1 { get => CliColumn; set => CliColumn = value; }
        static public string CliLength1 { get => CliLength; set => CliColumn = value; }
        static public string CliName1 { get => CliName; set => CliName = value; }
        static public bool CliMode1 { get => CliMode; set => CliMode = value; }
        static public string CliText1 { get => CliText; set => CliText = value; }
        static public string CliOut1 { get => CliOut; set => CliOut = value; }
        static public string CliHelp1 { get => CliHelp; set => CliHelp = value; }
    }
}
