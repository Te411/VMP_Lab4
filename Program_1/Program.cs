//Дан с клавиатуры двумерный массив значений из n строк. 
//Значения вводятся через пробел для каждой строки массива. 
//Между значениями могут быть лишние пробелы, а значения не всегда могут быть числовыми, 
//все значения которые невозможно конвертировать в число необходимо заменить нулем. 
//Реализовать методы для поиска минимального, максимального и суммы каждой строки массива. 
//Крайне важно — программа не должна критически завершаться! 
//При реализации методов необходимо использовать модификаторы ref, in, out.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_1
{
    internal class Program
    {
        static public void Print(in int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static public void Sum(in int[][] array, ref int[] sum)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[index] += array[i][j];
                }
                index++;
            }
        }

        static public void Min(in int[][] array, ref int[] minResult)
        {
            int index = 0;
            int min = 9999;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }
                minResult[index] = min;
                index++;
                min = 9999;
            }
        }

        static public void Max(in int[][] array, out int[] maxResult)
        {
            int max = -9999;
            maxResult = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }
                maxResult[i] = max;
                max = -9999;
            }
        }
        static void Main(string[] args)
        {
            int n = -1;
            Console.Write("Введи количество строк в матрице: ");
            do
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    while (n < 0)
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        n = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                    n = -1;
                }
            } while (n <= 0);
            int[] sumResult = new int[n];
            int[] minResult = new int[n];
            int[] maxResult = new int[] { };
            int[][] array = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите значения для строки {i + 1}");
                string input = Console.ReadLine();
                string[] values = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                array[i] = new int[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    int value = 0;
                    try
                    {

                        value = Convert.ToInt32(values[j]);
                    }
                    catch (FormatException)
                    {
                        value = 0;
                    }
                    finally
                    {
                        array[i][j] = value;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Матрица: ");
            Print(in array);
            Console.WriteLine();
            Sum(in array, ref sumResult);
            Console.WriteLine("Сумма: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1} строки: {sumResult[i]}");
            }
            Console.WriteLine();
            Min(in array, ref minResult);
            Console.WriteLine("Минимум: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1} строки: {minResult[i]}");
            }
            Console.WriteLine();
            Max(in array, out maxResult);
            Console.WriteLine("Максимум: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1} строки: {maxResult[i]}");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
