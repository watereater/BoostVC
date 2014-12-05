using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace BoostVC
{
    class Program
    {
        static void Main(string[] args)
        {
            example();
        }

        public static void example()
        {
            string address = "BitcoinLisa.png";
            BitmapReader br = new BitmapReader(address);
            bool[,] array = br.monochrome();
            setup();
            Console.WriteLine("ready");
            while (Console.ReadLine() != "s")
            { }
            System.Threading.Thread.Sleep(10000);
            print(array, array.GetLength(0) - 10, array.GetLength(1) - 20, 0, array.GetLength(1) - 20);
        }

        private static int dx, dy;

        private static void setup()
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            int w = (int)SystemParameters.PrimaryScreenWidth;
            int h = (int)SystemParameters.PrimaryScreenHeight;
            dx = Cursor.Position.X - x;
            dy = Cursor.Position.Y - y;
        }

        public static void print(bool[,] array, int iL, int jL, int si, int ei)
        {
            int x, y;
            x = y = 0;
            x = Cursor.Position.X + dx;
            y = Cursor.Position.Y + dy;
            
            int w = (int)SystemParameters.PrimaryScreenWidth;
            int h = (int)SystemParameters.PrimaryScreenHeight;
            bool iD = false;
            for (int i = si, j; i < iL && i < ei; i++)
            {
                for (j = 0; j < jL; j++)
                {

                    if (array[i, j])
                    {
                        if (!iD)
                        {
                            iD = true;
                            NativeMethods.SendMouseInput(x + j, y + i, w, h, true);
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        if (iD)
                        {
                            iD = false;
                            NativeMethods.SendMouseInput(x + j, y + i, w, h, false);
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                }
                iD = false;
                NativeMethods.SendMouseInput(x + j, y + i, w, h, false);
            }
        }
    }
}
