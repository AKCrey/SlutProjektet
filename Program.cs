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

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    chessBoard[0, 1] = 1;

                    if (chessBoard[x, y] == 1)
                    {
                        Console.WriteLine("Bööö");
                    }

                    Console.Write(chessBoard[x, y]);
                }
                Console.WriteLine();

            }

            int location = chessBoard[0, 0];

            string input = Console.ReadLine();

            while (input != "w" && input != "a" && input != "s" && input != "d")
            {
                input = Console.ReadLine();
            }

            if (input == "w")
            {
                //Skulle behöva flytta mig i arrayen i bara ett led.
            }

            Console.ReadLine();

        }
    }
}
