using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProjektet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] chessBoard = new int[8, 8]; //kommatecknet avgör hur många dimensioner arrayen har.

            Console.WriteLine("Press 1 for the map");

            string input = Console.ReadLine();

            int mapKey = 0;

            bool success = int.TryParse(input, out mapKey);


            if (mapKey == 1) 
            {
                chessBoard = Map(chessBoard);
            }

            //int location = chessBoard[0, 0];

            /*while (input != "w" && input != "a" && input != "s" && input != "d")
            {
                input = Console.ReadLine();
            }

            if (input == "w")
            {
                
            }

            Console.ReadLine();*/

        }
        static int[,] Map (int[,] chessBoard)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                { 
                    Console.Write(chessBoard[x, y]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            return chessBoard;

        }
    }
}
