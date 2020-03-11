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

            //Jag har lagt till en slumpgenerator på siffrorna. En idee är att beroende på vilken siffra det är så kommer rummet att vara annorlunda. Jag göra därför massa if-satser så att varje rum man går in i har en chans att bli annorlunda. 

            Random generator = new Random();

            int[,] chessBoard = new int[8, 8]; //kommatecknet avgör hur många dimensioner arrayen har.

            chessBoard = MapKey(chessBoard);

            int location = chessBoard[0, 0];

            while (location != 3)
            {
                if (location == 0)
                {
                    Console.WriteLine("DUNGEON MASTER");
                }
                else if (location == 1)
                {
                    Console.WriteLine("WÄ");
                }
                else if (location == 2)
                {
                    Console.WriteLine("2");
                }
                Console.ReadLine();
                Console.Clear();
            }

            string movement = "";

            movement = Movement(movement);

            Console.ReadLine();

        }
        static int[,] MapKey (int[,] chessBoard) //Metoden för klicka på 1 för att anropa Map metoden
        {
            Console.WriteLine("Press 1 for the map");

            string input = Console.ReadLine();

            int mapKey = 0;

            bool success = int.TryParse(input, out mapKey);

            if (mapKey == 1)
            {
                chessBoard = Map(chessBoard);
            }

            return chessBoard;
        }
        static int[,] Map (int[,] chessBoard) //Visar kartan.
        {
            Random generator = new Random();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    chessBoard[x, y] = generator.Next(3);
                    Console.Write(chessBoard[x, y]);                   
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            return chessBoard;

        }
        static string Movement (string movement)
        {
            Console.WriteLine("Press W for Up");
            Console.WriteLine("Press A for Left");
            Console.WriteLine("Press S for Down");
            Console.WriteLine("Press D for Right");

            string input = Console.ReadLine().ToLower().Trim();

            while (input != "w" && input != "a" && input != "s" && input != "d")
            {
                input = Console.ReadLine();
            }

            if (input == "w")
            {

            }
            else if (input == "a")
            {

            }
            else if (input == "s")
            {

            }
            else if (input == "d")
            {

            }

            return movement;           
        }
    }
}
