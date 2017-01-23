using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mult_rownania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Random random = new Random();
            List<Task> tasks = new List<Task>();

            Console.Write("Podaj liczbę niewiadomych: ");
            n = int.Parse(Console.ReadLine());

            float[,] array = new float[n, n + 1];

            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine((i + 1) + ". równanie:");
                for (int j = 0; j < n+1; j++)
                {
                    //Console.Write("["+(i+1)+","+(j+1)+"]= ");
                    /*if (j != n)
                        Console.Write("Współczynnik przy x" + (j + 1) + "= ");
                    else
                        Console.Write("Wyraz wolny= ");
                    array[i, j] = int.Parse(Console.ReadLine());*/
                    array[i, j] = random.Next(0,100);
                }
            }

            Matrix matrix = new Matrix(array);

            //matrix.showMatrix();
            DateTime time = DateTime.Now;
            
            for (int i = 0; i < n; i++)
            {
                if(matrix.matrix[i,i]==0)
                {
                    for (int j = i+1; j < n; j++)
                    {
                        if (matrix.matrix[j, i] != 0)
                            matrix.swap_rows(i, j);
                    }
                }
                    
                matrix.first_to_one(i);
                for (int j = 0; j < n; j++)
                {
                    //if(i!=j)
                    //{
                        int index_i = i;
                        int index_j = j;
                        tasks.Add( Task.Factory.StartNew(
                            () =>
                            {
                                matrix.calculate(index_i, index_j);
                            }));
                        //matrix.calculate(i, j);
                    //}
                }
                Task.WaitAll(tasks.ToArray());
                tasks.Clear();
            }
            DateTime time2 = DateTime.Now;
            Console.WriteLine(time - time2);

            Console.WriteLine();
            matrix.showResult();

            Console.ReadLine();

        }
    }
}
