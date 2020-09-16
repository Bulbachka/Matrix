using System;

namespace Matrix
{
    public class Matrix
    {
        private double[,] Data { get; set; }

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

        private int Rows { get; set; }

        private int Columns { get; set; }

        public static Matrix Transposition(Matrix m)
        {
            Matrix result = new Matrix(m.Columns, m.Rows);
            
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = m[j, i];
                }
            }

            return result;
        }
        
        public Matrix Transposition()
        {
            double[,] result = new double[Columns,Rows];
            
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    result[i, j] = Data[j, i];
                }
            }

            Data = result;
            int temp = Rows;
            Rows = Columns;
            Columns = temp;

            return this;
        }
 
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

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Columns != b.Columns && a.Rows != b.Rows)
            {
                throw new Exception("non-folding matrices");
            }
            
            var result = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }
        
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new Exception("non-multipliable matrices");
            }

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