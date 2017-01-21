using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mult_rownania
{
    class Matrix
    {
        public float[,] matrix;

        public Matrix(float[,] arr)
        {
            matrix = arr;
        }

        public void showMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("[" + (i + 1) + "," + (j + 1) + "]= ");
                    Console.WriteLine(matrix[i, j]);
                }
            }
        }

        public void swap_rows(int r_base, int r_calc)
        {
            float temp;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                temp = matrix[r_base, i];
                matrix[r_base, i] = matrix[r_calc, i];
                matrix[r_calc, i] = temp;
            }
        }

        public void first_to_one(int r_base)
        {
            float div = matrix[r_base, r_base];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[r_base, i] = matrix[r_base, i] / div;
            }
        }

        public void calculate(int r_base, int r_calc )
        {
            float calc_base = matrix[r_calc, r_base];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[r_calc,i] = matrix[r_calc,i] - calc_base * matrix[r_base,i];
            }
        }

        public void showResult()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + matrix[i, matrix.GetLength(0)]);
            }
        }
     }
}
