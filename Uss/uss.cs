﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
     class uss
    {
        public static void Main(string[] args)
        {





            Console.SetWindowSize(80, 25);


            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftline = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightline = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftline.Drow();
            rightline.Drow();



            Point p = new Point(4, 5, '*');
            p.draw();










            //Point p1 = new Point(1, 3, '*');
            //Draw(p1.x, p1.y, p1.sym);

            //Point p2 = new Point(4, 5, '#');
            //Draw(p2.x, p2.y, p2.sym);


            //int x1 = 1;
            //int y1 = 3;
            //char sym1 = '*';

            //Draw(x1, y1, sym1);

            //List<int> numList = new List<int>();
            //numList.Add(0);
            //numList.Add(1);
            //numList.Add(2);


            //int x = numList[0];
            //int y = numList[1];
            //int z = numList[2];

            //foreach(int i in numList)
            //{
            //    Console.WriteLine(i);
            //}

            //numList.RemoveAt(0);

            //List<Point> pLIST = new List<Point>();
            //pLIST.Add(p1);
            //pLIST.Add(p2);

            //HorizontalLine line = new HorizontalLine(5, 10, 8, '+');
            //line.Drow();

            //Console.ReadLine();
        }

        //static void Draw(int x, int y, char sym)
        //{
        //    Console.SetCursorPosition(x, y);
        //    Console.Write(sym);
        //}
    }
}
