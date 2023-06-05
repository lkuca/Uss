using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Sources;
using Uss;


namespace Snake
{
	class Program
	{

		

        static void Main( string[] args )
		{
			



            int speed = 100;
			int scor = 0;

			Console.SetWindowSize( 90, 25 );

			Walls walls = new Walls( 80, 25,scor );
			walls.Draw();
            List<Figure> wallList = new List<Figure> { };
            // Отрисовка точек			
            Point p = new Point( 4, 5, '*' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator( 80, 25, '$' );
			Point food = foodCreator.CreateFood();
			food.Draw();

			FoodCreator boostcreator = new FoodCreator(80, 25, 'b');
            Point boost = boostcreator.BoostCreater();
			boost.Draw();

			FoodCreator debufcreator = new FoodCreator(80, 25, 'a');
			Point debuf = debufcreator.DebufCreator();
			debuf.Draw();

            sound mäng = new sound();
			ConsoleKeyInfo nupp = new ConsoleKeyInfo();
			_ = mäng.Tagaplaanis_Mangida("../../../back.wav");
			//Console.WriteLine(score);




			while (true)
			{
                ReadText(scor);
                if ( walls.IsHit(snake) || snake.IsHitTail() )
				{
					break;
				}
				if(snake.Eat( food ) )
				{
					_ = mäng.Natuke_Mangida("../../../eat.wav");
					food = foodCreator.CreateFood();
					food.Draw();
					scor++;
                    if (scor >= 5)

                    {
                        wallList = new List<Figure>();
                        walls.Draw();

                        ConsoleColor consoleColor = ConsoleColor.Green;

                        Console.ForegroundColor = consoleColor;
                    }// Отрисовка рамочки
                    else
                        Console.ForegroundColor = ConsoleColor.White;


                    WriteText($"score: {scor}", 81, 8 ) ;

					
				}
				else if (snake.Eat2(boost) )
				{
                    _ = mäng.Natuke_Mangida("../../../eat.wav");
					boost = boostcreator.BoostCreater();
                    boost.Draw();
                    speed = 60;
					
                }
				else if (snake.Eat3(debuf))
				{
                    _ = mäng.Natuke_Mangida("../../../eat.wav");
					debuf = debufcreator.DebufCreator();
					debuf.Draw();
					speed = 200;
                }
				else
				{
					snake.Move();
				}

				Thread.Sleep( speed );
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}
			WriteGameOver(scor);
            WriteTxt(scor);
            Console.ReadLine();
      }


		static void WriteGameOver(int scor)
		{
			


			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			
			Console.SetCursorPosition( xOffset, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			WriteText( "mäng    lõppenud", xOffset + 1, yOffset++ );
			yOffset++;
			WriteText( "autor: Luca Gluhhov", xOffset + 2, yOffset++ );
			WriteText($"score: {scor}", xOffset + 1, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			sound over = new sound();
			_ = over.Natuke_Mangida("../../../over.wav");
		}

		static void WriteText( String text, int xOffset, int yOffset )
		{
			Console.SetCursorPosition( xOffset, yOffset );
			Console.WriteLine( text );
		}
        static void WriteTxt(int scor)
        {

            string path = "../../../bestscore.txt";


            using (StreamWriter writer = new StreamWriter(path, true))
            {
                int text = scor;


                writer.WriteLine(text);
            }
        }
        static void ReadText(int scor)
        {
            string path = "../../../bestscore.txt";
            int maxNumber = ReadMaxNumberFromFile(path);

            WriteText($"best score: {maxNumber}", 40, 25);

            if (scor <= maxNumber)
            {
                WriteText($"score: {scor}", 81, 8);
            }
            else if (scor > maxNumber)
            {
                WriteText($"score: {scor}", 81, 8);
                WriteText($"best score: {scor}", 80, 8);
            }
        }

        static int ReadMaxNumberFromFile(string filePath)
        {
            int maxNumber = int.MinValue;
            bool foundNumber = false;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        if (!foundNumber || number > maxNumber)
                        {
                            maxNumber = number;
                            foundNumber = true;
                        }
                    }
                }
            }

            if (foundNumber)
            {
                return maxNumber;
            }
            else
            {
                // Возвращаемое значение, если не найдено ни одного числа
                return 0; // Или int.MinValue, в зависимости от требований
            }
        }

    }
}
