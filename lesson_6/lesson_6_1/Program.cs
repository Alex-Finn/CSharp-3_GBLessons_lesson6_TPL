using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//   1. Даны 2 двумерных матрицы.Размерность 100х100 каждая. Напишите приложение,
//      производящее параллельное умножение матриц. Матрицы заполняются случайными целыми
//      числами от 0 до 10.

namespace lesson_6_1
{
    class Program
    {
        static Random rnd = new Random();
        //class Matrix
        //{
        //    private readonly int vertDimension = 100;
        //    private readonly int horizDimension = 100;

        //    public int VertDimension
        //    {
        //        get => vertDimension;
        //    }
        //    public int HorizDimension
        //    {
        //        get => horizDimension;
        //    }

        //    public Matrix()
        //    {
                
        //    }


        //    public void ShowMatrix()
        //    {

        //    }
        //}

        static void Main(string[] args)
        {            
            int dimension = 500;
            int[,] first = new int[dimension, dimension];
            int[,] second = new int[dimension, dimension];
            int[,] result = new int[dimension, dimension];

            DateTime dt = new DateTime();
            
            MakeMatrix(first, dimension);
            MakeMatrix(second, dimension);

            //DrawMatrix(first, dimension);
            //DrawMatrix(second, dimension);

            dt = DateTime.Now;
            Console.WriteLine("Запущено синхронное перемножение");
            MultiplyMatrixes(first, second, dimension, ref result);
            Console.WriteLine("Синхронное перемножение завершено");
            Console.WriteLine("Прошло времени: " + (DateTime.Now - dt));

            dt = DateTime.Now;
            Console.WriteLine("Запущено параллельное перемножение");
            Task.Factory.StartNew(()=>MultiplyMatrixes(first, second, dimension, ref result));
            Console.WriteLine("Параллельное перемножение завершено");
            Console.WriteLine("Прошло времени: " + (DateTime.Now - dt));

            //DrawMatrix(result, dimension);


            Console.ReadKey();
        }   
        
        public static void MakeMatrix(int[,] inputMatrix, int dimension)
        {            
            for (int i = 0; i < dimension; ++i)
            {
                for (int j = 0; j < dimension; ++j)
                {
                    inputMatrix[i, j] = rnd.Next(0, 11);
                }
            }
        }

        public static void DrawMatrix(int[,] inputMatrix, int dimension)
        {
            for (int i = 0; i < dimension; ++i)
            {
                for (int j = 0; j < dimension; ++j)
                {
                    Console.Write($"{ inputMatrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void MultiplyMatrixes(int[,] first, int[,] second, int dimension, ref int[,] result)
        {
            for (int i = 0; i < dimension; ++i)
            {
                for (int j = 0; j < dimension; ++j)
                {
                    for (int k = 0; k < dimension; ++k)
                    {
                        result[i, j] += first[i, k] * second[k, j];
                    }                    
                }
            }
        }

        //public static void MultyParalel(int[,] first, int[,] second, int dimension, ref int[,] result)
        //{
        //    for (int i = 0; i < dimension; ++i)
        //    {
        //        for (int j = 0; j < dimension; ++j)
        //        {
        //            for (int k = 0; k < dimension; ++k)
        //            {
        //                result[i, j] += first[i, k] * second[k, j];
        //            }                    
        //        }
        //    }
        //}
    }
}
