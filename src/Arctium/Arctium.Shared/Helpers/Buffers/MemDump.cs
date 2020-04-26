﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Arctium.Shared.Helpers.Buffers
{
    public static unsafe class MemDump
    {
        /// <summary>
        /// Writes formatter byte array to the console output as a hexdump
        /// Useful in debugging
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="lineLength"></param>
        /// <param name="delimiterAfterNthByte"></param>
        /// <param name="delimiter"></param>
        /// <param name="format"></param>
        public static void HexDump(byte[] buffer, int lineLength = 16, int delimiterAfterNthByte = 4, string delimiter = " ", string format = "{0:X2}")
        {
            int linesCount = (buffer.Length / lineLength);
            int lastCount = buffer.Length % lineLength;

            string line = "";
            string allLines = "";
            int appendedBytes = 0;

            for (int i = 0; i < linesCount; i++)
            {
                for (int j = 0; j < lineLength; j++)
                {
                    line += string.Format(format, buffer[j + (i * lineLength)]);

                    appendedBytes++;
                    if (appendedBytes % delimiterAfterNthByte == 0)
                        line += delimiter;
                }

                allLines += line + "\r\n";
                line = "";
            }

            string lastLine = "";

            for (int i = 0; i < lastCount; i++)
            {
                lastLine += string.Format(format, buffer[i + (linesCount * lineLength)]);

                appendedBytes++;
                if (appendedBytes % delimiterAfterNthByte == 0)
                    line += delimiter;
            }

            allLines += lastLine;

            Console.WriteLine(allLines);

        }


        public static void HexDump(byte* p, int length, int groupLength = -1)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0:X2}", p[i]);

                if ((i + 1) % groupLength == 0) Console.Write(" ");
            }
        }


        public static void HexDump(uint* ptr, int length, int width = 4)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0:X8} ", ptr[i]);

                if ((i + 1) % width == 0) Console.WriteLine();
            }
        }

    }
}