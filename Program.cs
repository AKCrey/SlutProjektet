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

            int playerHP = 50;

            int[,] chessBoard = new int[8, 8]; //kommatecknet avgör hur många dimensioner arrayen har.

            chessBoard = Map(chessBoard);

            Console.Clear();

            (int x, int y, int location) currentState = (0, 0, 0); //Pröva att ta bort "int location", den ska ju inte få ett värde i början. 

            currentState.location = chessBoard[currentState.x, currentState.y];

            while (currentState.location != 3 || playerHP <= 0)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        Console.Write(chessBoard[x, y]);
                    }
                    Console.WriteLine();
                }

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
                Console.Clear();
            }

            //Lägg in någonting som kan få spelet att köras om. 

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
                
                input = Console.ReadLine().ToLower().Trim();
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
        static int battle(int playerHP) //Här är min strid lagrad i en metod
        {
            Random generator = new Random();

            string fighterA = "You";

            string fighterB = "Dungeon Master";

            int hpA = playerHP;
            int hpB = 20;

            Console.WriteLine("A " + fighterB + " attacks!");
            Console.WriteLine("");

            while (hpA > 0 && hpB > 0) //Så länge båda karaktärer har över 0 hp så fortsätter striden//
            {
                Console.WriteLine("Your HP: " + hpA);
                Console.WriteLine(fighterB + " HP: " + hpB);

                Console.WriteLine("");

                Console.WriteLine("Choose an Attack! (Write the number)");
                Console.WriteLine("1. Lightsaber Strike (Low DMG but high chance of hitting)");
                Console.WriteLine("2. Force Push (High DMG but low chance of hitting)");

                string choiceAttack = Console.ReadLine().Trim();

                while (choiceAttack != "1" && choiceAttack != "2" && choiceAttack != "1." && choiceAttack != "2.") //Om man inte skriver in attack-nummret så loopas det.
                {
                    Console.WriteLine("Wrong Input");
                    choiceAttack = Console.ReadLine();
                }

                Console.WriteLine("");

                int dmgLightA = generator.Next(7, 9); //Random DMG för både light och heavy. Detta för att göra det lite mer varierat.
                int dmgHeavyA = generator.Next(12, 16);

                if (choiceAttack == "1" || choiceAttack == "1.") //När man väljer attack 1 (light attack) så händer följande:
                {
                    hpB = hpB - dmgLightA;
                    Console.WriteLine(fighterA + " did " + dmgLightA + " DMG to " + fighterB); //Vill skriva ut hur mycket dmg man gör mot motståndaren
                }
                else if (choiceAttack == "2" || choiceAttack == "2.")//När man väljer attack 2 (heavy) så händer följande:
                { 
                    hpB = hpB - dmgHeavyA;
                    Console.WriteLine(fighterA + " did " + dmgHeavyA + " DMG to " + fighterB); //Fungerar på samma sätt som light attacken
                }

                Console.WriteLine("");

                int trooperAttack = generator.Next(1, 3); // 50/50 om det är light eller heavy attack
                int dmgLightShadow = generator.Next(5, 7);
                int dmgHeavyShadow = generator.Next(8, 11);

                if (trooperAttack == 1)
                {
                    hpA = hpA - dmgLightShadow;
                    Console.WriteLine(fighterB + " used: Light attack!");
                    Console.WriteLine(fighterB + " did " + dmgLightShadow + " DMG");
                }
                else if (trooperAttack == 2)
                {
                    hpA = hpA - dmgHeavyShadow;
                    Console.WriteLine(fighterB + " used: Heavy attack!");
                    Console.WriteLine(fighterB + " did " + dmgHeavyShadow + " DMG to you");
                }

                Console.ReadLine();

                Console.Clear();//Eftersom det är en del text och val man måste göra varje gång, så ville jag Cleara det efter varje runda. 
            }

            if (hpB <= 0) //Om motståndaren har mindre eller lika med 0 så vinner spelaren! Yay :D
            {
                Console.WriteLine(fighterB + " died");
                Console.WriteLine("Fight won!");
            }

            playerHP = hpA; //hpA skrivs över till playerHP

            Console.ReadLine();

            return playerHP; //playerHP måste komma till baka till main-koden
        }
    }
}
