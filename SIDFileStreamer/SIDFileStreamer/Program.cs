using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace SIDFileStreamer
{
    class Program
    {
        private static SerialPort serialPort = new SerialPort("COM3");


        static void Main(string[] args)
        {
            serialPort.BaudRate = 115200;
            serialPort.Open();

            // | Frame | Freq Note/Abs WF ADSR Pul | Freq Note/Abs WF ADSR Pul | Freq Note/Abs WF ADSR Pul | FCut RC Typ V |
            // |     0 | 0000  ... ..  00 4909 7FF | 0000  ... ..  00 4909 3E8 | 0000  ... ..  00 0900 BB8 | FF00 00 Hi  C |
            // 01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
            //           1         2         3         4         5         6         7         8         9         0  
            //                                                                                                     1
            //TextReader inputFile = new StreamReader(@"C:\Users\nicola\Downloads\felise.txt");
            TextReader inputFile = new StreamReader(@"C:\Users\nicola\Downloads\ab.txt");

            List<Tuple<byte, int>> registersMapping = new List<Tuple<byte, int>>();
            for (int voice = 0; voice < 3; voice++)
            {
                registersMapping.Add(new Tuple<byte, int>((byte)(0 + (7 * voice)), 12 + (28 * voice))); // Register zero corresponds to position 11 in the file.
                registersMapping.Add(new Tuple<byte, int>((byte)(1 + (7 * voice)), 10 + (28 * voice)));
                registersMapping.Add(new Tuple<byte, int>((byte)(2 + (7 * voice)), 33 + (28 * voice)));
                registersMapping.Add(new Tuple<byte, int>((byte)(3 + (7 * voice)), 31 + (28 * voice)));
                registersMapping.Add(new Tuple<byte, int>((byte)(5 + (7 * voice)), 27 + (28 * voice)));
                registersMapping.Add(new Tuple<byte, int>((byte)(6 + (7 * voice)), 29 + (28 * voice)));
                registersMapping.Add(new Tuple<byte, int>((byte)(4 + (7 * voice)), 24 + (28 * voice))); // This goes last so gate is processed after setting all parameters.
            }   

            bool headerFound = false;
            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            while (inputFile.Peek() >= 0)
            {
                String line = inputFile.ReadLine();
                if (line.StartsWith("+-------+"))
                {
                    headerFound = true;
                    continue;
                }

                if (!headerFound)
                {
                    continue;
                }

                int frame = int.Parse(line.Substring(1, 6));
                while ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime < frame * 16)
                {
                    Thread.Sleep(1);
                }

                foreach (Tuple<byte, int> mapEntry in registersMapping)
                {
                    byte? value = parseByte(line, mapEntry.Item2);
                    if (value != null)
                    {
                        if (value != 0xF7)
                        {
                            byte[] midiCommand = { 0xF0, 0x3B, 0x01, mapEntry.Item1, (byte)value, 0xF7 };
                            serialPort.Write(midiCommand, 0, 6);
                        }
                    }
                }
            }

        }

        static byte? parseByte(String line, int start)
        {
            if (line.Substring(start, 2).Contains("."))
            {
                return null;
            }

            return byte.Parse(line.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
        }
    }
}

