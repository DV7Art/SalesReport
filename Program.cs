using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal plan;
            {
                Console.Write("Введите план продаж: ");
                plan = Convert.ToDecimal(Console.ReadLine());
            }

            string[] surnamesArray;
            {
                Console.WriteLine("Введите фамии сотрудников через запятую: ");
                string surnames = Console.ReadLine();
                surnamesArray = surnames.Split(',');

                for (int i = 0; i < surnamesArray.Length; i++)
                    surnamesArray[i] = surnamesArray[i].Trim();

            }

            decimal[][] jaggedArray;
            {
                jaggedArray = new decimal[surnamesArray.Length][];

                for (int i = 0; i < surnamesArray.Length; i++)
                {
                    Console.WriteLine($"Введите через запятую суммы продаж которые совершил {surnamesArray[i]}");
                    string sums = Console.ReadLine();
                    string[] sumsArray = sums.Split(',');
                    jaggedArray[i] = new decimal[sumsArray.Length];

                    for (int j = 0; j < sumsArray.Length; j++)
                    {
                        string sum = sumsArray[j].Trim();
                        jaggedArray[i][j] = Convert.ToDecimal(sum);
                    }
                }
            }

            decimal[] totalSumsArray;
            {
                totalSumsArray = new decimal[jaggedArray.Length];

                for (int i = 0; i < totalSumsArray.Length; i++)
                {
                    decimal totalSum = 0;

                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        totalSum += jaggedArray[i][j];
                    }

                    totalSumsArray[i] = totalSum;
                }
            }

            //Формирование отчета кто и насколько % выполнил план
            {
                for (int i = 0; i < totalSumsArray.Length; i++)
                {
                    Console.Write($"{surnamesArray[i]} продал товара на сумму {totalSumsArray[i]} грн. ");
                    decimal percent;

                    if (totalSumsArray[i] < plan)
                    {
                        percent = (plan - totalSumsArray[i]) / (plan / 100);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"План недовыполнен на {percent} %");
                        Console.ResetColor();
                    }
                    else if (totalSumsArray[i] == plan)
                    {
                        Console.WriteLine("План выполнен на 100 %");
                    }
                    else if (totalSumsArray[i] > plan)
                    {
                        percent = (totalSumsArray[i] - plan) / (plan / 100);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"План перевыполнен на {percent} %");
                        Console.ResetColor();
                    }
                }
            }

            //Формирование отчета о мин и макс продаже для каждого сейла
            {
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    Array.Sort(jaggedArray[i]);
                    int lastIndex = jaggedArray[i].Length - 1;
                    Console.WriteLine($"{surnamesArray[i]}: Мин. продажа = {jaggedArray[i][0]}, Макс. продажа {jaggedArray[i][lastIndex]} ");
                }
            }

            //Delay
            Console.ReadKey();
        }
    }
}
