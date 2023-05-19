using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pLIST = new List<Point>();
            for(int i = 0; i< lenght; i++) 
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pLIST.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pLIST.First();
            pLIST.Remove(tail);
            Point head = GetNextPoint();
            pLIST.Add(head);

            tail.Clear();
            head.draw();
        }

        public Point GetNextPoint()
        {
            Point head = pLIST.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
    }
}
