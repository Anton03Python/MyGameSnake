using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameSnake
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            int width = 20;
            int height = 10;

            while (true)
            {
                int[,] my = new int[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {

                        //if (rand.Next(100) > 70)
                            //my[i, j] = (int)Figures.Barrier;
                        //else
                            my[i, j] = (int)Figures.EmptySpace;
                    }
                }
                var random = new Random(unchecked((int)DateTime.Now.Millisecond));
                my[random.Next(height), random.Next(width)] = (int)Figures.StartPosition;
                my[random.Next(height), random.Next(width)] = (int)Figures.Destination;
               // Print(my);

                var li = new LeeAlgorithm(my);
                Console.WriteLine(li.PathFound);
                if (li.PathFound)
                {
                    foreach (var item in li.Path)
                    {
                        if (item == li.Path.Last())
                            my[item.Item1, item.Item2] = (int)Figures.StartPosition;
                        else if (item == li.Path.First())
                            my[item.Item1, item.Item2] = (int)Figures.Destination;
                        else
                            my[item.Item1, item.Item2] = (int)Figures.Path;
                    }
                    //Print(li.ArrayGraph);
                    Console.WriteLine("Длина " + li.LengthPath);
                }
                else
                    Console.WriteLine("Путь не найден");
                Console.ReadLine();
            }
    
        }
    }
    
}

