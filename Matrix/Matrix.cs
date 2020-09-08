﻿using System;

namespace Matrix
{
    public class Matrix
    {
        private double[,] Data { get; }

        public Matrix(double[,] data, int rows, int columns)
        {
            this.Data = data;
            Rows = rows;
            Columns = columns;
        }
        
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = new double[rows, columns];
        }

        private int Rows { get; }

        private int Columns { get; }

 
        public double this[int i, int j]
        {
            set
            {
                Data[i,j] = value;
            }
            get
            {
                return Data[i,j];
            }
            
        }

        public void Print()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++) Console.Write(Data[i, j] + " ");

                Console.WriteLine();
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            var result = new Matrix(a.Rows, b.Columns);

            for (var i = 0; i < a.Rows; ++i)
            {
                for (var j = 0; j < b.Columns; ++j)
                {
                    for (var k = 0; k < a.Columns; ++k)
                    {
                        result[i,j] += a[i,k] * b[k,j];
                    }
                }
            }

            return result;
        }
    }
}