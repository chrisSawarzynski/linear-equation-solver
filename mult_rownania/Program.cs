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
            
            n = int.Parse(Console.ReadLine());

            float[,] array = new float[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n+1; j++)
                {
                    Console.Write("["+(i+1)+","+(j+1)+"]= ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Matrix matrix = new Matrix(array);

            //matrix.showMatrix();

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
                    if(i!=j)
                    {
                        //(new Thread(() => { matrix.calculate(i, j); })).Start();
                        //Mutex.WaitAll();
                        matrix.calculate(i, j);
                    }
                }
            }

            /*matrix.first_to_one(0);

            matrix.showMatrix();

            matrix.calculate(0, 1);

            matrix.showMatrix();

            matrix.first_to_one(1);

            matrix.showMatrix();

            matrix.calculate(1, 0);*/

            //matrix.showMatrix();

            matrix.showResult();

            Console.ReadLine();
        }
    }
}
