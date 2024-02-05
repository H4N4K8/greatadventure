using System;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref health, r);
            while (lives > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref health);
                else
                    actions(r.Next(10), ref lives, ref health);
                checkResults(ref round, ref lives, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully walking to the store!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and ended up in the hospital");
            else
                Console.WriteLine("You are in poor health and had to go home");

        }
        static void initValues(ref int lives, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            health = r.Next(5, 15) + 1;
        }
        static int chooseDirection()
        {
            Console.WriteLine("You take a step forward, enter 1 to go right and 2 to go left");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        static void actions(int num, ref int lives, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You tripped on a rock");
                    Console.WriteLine("You lose 1 unit of health");
                    health -= 1;
                    break;
                case 1:
                    Console.WriteLine("You walked in front of a car and just barley made it past");
                    Console.WriteLine("You lost 2 units of health and 1 life");
                    health -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You fall through a manhole cover");
                    Console.WriteLine("you lose 1 life.");
                    lives -= 1;
                    break;
                case 3:
                    Console.WriteLine("You stop to grab some street food");
                    Console.WriteLine("You gain one life");
                    lives += 1;
                    break;
                case 4:
                    Console.WriteLine("You see a cute dog");
                    Console.WriteLine("You gained 3 health");
                    health += 3;
                    break;
                case 5:
                    Console.WriteLine("You find a 100 dollar bill");
                    Console.WriteLine("You gain 2 health and lives");
                    health += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You crossed the crosswalk");
                    Console.WriteLine("You gain 3 units of health");
                    health += 3;
                    break;
                case 7:
                    Console.WriteLine("You witness a purse theft");
                    Console.WriteLine("You lose 3 health");
                    health -= 3;
                    break;
                case 8:
                    Console.WriteLine("You are given free lemonade from a lemonade stand");
                    Console.WriteLine("You gain 1 life and 3 health");
                    lives += 1;
                    health += 3;
                    break;
                case 9:
                    Console.WriteLine("You are smited");
                    Console.WriteLine("You lose 5 health and 2 lives");
                    health -= 5;
                    lives -= 2;
                    break;
                default:
                    Console.WriteLine("Your shoes feel very comfortable");
                    Console.WriteLine("You gain 2 health");
                    health += 2;
                    break;
            }
        }
        private static void checkResults(ref int round, ref int lives, ref int health, ref bool win)
        {
            round++;
            Console.WriteLine(round);
            Console.WriteLine("Lives =" + lives);
            Console.WriteLine("Health =" + health);
            if (round >= 25)
            {
                win = true;
            }
        }
    }
}