using NAudio.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
     class VerticalLine : Figure
    {
 

        public VerticalLine(int yUP, int yDown, int x, char sym)
        {
            pLIST = new List<Point>();
            for (int y = yUP; y<= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pLIST.Add(p);
            }
            
        }
        
    }
}
