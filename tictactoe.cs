using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Developer:
//██████╗░███████╗███╗░░░███╗░█████╗░░██████╗
//██╔══██╗██╔════╝████╗░████║██╔══██╗██╔════╝
//██████╦╝█████╗░░██╔████╔██║██║░░██║╚█████╗░
//██╔══██╗██╔══╝░░██║╚██╔╝██║██║░░██║░╚═══██╗
//██████╦╝███████╗██║░╚═╝░██║╚█████╔╝██████╔╝
//╚═════╝░╚══════╝╚═╝░░░░░╚═╝░╚════╝░╚═════╝░

namespace bemostictactoe
{
    class tictactoe
    {

        private string[,] field =
            {
                {"1", "2", "3",},
                {"4", "5", "6",},
                {"7", "8", "9",}
            };

        public void Game()
        {
            Show(field);

            int player = 1;

            bool isTrue = false;

            for (int i = 1; i < 6; i++)
            {
                if (player == 1)
                {
                    link1:
                    Console.WriteLine("Ход крестиков:");
                    Console.Write("Введите число -> ");
                    string y = Console.ReadLine();

                    if (y == "x" || y == "o")
                        goto link1;

                    int number = Convert.ToInt32(y);

                    if (number >= 10)
                    {
                        goto link1;
                    }

                    bool SeachValue = true;

                    SeachValue = Search(field, y);

                    if (SeachValue == false)
                    {
                        SeachValue = true;
                        goto link1; 
                    }
                    

                    Console.WriteLine();

                    Replace(field, y, "x");

                    player *= -1;

                    Console.Clear();

                    Show(field);
                    isTrue = Check(field);

                    

                    if (isTrue == true)
                    {
                        Console.WriteLine("\tКрестики выйграли :)");
                        break;
                    }
                }

                if (player == -1)
                {
                link2:
                    Console.WriteLine("Ход ноликов:");
                    Console.Write("Введите число -> ");
                    string y = Console.ReadLine();

                    if (y == "x" || y == "o")
                        goto link2;

                    int number = Convert.ToInt32(y);

                    if (number >= 10)
                    {
                        goto link2;
                    }

                    bool SeachValue = true;

                    SeachValue = Search(field, y);

                    if (SeachValue == false)
                    {
                        SeachValue = true;
                        goto link2;
                    }

                    Console.WriteLine();

                    Replace(field, y, "o");

                    player *= -1;

                    Console.Clear();

                    Show(field);
                    isTrue = Check(field);

                    if (isTrue == true)
                    {
                        Console.WriteLine("\tНолики выйграли :)");
                        break;
                    }
                }
            }

            static void Show(string[,] array)
            {
                Console.WriteLine("");

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write("\t" + array[i, j]);
                    }
                    Console.WriteLine("\n");
                }
            }

