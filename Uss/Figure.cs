using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
     class Figure
    {
        protected List<Point> pLIST;

        public void Drow()
        {
            foreach ( Point p in pLIST)
            {
                p.draw();
            }
        }
    }
}
