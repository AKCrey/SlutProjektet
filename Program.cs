using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SlutProjektet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] chessBoard = new int[8, 8]; //kommatecknet avgör hur många dimensioner arrayen har. Jag har valt att göra en tvådimensionell array då jag bara vill ha kartan 8x8 i storlek. Det var den tvådimensionella arrayen som gav mig idéen till hela projektet, där jag såg ett kordinatsystem som man skulle kunna röra runt sig på. 
            
            string goAgane = Start();

            while (goAgane == "y")
            {
                int playerHP = 50; //livet anges här nere för att man ska kunna köra om spelet och börja med 50 hp. 

                chessBoard = FirstMap(chessBoard); //Arrayen måste skrivas ut en gång först för att kordinaterna ska anges värden.

                (int x, int y, int location) currentState = (0, 0, 0); //x och y ligger i samma variabel för att man ska returnera båda värderna i 1 metod samtidigt. "location" avgör inte vart man är, utan vilket rum det kommer bli. 

                currentState.location = chessBoard[currentState.x, currentState.y];

                playerHP = RoomLoop(chessBoard, playerHP, currentState); //Loopen för rummen. 

                if (playerHP <= 0)
                {
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("");
                }
                Console.WriteLine("Do you want to GO AGANE? Y/N"); //Eftersom det fortfarande är samma fråga om Y/N så kan man använda det till att göra om allt igen. 

                goAgane = Console.ReadLine().Trim().ToLower();

            }

            Console.ReadLine();

        }
        static string Start ()
        {
            Console.WriteLine("Press Y to start");

            string goAgane = Console.ReadLine().ToLower().Trim();

            if (goAgane != "y") //Om man bestämmer sig för att inte skriva in Y så får man skylla sig själv
            {
                Console.WriteLine("Well then, get lost");
            }

            return goAgane;
        }
        static int[,] FirstMap (int[,] chessBoard) //Metoden för klicka på 1 för att anropa Map metoden
        {
            Random generator = new Random();

            for (int y = 0; y < 8; y++) 
            {
                for (int x = 0; x < 8; x++) //Denna loop gör att för varje gång y går upp med 1 så körs den andra som skriver ut 8 värden på rad. 
                {
                    chessBoard[x, y] = generator.Next(3); //Denna rad slumpar in ett tal mellan 0-2 i varje kordinat som skapats. 
                    Console.Write(chessBoard[x, y]);
                }
                Console.WriteLine();//Den byter rad.
            }

            Console.Clear(); //Arrayen måste ha skapats för att jag ska kunna referera till den senare, men eftersom jag vill ha en i loopen så vill jag cleara den här. 

            return chessBoard;
        }
        static int RoomLoop (int[,] chessBoard, int playerHP, (int x, int y, int location) currentState )
        {
            while (currentState.location != 3)
            {
                chessBoard = Map(chessBoard); //Denna metod anropas vare gång loopen körs om, vilket är bra då man konstant kan se kartan. 

                Locations(currentState);

                if (currentState.location == 0)
                {
                    //Console.WriteLine("0");

                    playerHP = Battle(playerHP); //I rum 0 finns det en strid. 

                    if (playerHP <= 0)
                    {
                        currentState.location = 3; //Game Over
                    }
                    else
                    {
                        chessBoard = Map(chessBoard); //Eftersom kartan försvinner under striden vill jag visa den igen efter. 
                        Locations(currentState);

                        currentState = Movement(currentState, chessBoard);
                    }

                }
                else if (currentState.location == 1)
                {
                    //Console.WriteLine("1");

                    currentState = Movement(currentState, chessBoard);

                }
                else if (currentState.location == 2)
                {
                    //Console.WriteLine("2");

                    currentState = Movement(currentState, chessBoard);

                }

                Console.Clear();

            }

            return playerHP;
        }
        static int[,] Map (int[,] chessBoard) //Visar kartan.
        {

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(chessBoard[x, y]);
                }
                Console.WriteLine();
            }

            return chessBoard;

        }
        static void Locations ((int x, int y, int location) state )
        {
            Console.WriteLine("Coordinates: " + state.x + ", " + state.y);//Det här är lite fucked då 0,0 är högst upp i vänstra hörnet. 
            Console.WriteLine("Currently on: " + state.location);
            Console.WriteLine("");
        }
        static (int x, int y, int location) Movement ((int x, int y, int location) state, int[,] chessBoard)
        {
            string input = MovementControl(state.x, state.y); //Metoden hämtar in vilken knapp som användaren tryckt för att förflytta sig. 

            input = MovementControlCheck(state.x, state.y, input); //Om användaren inte skrev in något av rörelse-alternativen.

            if (input == "w" && state.y > 0) //state.y > 0 säkerhetskollar så att man inte kan gå uppåt även om man inte fått det alternativet, så att spelet inte kraschar. 
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

            return (state.x, state.y, state.location); //man har redan flyttat på sig men värdena måste behållas för nästa förflyttning.
        }
        static string MovementControl(int x, int y)
        {
            if (y > 0) //Om man står på kanten ska man inte ens få alternativet att gå in i väggen. 
            {
                Console.WriteLine("Press W for Up");
            }

            if (x > 0)
            {
                Console.WriteLine("Press A for Left");
            }

            if (y < 7)
            {
                Console.WriteLine("Press S for Down");
            }

            if (x < 7)
            {
                Console.WriteLine("Press D for Right");
            }

            string input = Console.ReadLine().ToLower().Trim();

            return input;
        }
        static string MovementControlCheck (int x, int y, string input)
        {

            while (input != "w" && input != "a" && input != "s" && input != "d") //Den klassiska while-loopen som kontrollerar att användaren skriver in rätt alternativ. 
            {
                if (y > 0)
                {
                    Console.WriteLine("Press W for Up");
                }

                if (x > 0)
                {
                    Console.WriteLine("Press A for Left");
                }

                if (y < 7)
                {
                    Console.WriteLine("Press S for Down");
                }

                if (x < 7)
                {
                    Console.WriteLine("Press D for Right");
                }

                input = Console.ReadLine().ToLower().Trim();
            }

            return input;
        }
        static int Battle(int playerHP) //Här är min strid lagrad i en metod
        {
            Random generator = new Random();

            string fighterA = "You"; //För framtida ändringar och tydligare kod gjorde jag även en fighterA istället för att bara skriva "You"

            string fighterB = "Dungeon Master";

            int enemyHP = 20; //Motståndarens HP. 

            EnemySpotted(fighterB);

            while (playerHP > 0 && enemyHP > 0) //Så länge båda karaktärer har över 0 hp så fortsätter striden
            {
                string choiceAttack = AttackChoice(fighterB, playerHP, enemyHP); //Anropar attack-valet för SPELAREN

                enemyHP = UserAttack(choiceAttack, enemyHP, fighterA, fighterB); //Anropar attack-metoden för SPELAREN

                playerHP = EnemyAttack(playerHP, fighterB); //Anropar metoden för MOTSTÅNDAREN

                Console.Clear();//Eftersom det är en del text och val man måste göra varje gång, så ville jag Cleara det efter varje runda. 
            }

            PlayerWin(enemyHP, fighterB);

            return playerHP; //playerHP måste komma till baka till main-koden
        }
        static void EnemySpotted(string fighterB) //Eftersom jag bara har text behöver jag inte returna något värde. 
        {
            Console.WriteLine("");
            Console.WriteLine("A " + fighterB + " attacks!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            Console.WriteLine("");
            Console.ReadLine();
        }
        static string AttackChoice (string fighterB, int playerHP, int enemyHP) //Metoden för användarens attack choice. 
        {
            Console.WriteLine("Your HP: " + playerHP);
            Console.WriteLine(fighterB + " HP: " + enemyHP);

            Console.WriteLine("");

            Console.WriteLine("Choose an Attack! (Write the number)");
            Console.WriteLine("1. Light Attack (7-9 DMG)");
            Console.WriteLine("2. Heavy Attack (12-16 DMG)");

            string choiceAttack = Console.ReadLine().Trim();

            while (choiceAttack != "1" && choiceAttack != "2" && choiceAttack != "1." && choiceAttack != "2.") //Om man inte skriver in attack-nummret så loopas det.
            {
                Console.WriteLine("Wrong Input");
                choiceAttack = Console.ReadLine();
            }

            Console.WriteLine("");

            return choiceAttack;
        }
        static int UserAttack (string choiceAttack, int enemyHP, string fighterA, string fighterB) //Metoden för spelarens attack
        {
            Random generator = new Random();

            int dmgLightA = generator.Next(7, 9); //Random DMG för både light och heavy. Detta för att göra det lite mer varierat.
            int dmgHeavyA = generator.Next(12, 16);

            if (choiceAttack == "1" || choiceAttack == "1.") //När man väljer attack 1 (light attack) så händer följande:
            {
                enemyHP = enemyHP - dmgLightA;
                Console.WriteLine(fighterA + " did " + dmgLightA + " DMG to " + fighterB); //Vill skriva ut hur mycket dmg man gör mot motståndaren
            }
            else if (choiceAttack == "2" || choiceAttack == "2.")//När man väljer attack 2 (heavy) så händer följande:
            {
                enemyHP = enemyHP - dmgHeavyA;
                Console.WriteLine(fighterA + " did " + dmgHeavyA + " DMG to " + fighterB); //Fungerar på samma sätt som light attacken
            }

            Console.WriteLine("");

            return enemyHP;
        }
        static int EnemyAttack (int playerHP, string fighterB) //Metoden för motståndarens attack. 
        {
            Random generator = new Random();

            int attack = generator.Next(1, 3); // 50/50 om det är light eller heavy attack
            int dmgLight = generator.Next(5, 7);
            int dmgHeavy = generator.Next(8, 11);

            if (attack == 1) //Om attack blir 1, gör motståndaren en light attack på dmgLight DMG. 
            {
                playerHP = playerHP - dmgLight;
                Console.WriteLine(fighterB + " used: Light attack!");
                Console.WriteLine(fighterB + " did " + dmgLight + " DMG");
            }
            else if (attack == 2) //Osv med attack 2. 
            {
                playerHP = playerHP - dmgHeavy;
                Console.WriteLine(fighterB + " used: Heavy attack!");
                Console.WriteLine(fighterB + " did " + dmgHeavy + " DMG to you");
            }

            Console.ReadLine();

            return playerHP; //Eftersom det är spelarens HP som motståndaren slagit påp måste spelarens HP returneras. 
        }
        static void PlayerWin (int enemyHP, string fighterB) //Eftersom jag bara har text behöver jag inte returna något värde. 
        {
            if (enemyHP <= 0) //Om MOTSTÅNDAREN har mindre eller lika med 0 HP så vinner spelaren
            {
                Console.WriteLine(fighterB + " died");
                Console.WriteLine("Fight won!");
            }

            Console.ReadLine();
        }
    }
}
