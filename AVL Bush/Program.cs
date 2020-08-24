using System;
using System.Collections.Generic;

namespace AVL_Bush
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardedBets<int> leafyBoi = new BoardedBets<int>();
            // boring UI stuff
            while (true)
            {
                Console.WriteLine("Would you like to:\n   a) Add a number\n   b) Remove a number\n   c) Check if we have a number\n   d) Reset the tree\n   e) do other stuff\n   f) exit");
                string blah = Console.ReadLine();
                char c;
                if (blah == "")
                {
                    c = ' ';
                }
                else
                {
                    c = blah[0];
                }
                c = char.ToLower(c);
                if (c == 'a')
                {
                    Console.WriteLine("What number do you want to add?");
                    leafyBoi.add(int.Parse(Console.ReadLine()));
                }
                else if (c == 'b')
                {
                    Console.WriteLine("What number do you want to remove?");
                    if (!leafyBoi.remove(int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine("You cannot remove something that doesn't exist");
                    }
                }
                else if (c == 'c')
                {
                    Console.WriteLine("What number do you want to check?");
                    if (leafyBoi.contains(int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine("The tree contains this number");
                    }
                    else
                    {
                        Console.WriteLine("This number does not exist");
                    }
                }
                else if (c == 'd')
                {
                    leafyBoi = new BoardedBets<int>();
                    Console.WriteLine("The tree is empty now");
                }
                else if (c == 'e')
                {
                    while (true)
                    {
                        Console.WriteLine("Would you like to:\n   a) find the max\n   b) find the min\n   c) find a number's floor\n   d) find a number's ceiling\n  e) go back to the LAMER menu\n");
                        blah = Console.ReadLine();
                        if (blah == "")
                        {
                            Console.WriteLine("TRYING TO THROW AN EXCEPTION ON ME EH!?\n JUST GO BACK TO THE OTHER MENU YOU ******* ********** ****************************************ING IDIOT!");
                            break;
                        }
                        char a = blah[0];
                        a = char.ToLower(a);
                        if (a == 'a')
                        {
                            Console.WriteLine(leafyBoi.max());
                        }
                        else if (a == 'b')
                        {
                            Console.WriteLine(leafyBoi.min());
                        }
                        else if (a == 'c')
                        {
                            Console.WriteLine("What number do you want?");
                            Console.WriteLine(leafyBoi.floor(int.Parse(Console.ReadLine())));
                        }
                        else if (a == 'd')
                        {
                            Console.WriteLine("What number do you want?");
                            Console.WriteLine(leafyBoi.ceiling(int.Parse(Console.ReadLine())));
                        }
                        else if (a == 'e')
                        {
                            Console.WriteLine("Well...you can go back to the loser's menu for all I care!\n *Hurumph*\n\nWelcome back! I hope my colleague wasn't too much trouble");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("DID I SAY YOU COULD DO THAT YOU ******* ***** ****** ****** ******!?");
                        }
                    }
                }
                else if (c == 'f')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("That is not an option dumkoft");
                }
            }
        }
    }
}
