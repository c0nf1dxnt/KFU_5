using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Part1
{
    class Program
    {
        static void CountLetters(out int vowelLetters, out int consonantLetters, char[] lettersArray)
        {
            vowelLetters = 0; consonantLetters = 0;
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            foreach (char letter in lettersArray)
            {
                if (vowels.Contains(letter))
                {
                    vowelLetters++;
                }
                else
                {
                    consonantLetters++;
                }
            }
        }
        static void FillMatrix(int[,] matrix)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(100);
                }
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int[,] MultiplyMatrices(int[,] firstMatrix, int[,] secondMatrix)
        {
            int[,] resultMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < secondMatrix.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
            return resultMatrix;
        }
        static double[] CalculateAverageMonthlyTemperature(int[,] array)
        {
            double[] averageMonthlyTemperature = new double[12];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    averageMonthlyTemperature[i] += array[i, j];
                }
                averageMonthlyTemperature[i] /= 30;
            }
            return averageMonthlyTemperature;
        }
        static LinkedList<LinkedList<int>> FillMatrix(int lines, int columns)
        {
            Random random = new Random();
            LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < lines; i++)
            {
                LinkedList<int> line = new LinkedList<int>();
                for (int j = 0; j < columns; j++)
                {
                    line.AddLast(random.Next(100));
                }
                matrix.AddLast(line);
            }
            return matrix;
        }
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (LinkedList<int> line in matrix)
            {
                foreach (int element in line)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> matrix1, LinkedList<LinkedList<int>> matrix2)
        {
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();
            foreach (LinkedList<int> row1 in matrix1)
            {
                LinkedList<int> newRow = new LinkedList<int>();
                for (int j = 0; j < matrix2.First.Value.Count; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.First.Value.Count; k++)
                    {
                        sum += row1.ElementAt(k) * matrix2.ElementAt(k).ElementAt(j);
                    }
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
            }
            return result;
        }
        static void CountLetters(out int vowelLetters, out int consonantLetters, List<char> lettersList)
        {
            vowelLetters = 0; consonantLetters = 0;
            List<char> vowels = new List<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            foreach (char letter in lettersList)
            {
                if (vowels.Contains(letter))
                {
                    vowelLetters++;
                }
                else
                {
                    consonantLetters++;
                }
            }
        }
        static void Task1(string[] args)
        {
            Console.WriteLine("Задание №1:\nПосчитать количество гласных и согласных букв в файле, имя которого передаётся как аргумент в функцию Main()\n");
            FileInfo textFile = new FileInfo(args[0]);
            char[] lettersArray = File.ReadAllText(args[0]).ToLower().ToCharArray();
            CountLetters(out int vowelLetters, out int consonantLetters, lettersArray);
            Console.WriteLine($"В текстовом файле {textFile.Name}, находится {vowelLetters} гласных(-ая) букв и {consonantLetters} согласных(-ая) букв\n");
        }
        static void Task2()
        {
            Console.WriteLine("Задание №2:\nПеремножить матрицы, предусмотреть два метода: метод печати матрицы и метод умножения матриц\n");

            Console.Write("Введите длину первой матрицы: ");
            string inputString1 = Console.ReadLine();
            Console.Write("Введите ширину первой матрицы: ");
            string inputString2 = Console.ReadLine();

            if (int.TryParse(inputString1, out int firstMatrixLength) && int.TryParse(inputString2, out int firstMatrixWidth))
            {
                int[,] firstMatrix = new int[firstMatrixLength, firstMatrixWidth];

                FillMatrix(firstMatrix);
                Console.WriteLine($"Сгенерированная матрица {firstMatrix.GetLength(0)} x {firstMatrix.GetLength(1)}: ");
                PrintMatrix(firstMatrix);

                Console.Write("Введите длину первой матрицы: ");
                string inputString3 = Console.ReadLine();
                Console.Write("Введите ширину первой матрицы: ");
                string inputString4 = Console.ReadLine();

                if (int.TryParse(inputString3, out int secondMatrixLength) && int.TryParse(inputString4, out int secondMatrixWidth))
                {
                    int[,] secondMatrix = new int[secondMatrixLength, secondMatrixWidth];

                    FillMatrix(secondMatrix);
                    Console.WriteLine($"Сгенерированная матрица {secondMatrix.GetLength(0)} x {secondMatrix.GetLength(1)}: ");
                    PrintMatrix(secondMatrix);

                    if (firstMatrixWidth == secondMatrixLength)
                    {
                        Console.WriteLine("Результат перемножения матриц:");
                        PrintMatrix(MultiplyMatrices(firstMatrix, secondMatrix));
                    }
                    else
                    {
                        Console.WriteLine("Невозможно перемножить матрицы, кол-во столбцов первой матрицы не равно кол-ву строк второй матрицы!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввлели не число или не целое число!\n");
                }
            }
            else
            {
                Console.WriteLine("Вы ввлели не число или не целое число!\n");
            }
        }
        static void Task3()
        {
            Console.WriteLine("Задание №3:\nНаписать программу, вычисляющую среднюю температуру за год. Написать метод, вычисляющий и возвращающий среднюю температуру в нём\n");
            int[,] temperature = new int[12, 30];
            Random random = new Random();
            double averageYearTemperature = 0;
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = random.Next(-30, 30);
                    averageYearTemperature += temperature[i, j];
                }
            }
            averageYearTemperature /= temperature.GetLength(0);
            double[] averageMonthlyTemperature = CalculateAverageMonthlyTemperature(temperature);
            Console.WriteLine($"Среднегодовая температура: {averageYearTemperature:0.00}");
            for (int i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"Температура в январе: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 1:
                        Console.WriteLine($"Температура в феврале: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 2:
                        Console.WriteLine($"Температура в марте: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 3:
                        Console.WriteLine($"Температура в апреле: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 4:
                        Console.WriteLine($"Температура в мае: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 5:
                        Console.WriteLine($"Температура в июне: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 6:
                        Console.WriteLine($"Температура в июле: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 7:
                        Console.WriteLine($"Температура в августе: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 8:
                        Console.WriteLine($"Температура в сентябре: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 9:
                        Console.WriteLine($"Температура в октябре: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 10:
                        Console.WriteLine($"Температура в ноябре: {averageMonthlyTemperature[i]:0.00}");
                        break;
                    case 11:
                        Console.WriteLine($"Температура в декабре: {averageMonthlyTemperature[i]:0.00}\n");
                        break;
                }
            }
            Array.Sort(averageMonthlyTemperature);
        }
        static void Task4(string[] args)
        {
            Console.WriteLine("Задание №4:\nПосчитать количество гласных и согласных букв в файле, имя которого передаётся как аргумент в функцию Main().\nИспользовать коллекцию List<T>\n");
            FileInfo textFile = new FileInfo(args[0]);
            List<char> lettersList = new List<char>(File.ReadAllText(args[0]).ToLower().ToCharArray());
            CountLetters(out int vowelLetters, out int consonantLetters, lettersList);
            Console.WriteLine($"В текстовом файле {textFile.Name}, находится {vowelLetters} гласных(-ая) букв и {consonantLetters} согласных(-ая) букв\n");
        }
        static void Task5()
        {
            Console.WriteLine("Задание №5:\nПеремножить матрицы, предусмотреть два метода: метод печати матрицы и метод умножения матриц.\nИспользовать коллекцию LinkedList<LinkedList<T>>\n");

            Console.Write("Введите длину первой матрицы: ");
            string inputString1 = Console.ReadLine();
            Console.Write("Введите ширину первой матрицы: ");
            string inputString2 = Console.ReadLine();

            if (int.TryParse(inputString1, out int firstMatrixLength) && int.TryParse(inputString2, out int firstMatrixWidth))
            {
                LinkedList<LinkedList<int>> firstMatrix = FillMatrix(firstMatrixLength, firstMatrixWidth);
                Console.WriteLine($"Сгенерированная матрица {firstMatrixLength} x {firstMatrixWidth}: ");
                PrintMatrix(firstMatrix);

                Console.Write("Введите длину первой матрицы: ");
                string inputString3 = Console.ReadLine();
                Console.Write("Введите ширину первой матрицы: ");
                string inputString4 = Console.ReadLine();

                if (int.TryParse(inputString3, out int secondMatrixLength) && int.TryParse(inputString4, out int secondMatrixWidth))
                {
                    LinkedList<LinkedList<int>> secondMatrix = FillMatrix(secondMatrixLength, secondMatrixWidth);
                    Console.WriteLine($"Сгенерированная матрица {secondMatrixLength} x {secondMatrixWidth}: ");
                    PrintMatrix(secondMatrix);

                    if (firstMatrixWidth == secondMatrixLength)
                    {
                        Console.WriteLine("Результат перемножения матриц:");
                        PrintMatrix(MultiplyMatrices(firstMatrix, secondMatrix));
                    }
                    else
                    {
                        Console.WriteLine("Невозможно перемножить матрицы, кол-во столбцов первой матрицы не равно кол-ву строк второй матрицы!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввлели не число или не целое число!\n");
                }
            }
            else
            {
                Console.WriteLine("Вы ввлели не число или не целое число!\n");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Skynet";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Task1(args);
            Task2();
            Task3();
            Task4(args);
            Task5();

            Console.ReadKey();
        }
    }
}
