using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoostVC
{
    class BitmapReader
    {
        private System.Drawing.Bitmap b;
        public BitmapReader(string address)
        {
            b = new System.Drawing.Bitmap(address);
        }

        public bool[,] monochrome()
        {
            bool[,] ret = new bool[b.Height, b.Width];
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    Color clr = b.GetPixel(x, y);
                    ret[y, x] = (clr.R + clr.G + clr.B) / 3 < 50;
                }
            }
            return ret;
        }
    }
}
