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

            //Minesweeper

            Random generator = new Random();

            int[,] chessBoard = new int[8, 8]; //kommatecknet avgör hur många dimensioner arrayen har.

            chessBoard = MapKey(chessBoard);

            /*int x = 0;
            int y = 0;*/

            (int x, int y, int location) currentState = (0, 0, 0); //Pröva att ta bort "int location"

            int location = chessBoard[currentState.x, currentState.y];

            while (location != 3)
            {
                if (location == 0)
                {
                    Console.WriteLine("0");
                    currentState = Movement(currentState, chessBoard);
                }
                else if (location == 1)
                {
                    Console.WriteLine("1");
                    currentState = Movement(currentState, chessBoard);
                }
                else if (location == 2)
                {
                    Console.WriteLine("2");

                    currentState = Movement(currentState, chessBoard);
                }
            }

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
        static (int x, int y, int location) Movement ((int x, int y, int location) state, int[,] chessBoard)
        {
            Console.WriteLine("Press W for Up");
            Console.WriteLine("Press A for Left");
            Console.WriteLine("Press S for Down");
            Console.WriteLine("Press D for Right");

            string input = Console.ReadLine().ToLower().Trim();

            while (input != "w" && input != "a" && input != "s" && input != "d")
            {
                Console.WriteLine("Press W for Up");
                Console.WriteLine("Press A for Left");
                Console.WriteLine("Press S for Down");
                Console.WriteLine("Press D for Right");
                input = Console.ReadLine();
            }

            if (input == "w")
            {
                state.location = chessBoard[state.x, state.y - 1];
            }
            else if (input == "a")
            {
                state.location = chessBoard[state.x - 1, state.y];
            }
            else if (input == "s")
            {
                state.location = chessBoard[state.x, state.y + 1];
            }
            else if (input == "d")
            {
                state.location = chessBoard[state.x + 1, state.y];
            }

            return state;
        }
    }
}
