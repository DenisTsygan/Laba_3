using System;

namespace Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 952");
            Task_952();
            Console.WriteLine(" --------------------------------------------------------------");

            Console.WriteLine("TASK 959");
            Task_959();
            Console.WriteLine(" --------------------------------------------------------------");

            Console.WriteLine("TASK 978");
            Task_978();
            Console.WriteLine(" --------------------------------------------------------------");

            Console.WriteLine("TASK 1015");
            Task_1015();
            Console.WriteLine(" --------------------------------------------------------------");

        }
        /// <summary>
        /// Составить программу, которая проводит замену всех элементов:
        ///а) некоторой строки Двумерного массива заданным числом;
        ///б) некоторого столбца Двумерного массива заданным числом.
        /// </summary>
        private static void Task_952()
        {
            int rows = RandomGenerator.getRandomIntegerValue(1,20);
            int columns = RandomGenerator.getRandomIntegerValue(1, 20);
            Console.WriteLine("rows= "+ rows+ " ; colums="+ columns+" ;");
            int[,] array = RandomGenerator.getRandomIntegersArray(rows,columns);
            Console.WriteLine("Init array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            int indexRow = RandomGenerator.getRandomIntegerValue(0, rows-1);
            Console.WriteLine("a) Index any row= " + indexRow);

            int rundomNumber = RandomGenerator.getRandomIntegerValue(0, 100);
            Console.WriteLine("Random number = " + rundomNumber);

            for (int i = 0; i < columns; i++)
            {
                array[indexRow, i] = rundomNumber;
            }
            Console.WriteLine("Array after:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            int indexColumn = RandomGenerator.getRandomIntegerValue(0, columns - 1);

            Console.WriteLine("б) Index any column= " + indexColumn);

            rundomNumber = RandomGenerator.getRandomIntegerValue(0, 100);
            Console.WriteLine("Random number = " + rundomNumber);

            for (int i = 0; i < rows; i++)
            {
                array[i,indexColumn] = rundomNumber;
            }
            Console.WriteLine("Array after:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// В Двумерном массиве хранится информация о количестве учеников в каждом классе каждого потока школы с первого по
        /// одиннадцатый (в первой строке — информация о первых классах, во второй — о вторых классах и т. д.). 
        /// В каждом потоке школы имеются четыре класса. Определить общее число учеников 5-х классов.
        /// </summary>
        private static void Task_959()
        {
            int rows = 11;
            int columns = 4;
            Console.WriteLine("rows= " + rows + " ; colums=" + columns + " ;");
            int[,] array = RandomGenerator.getRandomIntegersArray(rows, columns);
            Console.WriteLine("info about the number of students in each class of each stream of the school:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            int sumStudentsSomeClass = 0;
            int indexClass = 5;
            for (int i = 0; i < columns; i++)
            {
                sumStudentsSomeClass+= array[indexClass - 1, i];
            }
            Console.WriteLine("Total number of 5th class students = " + sumStudentsSomeClass);
        }
        /// <summary>
        /// Дана вещественная квадратная матрица порядка 2n. Получить новую матрицу, 
        /// переставляя ее блоки размера n × n крест-накрест.
        /// </summary>
        private static void Task_978()
        {
            int n = 3;
            float[,] array = RandomGenerator.getRandomRealsArray(n);
            Console.WriteLine("Init array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            int size = array.GetLength(0); 
            float[,] resultMatrix = new float[size, size];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(i + n<size && j + n < size)
                    {
                        resultMatrix[i + n, j + n] = array[i, j];
                        resultMatrix[i, j] = array[i + n, j + n];
                    }
                    else
                    {
                        resultMatrix[i+n,  j-n] = array[i, j];
                        resultMatrix[i, j] = array[i+n, j - n];
                            
                    }
                }
            }
            Console.WriteLine("Array after:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write($"{resultMatrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Определить, является ли заданная матрица ортонормированной, 
        /// то есть равно ли скалярное произведение каждой пары разных строк (столбцов) нулю.
        /// </summary>
        private static void Task_1015()
        {
            int rows = 4;
            int columns = 4;

            Console.WriteLine("rows= " + rows + " ; colums=" + columns + " ;");
            int[,] array = RandomGenerator.getRandomIntegersArray(rows, columns);
            //int[,] array = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            //int[,] array = { { 1, -2, }, { 2, -1 } };

            Console.WriteLine("Init array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            int scalarProductVertical = 0;
            int scalarProductHorizont = 0;

            bool isOrtogonalnaya = true;
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0 ,switchRow=0; k <rows && switchRow<rows-1; k++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i + 1 < rows)
                        {
                            if (k == rows - 1-switchRow)
                            {
                                switchRow++;
                                k = 0;
                                if(switchRow == rows - 1)
                                {
                                   goto EndFor;
                                }
                            }
                            //Horizontal (ниже можно посмотреть скалярное произведение каких векторов расчитываем)
                            //Console.WriteLine($"array[{i + switchRow}, {j}]={array[i + switchRow, j]}   |  array[{i + 1 + k + switchRow},{ j}] = {array[i + 1 + k + switchRow, j]}");
                            scalarProductHorizont += array[i + switchRow, j] * array[i + 1 + k + switchRow, j];
                            
                            //Vertical
                            //Console.WriteLine($"array[{j},{i+switchRow}]= {array[j, i + switchRow] }  |  array[{j},{ i + 1+k+switchRow}] = {array[j, i + 1+k+switchRow]}");
                            scalarProductVertical += array[j, i + switchRow] * array[j, i + 1 + k + switchRow];
                        }
                        if (j == columns - 1)
                        {
                            //Console.WriteLine("CHECK:");
                            //Console.WriteLine("scalarProductHorizont=" + scalarProductHorizont);
                            //Console.WriteLine("scalarProductHorizont=" + scalarProductVertical);
                            if (scalarProductHorizont != 0 || scalarProductVertical != 0)
                            {
                                isOrtogonalnaya = false;
                                goto EndFor;
                            }
                        }
                    }
                }
            }
            EndFor:
            if (isOrtogonalnaya)
            {
                Console.WriteLine("Its ortogonalnaya matrix");
            }
            else
            {
                Console.WriteLine("Its not ortogonalnaya matrix");
            }
        }
        private class RandomGenerator
        {
            private static Random random = new Random();
            /// <summary>
            /// Генерация двумерного массива с рандомными вещественными числами от 0 до 100 порядка 2*n
            /// </summary>
            /// <param name="n">порядок матрицы</param>
            public static float[,] getRandomRealsArray(int n)
            {
                int rows = 2 * n;
                float[,] arr = new float[rows, rows];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        arr[i, j] = (float)random.NextDouble() * 100;
                    }
                }
                return arr;
            }
            /// <summary>
            /// Генерация двумерного массива с рандомными целочисленными числами 
            /// </summary>
            /// <param name="rows">количевство строк в двумерном массиве</param>
            /// <param name="columns">количевство столбцов в двумерном массиве</param>
            /// 
            public static int[,] getRandomIntegersArray(int rows, int columns)
            {
                int[,] arr = new int[rows,columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        arr[i, j] = random.Next(1, 100);
                    }
                }
                return arr;
            }
            
            /// <summary>
            /// Генерация рандомного целочисленного числа от minValue до maxValue
            /// </summary>
            /// <param name="minValue">максимальное значение генерации</param>
            /// <param name="maxValue">минимальное значение генерации</param>
            /// <returns></returns>
            public static int getRandomIntegerValue(int minValue,int maxValue)
            {
                return random.Next(minValue,maxValue) ;
            }
        }
    }
}
