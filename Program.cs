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

            chessBoard = Map(chessBoard);

            (int x, int y, int location) currentState = (0, 0, 0); //Pröva att ta bort "int location", den ska ju inte få ett värde i början. 

            currentState.location = chessBoard[currentState.x, currentState.y];

            while (currentState.location != 3)
            {
                //chessBoard = Map(chessBoard);

                if (currentState.location == 0)
                {
                    Console.WriteLine("0");
                    currentState = Movement(currentState, chessBoard);

                }
                else if (currentState.location == 1)
                {
                    Console.WriteLine("1");
                    currentState = Movement(currentState, chessBoard);

                }
                else if (currentState.location == 2)
                {
                    Console.WriteLine("2");

                    currentState = Movement(currentState, chessBoard);
                    
                }
                //Console.Clear();
            }

            Console.ReadLine();

        }
        /*static int[,] MapKey (int[,] chessBoard) //Metoden för klicka på 1 för att anropa Map metoden
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
        }Just nu har jag inget behov av att detta. Kartan ska istället visas hela tiden*/
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
            if (state.y > 0)
            {
                Console.WriteLine("Press W for Up");
            }
            
            if (state.x > 0)
            {
                Console.WriteLine("Press A for Left");
            }
            
            if (state.y < 7)
            {
                Console.WriteLine("Press S for Down");
            }
            
            if (state.x < 7)
            {
                Console.WriteLine("Press D for Right");
            }

            string input = Console.ReadLine().ToLower().Trim();

            while (input != "w" && input != "a" && input != "s" && input != "d")
            {
                if (state.y > 0)
                {
                    Console.WriteLine("Press W for Up");
                }

                if (state.x > 0)
                {
                    Console.WriteLine("Press A for Left");
                }

                if (state.y < 7)
                {
                    Console.WriteLine("Press S for Down");
                }

                if (state.x < 7)
                {
                    Console.WriteLine("Press D for Right");
                }
                
                input = Console.ReadLine();
            }

            if (input == "w" && state.y > 0)
            {
                state.y = state.y - 1;

            }
            else if (input == "a" && state.x > 0)
            {
                state.x = state.x - 1;
            }
            else if (input == "s" && state.y < 7)
            {
                state.y = state.y + 1;
            }
            else if (input == "d" && state.x < 7)
            {
                state.x = state.x + 1;
            }

            state.location = chessBoard[state.x, state.y]; //Uppdaterar locationen utifrån vad användaren har klickat på för knapp.

            return (state.x, state.y, state.location);
        }
    }
}
