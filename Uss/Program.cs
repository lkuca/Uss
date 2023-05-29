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
			int scor = 0;
			Console.SetWindowSize( 90, 25 );

			Walls walls = new Walls( 80, 25 );
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point( 4, 5, '*' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator( 80, 25, '$' );
			Point food = foodCreator.CreateFood();
			food.Draw();

			sound mäng = new sound();
			ConsoleKeyInfo nupp = new ConsoleKeyInfo();
			_ = mäng.Tagaplaanis_Mangida("../../../back.wav");
			//Console.WriteLine(score);




			while (true)
			{
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
					WriteText($"score: {scor}", 82, 8 ) ;

					
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep( 100 );
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}
			WriteGameOver();
			Console.ReadLine();
      }


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition( xOffset, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			WriteText( "mäng    lõppenud", xOffset + 1, yOffset++ );
			yOffset++;
			WriteText( "autor: Luca Gluhhov", xOffset + 2, yOffset++ );
			WriteText( "", xOffset + 1, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			sound over = new sound();
			_ = over.Natuke_Mangida("../../../over.wav");
		}

		static void WriteText( String text, int xOffset, int yOffset )
		{
			Console.SetCursorPosition( xOffset, yOffset );
			Console.WriteLine( text );
		}
		
	}
}
