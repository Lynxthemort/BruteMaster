using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Globalization;
using System.Xml;
using System.Runtime.ConstrainedExecution;

namespace BruteMaster
{


    internal class Program
    {
        static void Main(string[] args)
        {
            string charactersCount;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n88\"\"Yb 88\"\"Yb 88   88 888888 888888 8b    d8    db    .dP\"Y8 888888 888888 88\"\"Yb \r\n88__dP 88__dP 88   88   88   88__   88b  d88   dPYb   `Ybo.\"   88   88__   88__dP \r\n88\"\"Yb 88\"Yb  Y8   8P   88   88\"\"   88YbdP88  dP__Yb  o.`Y8b   88   88\"\"   88\"Yb  \r\n88oodP 88  Yb `YbodP'   88   888888 88 YY 88 dP\"\"\"\"Yb 8bodP'   88   888888 88  Yb \r\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("The best program for everything related to brute force.\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select an option:");
            Console.WriteLine("Generate digital dictionary: 1\nDownload dictionary: 2\nDownload Hashcat: 3\nhashcat handshake converter: 4");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the number of characters");
                    charactersCount = Console.ReadLine();
                    string DId = "D" + charactersCount;
                    string maxLeanth = "9";
                    for (int i = 0; i < Convert.ToInt32(charactersCount) - 1; i++)
                    {
                        maxLeanth += "9";
                    }
                    int intMaxLeanth = Convert.ToInt32(maxLeanth) + 1;
                    Console.WriteLine("Enter the file name");
                    string filename = Console.ReadLine();
                    CreateNumberDict(filename, intMaxLeanth, DId);
                    OutputSuccess();
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Enter the name of the dictionary");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing yet, sorry");
                    string fileName = Console.ReadLine();
                    string remoteUri = "google.com";
                    string dest = fileName;
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(remoteUri + fileName, dest);
                    }
                    OutputSuccess();
                    break;
                    case "3":
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://hashcat.net/files/" + "hashcat-6.2.6.7z", "hashcat-6.2.6.7z");
                    }
                    OutputSuccess();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Don't forget to check the drivers for hashcat");
                    Console.ReadKey();
                    break;
                case "4":
                    System.Diagnostics.Process.Start("https://hashcat.net/cap2hashcat/");
                    break;
                default:
                    OutputError();
                    Console.ReadKey();
                    break;
            }
        }

        static void CreateNumberDict(string filename, int intMaxLeanth, string DId)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {

                for (int num = 0; num < intMaxLeanth; num++)
                {
                    string outputNum = num.ToString(DId);
                    file.WriteLine(outputNum);
                }
            }
        }

        static void OutputSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static void OutputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
