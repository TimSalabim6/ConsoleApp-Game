using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace ConsoleAppGameSD
{
    internal class Program
    {
        static public int hp;
        static public int maxHp = 20;
        static public int damage = 3;
        static public int stamina;
        static public int maxStamina = 10;
        static public bool isBlocking = false;
        static public bool hasSword = false;
        static public int timesTrained = 0;
        static public bool screetched = false;
        static void Main(string[] args)
        {
            EarthMonster earthling = new EarthMonster("Brown", "Smigle", 6, 6, 7, 6, 10, 25);
            WaterHydra waterHydra1 = new WaterHydra("light blue", "Georaph", 3, 6, 6, 7, 5, 9, 10);
            VoidWorm voidWorm = new VoidWorm("Kanox", 12, 4, 12, 10, 10, 30);
            hp = maxHp;
            stamina = maxStamina;
            Intro();


            void Loading()
            {
                Console.Clear();
                Console.WriteLine("Loading the game. Please wait." +
                    "Loading.");
                Thread.Sleep(400);
                Console.Clear();
                Console.WriteLine("Loading the game. Please wait." +
                    "Loading..");
                Thread.Sleep(400);
                Console.Clear();
                Console.WriteLine("Loading the game. Please wait." +
                    "Loading..."); ;
                Thread.Sleep(400);
                Console.Clear();
                Console.WriteLine("Loading the game completed."
                Thread.Sleep(2000);
                Console.Clear();
            }

            void Intro()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SCREETSH");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Mom, dad, what is that sound?");
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Mom: Everything will be alright!");
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dad: Hey come here, I will put you in a Cryopod. " +
    "You might feel a bit wierd at first. But everying will be alright!");
                Thread.Sleep(7000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("But I don't want to leave you.");
                Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Mom: Give us a hug, we will contact u soon.");
                Thread.Sleep(4000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Okayy...");
                Thread.Sleep(3000);
                Loading();
                Landing();
            }

            void Landing()
            {
                bool didChoose = true;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Cryopod: You have just landed on an planet 58232.");
                Console.WriteLine("Cryopod: Your change to survive is 0.0032%.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Well, thats nice to know.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Cryopod: The best way to survive is to find drink able water.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Yeah, tell me where I can find some.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Cryopod: I'm not able to Source any water, since the powerline to the gps is broken.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Of course, my luck. I better search for some nearby water then myself soon.");
                while (didChoose)
                {
                    string a = Choices(3, "Scout", "Sleep", "Eat", "", "");
                    switch (a)
                    {
                        case "1":
                            Scout(1);
                            didChoose = false;
                            break;
                        case "2":
                            Sleep();
                            break;
                        case "3":
                            Eat();
                            break;
                        default:
                            Console.WriteLine("Not a valid input...");
                            break;
                    }
                    Console.ReadLine();
                }
            }

            void Scout(int stage)
            {
                switch (stage)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are now walking and you see a forest in the distance.");
                        Thread.Sleep(3000);
                        Console.WriteLine("You see a lake and walk to it.");
                        Thread.Sleep(3000);
                        Loading();
                        Lake();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A Water Hydra apears out of the lake. You have to fight him to go any further");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("You are now entering combat...");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.White;
                        Loading();
                        FightWaterHydra();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("An Earthling apeared out of nowhere. he looks really mad. You have to fight him to continue on this journey.");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("You are now entering combat...");
                        Thread.Sleep(2000);
                        Loading();
                        FightEarthling();
                        break;
                }
            }

            void Sleep()
            {
                Console.Clear();
                Console.WriteLine("You are back at Max stamina because you had a pleasant night rest");
                stamina = maxStamina;
                Console.WriteLine("You are now at " + stamina + " stamina.");
                Console.WriteLine("press enter to return...");
            }

            void Eat()
            {
                Console.Clear();
                Console.WriteLine("You are back at Max health because you ate a delicious meal.");
                hp = maxHp;
                Console.WriteLine("You are now at " + hp + " hp.");
                Console.WriteLine("press enter to return...");
            }

            void Train()
            {
                Console.Clear();
                Random rnd = new Random();
                int newDamage = rnd.Next(1, 4);
                damage += newDamage;
                Console.WriteLine("You have trained for an hour and you stamina has gone down by 10.");
                Console.WriteLine("You gained " + newDamage + " damage. Your total is now " + damage + ".");
                timesTrained++;
                stamina -= 10;
            }

            void AttackHydra()
            {
                Console.Clear();
                Random rnd = new Random();
                int dmg = rnd.Next(1, damage);
                waterHydra1.hp -= dmg;
                Console.WriteLine("You made swung your fist and did " + dmg + " damage to the Hydra. The Hydra has " + waterHydra1.hp + " hp left.");
            }

            void Block()
            {
                Console.Clear();
                Console.WriteLine("You are now blocking the next attack and will heal 2 hp");
                isBlocking = true;
                hp += 2;
                Console.WriteLine("You now have " + hp + " hp left.");
            }
            void Run()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You ran away and failed the quest. " +
                "You have to start all over but at least you are still alive. Either way we dont want you quiters so bye!");
                System.Environment.Exit(0);
            }

            string Choices(int numberOfChoices, string choice1, string choice2, string choice3, string choice4, string choice5)
            {
                switch (numberOfChoices)
                {
                    case 2:
                        Console.WriteLine("You have 2 choices: " + choice1 + " [1], " + choice2 + " [2]. Press the number of desire.");
                        string a = Console.ReadLine();
                        return a;
                        break;
                    case 3:
                        Console.WriteLine("You have 3 choices: " + choice1 + " [1], " + choice2 + " [2], " + choice3 + " [3]. Press the number of desire.");
                        string b = Console.ReadLine();
                        return b;
                        break;
                    case 4:
                        Console.WriteLine("You have 3 choices: " + choice1 + " [1], " + choice2 + " [2], " + choice3 + " [3], " + choice4 + " [4]. Press the number of desire.");
                        string c = Console.ReadLine();
                        return c;
                        break;
                    default:
                        return "Not defined";
                }
            }

            void Lake()
            {
                Console.Clear();
                Console.WriteLine("You have now arived at the lake.");
                bool didChoose = true;
                while (didChoose)
                {
                    string a = Choices(3, "Scout", "Sleep", "Eat", "", "");
                    switch (a)
                    {
                        case "1":
                            Scout(2);
                            didChoose = false;
                            break;
                        case "2":
                            Sleep();
                            break;
                        case "3":
                            Eat();
                            break;
                        default:
                            Console.WriteLine("Not a valid input...");
                            break;
                    }
                    Console.ReadLine();
                }
            }
            void FightWaterHydra()
            {
                bool isAlive = true;
                while (isAlive)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    PlayersTurn();
                    if (hp <= 0)
                    {
                        Console.WriteLine("The hydra has defeated you. You died!");
                        System.Environment.Exit(0);
                    }
                    if (waterHydra1.hp <= 0)
                    {
                        Console.WriteLine("The Water Hydra was defeated! You won!");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=================      Drops      =================");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("1x Golden Sword");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("3x Hydra Meat");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("2x Golden Coin");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("===================================================");

                        Thread.Sleep(2000);
                        Console.WriteLine("You pick it up and this will boost you damge by x2!");
                        hasSword = true;
                        isAlive = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        HydrasTurn();
                    }
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                HydraDefeated();

            }

            void PlayersTurn()
            {
                Console.Clear();
                Console.WriteLine("It is your turn to attack the Hydra. It has " + waterHydra1.hp + " hp left.");
                bool didNotChoose = true;
                while (didNotChoose)
                {
                    string a = Choices(3, "Attack", "Block", "Run", "", "");
                    switch (a)
                    {
                        case "1":
                            AttackHydra();
                            didNotChoose = false;
                            break;
                        case "2":
                            Block();
                            didNotChoose = false;
                            break;
                        case "3":
                            Run();
                            didNotChoose = false;
                            break;
                        default:
                            Console.WriteLine("You missed your turn better luck next time!");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void HydrasTurn()
            {
                Console.Clear();
                Console.WriteLine("It is the Hydra's turn to attack.");
                Thread.Sleep(3000);
                Random rnd = new Random();
                int dmg = rnd.Next(1, waterHydra1.attack);
                int missed = rnd.Next(0, 2);
                if (missed == 0)
                {
                    Console.WriteLine("The Hydra missed you entirly. So you took no damage at all.");
                }
                else
                {
                    if (isBlocking)
                    {
                        dmg /= 2;
                        isBlocking = false;
                    }
                    hp -= dmg;
                    Console.WriteLine("The Hydra swung his head at you and did a total of " + dmg + " damage to you. You now have " + hp + " hp left.");
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void HydraDefeated()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Now that the hydra is defeated you can continue on your journey.");
                bool didNotChoose = true;
                while (didNotChoose)
                {
                    string a = Choices(4, "Scout", "Sleep", "Eat", "Train", "");
                    switch (a)
                    {
                        case "1":
                            Scout(3);
                            didNotChoose = false;
                            break;
                        case "2":
                            Sleep();
                            break;
                        case "3":
                            Eat();
                            break;
                        case "4":
                            if (timesTrained != 3)
                            {
                                if (stamina >= 10)
                                {
                                    Train();
                                }
                                else
                                {
                                    Console.WriteLine("You dont have enough stamina. Your total is now at " + stamina + ".");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have trained enough.");
                            }
                            break;
                        default:
                            Console.WriteLine("Not a valid input.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
            }

            void FightEarthling()
            {
                Console.WriteLine("There is a ugly looking earthling running at you.");
                bool isAlive = true;
                while (isAlive)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    PlayersTurnEarthling();
                    if (hp <= 0)
                    {
                        Console.WriteLine("The earthling has defeated you. You died!");
                        System.Environment.Exit(0);
                    }
                    if (earthling.hp <= 0)
                    {
                        Console.WriteLine("You defeated the Earthling! You won!");
                        Thread.Sleep(2000);
                        Console.WriteLine("=================      Drops      =================");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("1x Heal Postion");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("1x Golden Coin");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("===================================================");
                        isAlive = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        EarthlingTurn();
                    }
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void PlayersTurnEarthling()
            {
                Console.Clear();
                Console.WriteLine("It is your turn to attack the Earthling. It has " + earthling.hp + " hp left.");
                bool didNotChoose = true;
                while (didNotChoose)
                {
                    string a = Choices(3, "Attack", "Block", "Run", "", "");
                    switch (a)
                    {
                        case "1":
                            AttackEartling();
                            didNotChoose = false;
                            break;
                        case "2":
                            Block();
                            didNotChoose = false;
                            break;
                        case "3":
                            Run();
                            didNotChoose = false;
                            break;
                        default:
                            Console.WriteLine("You missed your turn better luck next time!");
                            Thread.Sleep(2000);
                            didNotChoose = false;
                            break;
                    }
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }

            void EarthlingTurn()
            {
                Console.Clear();
                Console.WriteLine("It is the Earthling's turn to attack.");
                Thread.Sleep(3000);
                Random rnd = new Random();
                int dmg = rnd.Next(1, earthling.attack);
                int missed = rnd.Next(0, 2);
                if (missed == 0)
                {
                    Console.WriteLine("The Earthling missed you entirly. So you took no damage at all.");
                }
                else
                {
                    if (isBlocking)
                    {
                        dmg /= 2;
                        isBlocking = false;
                    }
                    hp -= dmg;
                    Console.WriteLine("The earthling threw a rock at you and did a total of " + dmg + " damage to you. You now have " + hp + " hp left.");
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void AttackEartling()
            {
                Console.Clear();
                Random rnd = new Random();
                int dmg = rnd.Next(1, damage);
                if (hasSword)
                {
                    dmg *= 2;
                    Console.WriteLine("You do more damage because of your sword");
                }
                earthling.hp -= dmg;
                Console.WriteLine("You made swung your sword and did " + dmg + " damage to the Earthling. The Earthling has " + earthling.hp + " hp left.");
            }

            void FightVoidWorm()
            {
                Console.Clear();
                Console.WriteLine("While you are walking through the forest you hear an unknown sound.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("SCREETSH!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.WriteLine("No, not that sound again!");
                bool isAlive = true;
                while (isAlive)
                {
                    if (hp <= 0)
                    {
                        //player dead
                    }
                    else
                    {
                        PlayersTurnVoidWorm();
                    }
                    if (voidWorm.hp <= 0)
                    {
                        //Void worm dead
                    }
                    else
                    {
                        VoidWormsTurn();
                    }
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void PlayersTurnVoidWorm()
            {
                Console.WriteLine("Its your turn.");
                string a = Choices(3, "Attack", "Block", "Run", "", "");
                switch (a)
                {
                    case "1":
                        AttackvoidWorm();
                        break;
                    case "2":
                        Block();
                        break;
                    case "3":
                        Run();
                        break;
                }
            }

            void VoidWormsTurn()
            {
                Console.WriteLine("Its thee tvoid worms turn to attack.");
                Thread.Sleep(2000);
                Random rnd = new Random();
                bool swordtrow = rnd.Next(2) == 0;
                int ScreetshPosability = rnd.Next(1, 3);
                if (swordtrow)
                {
                    voidWorm.TrowSword(ref hasSword);
                    Thread.Sleep(2000);
                }
                if (ScreetshPosability == 1)
                {
                    voidWorm.Screetsh(ref hp, ref screetched);
                    Thread.Sleep(2000);
                }
                voidWorm.Attack(ref hp, ref isBlocking);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }

            void AttackvoidWorm()
            {
                Random rnd = new Random();
                int dmg = rnd.Next(1, damage);
                if (hasSword)
                {
                    dmg *= 2;
                    Console.WriteLine("You are doing more damage because of your sword.");
                }
                else
                {
                    Console.WriteLine("You dont have your sword. You can get it back by rolling a 4 or higher on a dice of 6.");
                    Console.WriteLine("Press ENTER to roll the dice...");
                    Console.ReadLine();
                    int diceRoll = rnd.Next(1, 6);
                    Console.WriteLine("You rolled a " + diceRoll + "!");
                    Thread.Sleep(2000);
                    if (diceRoll >= 4)
                    {
                        Console.WriteLine("You have gotten your sword back. You now deal twice as much damage!");
                        hasSword = true;
                        dmg *= 2;
                    }
                    else
                    {
                        Console.WriteLine("Unfortuneatly you didnt get your sword back. Try again next turn.");
                    }
                }
                Console.WriteLine("You did a grant total of " + dmg + " damage to the Void worm. It now has " + voidWorm.hp + " hp left");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }

    }

    //WaterHydra (First Monster)
    class WaterHydra
    {
        public string color;
        public string name;

        public int numberOfHeads;
        public int size;
        public int speed;
        public int attack;
        public int defence;
        public int stamina;
        public int hp;


        public WaterHydra(string color, string name, int numberOfHeads, int size, int speed, int attack, int defence, int stamina, int hp)
        {
            this.color = color;
            this.name = name;
            this.numberOfHeads = numberOfHeads;
            this.size = size;
            this.speed = speed;
            this.attack = attack;
            this.defence = defence;
            this.stamina = stamina;
            this.hp = hp;

        }
    }

    //EarthMonster (Second Monster)
    class EarthMonster
    {
        public string color;
        public string name;

        public int hp;
        public int size;
        public int speed;
        public int attack;
        public int defence;
        public int stamina;


        public EarthMonster(string color, string name, int size, int speed, int attack, int defence, int stamina, int hp)
        {
            this.color = color;
            this.name = name;
            this.size = size;
            this.speed = speed;
            this.attack = attack;
            this.defence = defence;
            this.stamina = stamina;
            this.hp = hp;
        }
    }

    //VoidWorm (FinalBoss)
    class VoidWorm
    {
        public string name;
        public int size;
        public int speed;
        public int attack;
        public int defence;
        public int screetchdamage;
        public int hp;


        public VoidWorm(string name, int size, int speed, int attack, int defence, int screetchdamage, int hp)
        {
            this.name = name;
            this.size = size;
            this.speed = speed;
            this.attack = attack;
            this.defence = defence;
            this.screetchdamage = screetchdamage;
        }

        public void Screetsh(ref int hp, ref bool screetshed)
        {
            Console.WriteLine("The Void Worm has used its Screetch ability. You took " + screetchdamage + " damage and you are not able to attack next move.");
            hp -= 10;
            screetshed = true;
        }

        public void Attack(ref int hp, ref bool isBlocking)
        {
            Random rnd = new Random();
            bool hit = rnd.Next(2) == 0;
            if (hit)
            {
                int damage = rnd.Next(1, attack);
                if (isBlocking)
                {
                    isBlocking = false;
                    damage /= 2;
                }
                hp -= damage;
                Console.WriteLine("The void worm has attacked you and did a total of " + damage + " damage to you. You now have " + hp + " hp left.");
            }
            else
            {
                Console.WriteLine("");
            }

        }

        public void TrowSword(ref bool hasSword)
        {
            Console.WriteLine("The Void worm pulled thhe sword out of your hands and threw it away. You have to roll a 4 or above to get it back.");
            hasSword = false;
        }

    }
}