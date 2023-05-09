using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
     class HorizontalLine : Figure
    {
        

        public HorizontalLine(int xLeft, int xReight, int y, char sym)
        {
            pLIST = new List<Point>();
            for( int x = xLeft; x <= xReight; x++ )
            {
                Point p = new Point(x, y, sym);
                pLIST.Add(p);
            }

            //pLIST = new List<Point>();
            //Point p1 = new Point(4, 4, '*');
            //Point p2 = new Point(5, 4, '*');
            //Point p3 = new Point(6, 4, '*');
            //pLIST.Add(p1);
            //pLIST.Add(p2);
            //pLIST.Add(p3);
        }
          
        
    }
}