            static void Replace(string[,] array, string input, string side)
            {
                Console.WriteLine("");

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] == input)
                        {
                            array[i, j] = side;
                        }
                    }
                }
            }

            static bool Search(string[,] array, string input)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] == input)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            static bool Check(string[,] array)
            {
                //по горизонтали
                if (array[0, 0] == "x" && array[0, 1] == "x" && array[0, 2] == "x" || array[0, 0] == "o" && array[0, 1] == "o" && array[0, 2] == "o")
                {
                    return true;
                }

                else if (array[1, 0] == "x" && array[1, 1] == "x" && array[1, 2] == "x" || array[1, 0] == "o" && array[1, 1] == "o" && array[1, 2] == "o")
                {
                    return true;
                }

                else if (array[2, 0] == "x" && array[2, 1] == "x" && array[2, 2] == "x" || array[2, 0] == "o" && array[2, 1] == "o" && array[2, 2] == "o")
                {
                    return true;
                }
                //---------------------

                //по вертикали
                else if (array[0, 0] == "x" && array[1, 0] == "x" && array[2, 0] == "x" || array[0, 0] == "o" && array[1, 0] == "o" && array[2, 0] == "o")
                {
                    return true;
                }

                else if (array[0, 1] == "x" && array[1, 1] == "x" && array[2, 1] == "x" || array[0, 1] == "o" && array[1, 1] == "o" && array[2, 1] == "o")
                {
                    return true;
                }

                else if (array[0, 2] == "x" && array[1, 2] == "x" && array[2, 2] == "x" || array[0, 2] == "o" && array[1, 2] == "o" && array[2, 2] == "o")
                {
                    return true;
                }
                //---------------------

                //по кресту
                else if (array[0, 0] == "x" && array[1, 1] == "x" && array[2, 2] == "x" || array[0, 0] == "o" && array[1, 1] == "o" && array[2, 2] == "o")
                {
                    return true;
                }

                else if (array[0, 2] == "x" && array[1, 1] == "x" && array[2, 0] == "x" || array[0, 2] == "o" && array[1, 1] == "o" && array[2, 0] == "o")
                {
                    return true;
                }

                else return false;
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//// Developer:
////██████╗░███████╗███╗░░░███╗░█████╗░░██████╗
////██╔══██╗██╔════╝████╗░████║██╔══██╗██╔════╝
////██████╦╝█████╗░░██╔████╔██║██║░░██║╚█████╗░
////██╔══██╗██╔══╝░░██║╚██╔╝██║██║░░██║░╚═══██╗
////██████╦╝███████╗██║░╚═╝░██║╚█████╔╝██████╔╝
////╚═════╝░╚══════╝╚═╝░░░░░╚═╝░╚════╝░╚═════╝░

//namespace bemostictactoe
//{
//    class tictactoe
//    {

//        private string[,] field =
//            {
//                {"0.0", "0.1", "0.2",},
//                {"1.0", "1.1", "1.2",},
//                {"2.0", "2.1", "2.2",}
//            };

//        public void Game()
//        {
//            Show(field);

//            int player = 1;

//            bool isTrue = false;

//            for (int i = 1; i < 6; i++)
//            {
//                if (player == 1)
//                {
//                link1:
//                    Console.WriteLine("Ход крестика:");
//                    Console.Write("Введите первое число -> ");
//                    int y = Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Введите второе число -> ");
//                    int x = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine();

//                    if (field[y, x] != "o")
//                    {
//                        field[y, x] = "x";
//                    }
//                    else goto link1;

//                    player *= -1;

//                    Show(field);
//                    isTrue = CheckX(field);

//                    if (isTrue == true)
//                    {
//                        Console.WriteLine("\tКрестик выйграл :)");
//                        break;
//                    }
//                }

//                if (player == -1)
//                {
//                link2:
//                    Console.WriteLine("Ход Нолика:");
//                    Console.WriteLine();
//                    Console.Write("Введите первое число -> ");
//                    int y = Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Введите второе число -> ");
//                    int x = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine();

//                    if (field[y, x] != "x")
//                    {
//                        field[y, x] = "o";
//                    }
//                    else goto link2;

//                    player *= -1;

//                    Show(field);
//                    isTrue = isTrue = CheckO(field);

//                    if (isTrue == true)
//                    {
//                        Console.WriteLine("\tНолик выйграл :)");
//                        break;
//                    }
//                }
//            }

//            static void Show(string[,] array)
//            {
//                Console.WriteLine("");

//                for (int i = 0; i < array.GetLength(0); i++)
//                {
//                    for (int j = 0; j < array.GetLength(1); j++)
//                    {
//                        Console.Write("\t" + array[i, j]);
//                    }
//                    Console.WriteLine("\n");
//                }
//            }

//            static void Replace(string[,] array, string input)
//            {
//                Console.WriteLine("");

//                for (int i = 0; i < array.GetLength(0); i++)
//                {
//                    for (int j = 0; j < array.GetLength(1); j++)
//                    {
//                        if (array[i, j] == input)
//                        {
//                            array[i, j] = input;
//                        }
//                    }
//                }
//            }

//            static bool CheckX(string[,] array)
//            {
//                //Крестики по горизонтали
//                if (array[0, 0] == "x" && array[0, 1] == "x" && array[0, 2] == "x")
//                {
//                    return true;
//                }

//                else if (array[1, 0] == "x" && array[1, 1] == "x" && array[1, 2] == "x")
//                {
//                    return true;
//                }

//                else if (array[2, 0] == "x" && array[2, 1] == "x" && array[2, 2] == "x")
//                {
//                    return true;
//                }
//                //---------------------

//                //Крестики по вертикали
//                else if (array[0, 0] == "x" && array[1, 0] == "x" && array[2, 0] == "x")
//                {
//                    return true;
//                }

//                else if (array[0, 1] == "x" && array[1, 1] == "x" && array[2, 1] == "x")
//                {
//                    return true;
//                }

//                else if (array[0, 2] == "x" && array[1, 2] == "x" && array[2, 2] == "x")
//                {
//                    return true;
//                }
//                //---------------------

//                //Крестики по кресту
//                else if (array[0, 0] == "x" && array[1, 1] == "x" && array[2, 2] == "x")
//                {
//                    return true;
//                }

//                else if (array[0, 2] == "x" && array[1, 1] == "x" && array[2, 0] == "x")
//                {
//                    return true;
//                }

//                else return false;
//            }

//            static bool CheckO(string[,] array)
//            {
//                //Крестики по горизонтали
//                if (array[0, 0] == "o" && array[0, 1] == "o" && array[0, 2] == "o")
//                {
//                    return true;
//                }

//                else if (array[1, 0] == "o" && array[1, 1] == "o" && array[1, 2] == "o")
//                {
//                    return true;
//                }

//                else if (array[2, 0] == "o" && array[2, 1] == "o" && array[2, 2] == "o")
//                {
//                    return true;
//                }
//                //---------------------

//                //Крестики по вертикали
//                else if (array[0, 0] == "o" && array[1, 0] == "o" && array[2, 0] == "o")
//                {
//                    return true;
//                }

//                else if (array[0, 1] == "o" && array[1, 1] == "o" && array[2, 1] == "o")
//                {
//                    return true;
//                }

//                else if (array[0, 2] == "o" && array[1, 2] == "o" && array[2, 2] == "o")
//                {
//                    return true;
//                }
//                //---------------------

//                //Крестики по кресту
//                else if (array[0, 0] == "o" && array[1, 1] == "o" && array[2, 2] == "o")
//                {
//                    return true;
//                }

//                else if (array[0, 2] == "x" && array[1, 1] == "o" && array[2, 0] == "o")
//                {
//                    return true;
//                }

//                else return false;
//            }
//        }
//    }
//}
