//Написать класс – одномерный массив целых чисел. Учитывая следующие рекомендации:
//-создайте метод конструктор(), внутри которого будут определен один параметр: размер массива. Начальные значения свойства берутся из входных параметров метода.
//-	создайте метод InputData позволяющий задать данные массива пользователем
//-	создайте метод InputDataRandom заполняющий массив с помощью датчика случайных чисел
//-	создайте метод print() – вывод на экран содержимого массив из указанного диапазона индексов 
//-	создайте метод FindValue  - который возвращает список индексов для искомого элемента
//-	создайте метод DelValue  - который удаляет из массива (искомый элемент в массиве может встречаться несколько раз) искомый элемент.
//-создайте метод FindMax- который возвращает максимальное значение из массива.
//-	создайте метод Add который выполняет сложение двух массивов одинаковой длины поэлементно
// -  создайте метод Sort который выполняет сортировку элементов массива по возрастанию.
//Замечание – использование класса Array  -  запрещено
//Замечание - при реализации методов класса необходимо использовать модификаторы ref, in, out

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_3
{
    public class IntArray
    {
        private int size;
        private int[] array;
        public IntArray(int sizeArray)
        {
            size = sizeArray;
            array = new int[size];
        }

        public void InputData()
        {
            Console.WriteLine("Введите элементы массива: ");
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    number = 0;
                }
                finally
                {
                    array[i] = number;
                }
            }
        }

        public void InputDataRandom()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 25);
            }
            Console.WriteLine("Массив заполнен");
        }

        public void Print(IntArray arrayPrint)
        {
            for (int i = 0; i < arrayPrint.array.Length; i++)
            {
                Console.Write($"{arrayPrint.array[i]} ");
            }
            Console.WriteLine();
        }

        public void FindValue(in int findnumber)
        {
            string findnumberresult = "";
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == findnumber)
                {
                    findnumberresult += i + " ";
                    count++;
                }
            }
            if (count != 0)
            {
                Console.WriteLine("Индексы найденных элементов: ");
                for (int i = 0; i < findnumberresult.Length; i++)
                {
                    Console.WriteLine($"{findnumberresult[i]} ");
                }
            }
            else
            {
                Console.WriteLine("Элементы не найдены!");
            }
        }

        public void DelValue(in int deletenumber)
        {
            int count = 0;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == deletenumber)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Элементы для удаления не найдены!");
            }
            else
            {
                int[] tmpArray = new int[size - count];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != deletenumber)
                    {
                        tmpArray[index++] = array[i];
                    }
                }
                array = tmpArray;
                size = size - count;
                Console.WriteLine($"Элемент {deletenumber} удален из массива");
            }
        }

        public void FindMax(out int max)
        {
            max = -9999;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
        }

        public void Add(IntArray arrayTwo, ref IntArray arrayResult)
        {
            for (int i = 0; i < array.Length; i++)
            {
                arrayResult.array[i] = array[i] + arrayTwo.array[i];
            }
        }

        public void Sort()
        {
            int tmpNumber = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        tmpNumber = array[i];
                        array[i] = array[j];
                        array[j] = tmpNumber;
                    }
                }
            }
            Console.WriteLine("Массив отсортирован");
            Console.WriteLine();
        }
    }

    internal class Program_3
    {
        static void Main(string[] args)
        {
            sbyte x = -1;
            IntArray array1 = null;
            IntArray array2 = null;
            int size = 0;
            int findnumber = 0;
            int deletenumber = 0;
            int maxnumber = 0;
            do
            {
                do
                {
                    Console.WriteLine("Выберите режим работы:");
                    Console.WriteLine("1. Заполнить массив");
                    Console.WriteLine("2. Вывод массива");
                    Console.WriteLine("3. Поиск элемента в массиве");
                    Console.WriteLine("4. Удаление элемента из массива");
                    Console.WriteLine("5. Поиск максимального значения в массиве");
                    Console.WriteLine("6. Сложение двух массивов");
                    Console.WriteLine("7. Сортировка массива");
                    Console.WriteLine("0. Завершение работы");
                    try
                    {
                        x = Convert.ToSByte(Console.ReadLine());
                        while (x < 0)
                        {
                            Console.WriteLine("Такой команды нет!");
                            Console.WriteLine();
                            x = Convert.ToSByte(Console.ReadLine());
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        x = -1;
                    }
                    Console.WriteLine();
                } while (x < 0);

                switch (x)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Выберите как заполнить массив: ");
                            Console.WriteLine("1. Заполнить вручную");
                            Console.WriteLine("2. Заполнить случайно");
                            try
                            {
                                x = Convert.ToSByte(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                                x = -1;
                            }
                        } while (x != 1 && x != 2);
                        Console.WriteLine();

                        Console.WriteLine("Выберите размер массива: ");
                        size = 0;
                        do
                        {
                            try
                            {
                                size = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                                size = -1;
                            }
                        } while (size < 0);

                        array1 = new IntArray(size);
                        switch (x)
                        {
                            case 1:
                                array1.InputData();
                                Console.WriteLine();
                                break;
                            case 2:
                                array1.InputDataRandom();
                                Console.WriteLine();
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("Элементы массива: ");
                        array1.Print(array1);
                        Console.WriteLine();
                        break;
                    case 3:

                        Console.Write("Введите элемент, который нужно найти в массиве: ");
                        try
                        {
                            findnumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        }

                        array1.FindValue(in findnumber);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Введите элемент, который нужно удалить из массива: ");
                        try
                        {
                            deletenumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        }

                        array1.DelValue(in deletenumber);
                        Console.WriteLine();
                        break;
                    case 5:
                        array1.FindMax(out maxnumber);
                        Console.Write($"Максимальный элемент в массиве: {maxnumber}");
                        Console.WriteLine("\n");
                        break;
                    case 6:
                        do
                        {
                            Console.WriteLine("Выберите как заполнить массив: ");
                            Console.WriteLine("1. Заполнить вручную");
                            Console.WriteLine("2. Заполнить случайно");
                            try
                            {
                                x = Convert.ToSByte(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                                x = -1;
                            }
                        } while (x != 1 && x != 2);
                        Console.WriteLine();

                        array2 = new IntArray(size);
                        switch (x)
                        {
                            case 1:
                                array2.InputData();
                                Console.WriteLine();
                                break;
                            case 2:
                                array2.InputDataRandom();
                                Console.WriteLine();
                                break;
                        }

                        IntArray arrayResult = new IntArray(size);
                        array1.Add(array2, ref arrayResult);
                        Console.Write("Массив, полученный после сложения двух массивов: ");
                        arrayResult.Print(arrayResult);
                        break;
                    case 7:
                        array1.Sort();
                        break;
                    default:
                        Console.WriteLine("Такой команды нет!");
                        Console.WriteLine();
                        break;

                }
            } while (x != 0);
        }
    }
}
