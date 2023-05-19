using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
     class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point()
        {

        }

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        public Point(Point p) 
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction) 
        {
            if(direction == Direction.RIGHT) 
            {
                x = x + offset;
            }
            else if(direction == Direction.LEFT) 
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y + offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y - offset;
            }
        }
        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }


        public void Clear()
        {
            sym = ' ';
            draw();
        }

        public override string ToString()
        {
            return x + " , "+ y + " + " + sym;
        }

        
    }
}
