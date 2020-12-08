using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Threading;

namespace LR5OAIP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вариант 31
            Console.WriteLine("Файл input находится в @/LR5OAIP/LR5OAIP/bin/Debug");
            Console.WriteLine("Файл output.txt находится в @/LR5OAIP/LR5OAIP/bin/Debug");
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);
            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("*** Вывод матрицы ***");

            // Вывод данных из исходной матрицы
            int[,] mas = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                String str_all = Console.ReadLine();
                string[] str_elem = str_all.Split(' ');
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Сумма элементов для каждой строки
            Console.WriteLine("***Сумма элементов каждой строки***");
            int[] sum = new int[M];
            for (int i = 0; i < N; i++)
            {
                int summary = 0;
                for (int j = 0; j < M; j++)
                {
                    summary += mas[i, j];
                }
                sum[i] = summary;
                Console.Write(sum[i] + " ");
            }
            Console.WriteLine();

            // Модифицированная  матрица, 
            //в  которой  элементы  большие  чем соответствующая  сумма  строки  заменены  на +, 
            //меньшие –на -,а остальные элементы –без изменений
            Console.WriteLine("***Модифицированная матрица***");
            for (int k = 0; k < N; k++)
            {
                for(int p = 0; p < M; p++)
                {
                    if (mas[p, k] < sum[k])
                    {
                        Console.Write("- ");
                    }
                    else if (mas[p, k] > sum[k])
                    {
                        Console.Write("+ ");
                    }
                    else
                    {
                        Console.Write(mas[p, k] + " ");
                    }
                }
                Console.WriteLine();
            }


            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
            Console.WriteLine();
            Console.WriteLine("Расчеты были завершены, нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
        }
    }
}