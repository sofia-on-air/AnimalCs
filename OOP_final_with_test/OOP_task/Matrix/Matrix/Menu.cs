using System;
using static OOP_task.Matrix.Matrix.NMatrix;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace OOP_task.Matrix.Matrix
{
    public class Menu
    {


        #region Attribute
        private NMatrix? matrix = null;
        #endregion



        public Menu() { }

        #region Menu operation

        private static void Menu_Print()
        {
            Console.WriteLine("\n********************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Get an element");
            Console.WriteLine("2. Print a matrix");
            Console.WriteLine("3. Add two matrices");
            Console.WriteLine("4. Multiply two matrices");
            Console.WriteLine("5. Set matrix");
            Console.WriteLine("Choose: ");
            Console.WriteLine("\n********************************");
        }



        #endregion

        public void Run()
        {
            int n;
            do
            {
                Menu_Print();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException) { n = -1; }
                switch (n)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    case 1:
                        getElement();
                        break;
                    case 2:
                        printMatrix(matrix);
                        break;
                    case 3:
                        sumMatrix();
                        break;
                    case 4:
                        multMatrix();
                        break;
                    case 5:
                        setMatrix();
                        break;
                    default:
                        Console.WriteLine("\nIncorrect input!");
                        break;
                }
            } while (n != 0);
        }

        private void setMatrix()
        {
            if (matrix != null)
            {
                Console.WriteLine("Matrix has already been set");
                return;
            }
            Console.WriteLine("Enter matrix size:");
            int size = 0;
            try
            {
                size = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException) { size = -1; }
            NMatrix temp_matrix = new NMatrix(size);
            if (initMatrix(temp_matrix))
            {
                matrix = new NMatrix(temp_matrix);
            }
        }

        private bool initMatrix(NMatrix m)
        {
            if (m == null)
            {
                Console.WriteLine("Matrix has not been set");
                return false;
            }

            try
            {
                NMatrix temp_matrix = new NMatrix(m.Size);
                for (int i = 0; i < m.Size; i++)
                {
                    Console.WriteLine("[" + i + ",0] = ");
                    try
                    {
                        int n = int.Parse(Console.ReadLine()!);
                        temp_matrix[i, 0] = n;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Should be integer");
                        return false;
                    }
                }
                for (int i = 0; i < m.Size - 2; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "," + (i + 1) + "]=");
                    try
                    {
                        int n = int.Parse(Console.ReadLine()!);
                        temp_matrix[i + 1, i + 1] = n;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Should be integer");
                        return false;
                    }
                }
                for (int i = 0; i < m.Size; i++)
                {
                    Console.WriteLine("[" + i + "," + (m.Size - 1) + "] = ");
                    try
                    {
                        int n = int.Parse(Console.ReadLine()!);
                        temp_matrix[i, m.Size - 1] = n;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Should be integer");
                        return false;
                    }
                }
                m.load(temp_matrix);
                printMatrix(m);
            }
            catch (NegativeSizeException)
            {
                Console.WriteLine("Incorrect size");
                return false;
            }
            return true;
        }

        private void printMatrix(NMatrix m)
        {
            if (m != null)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine("Matrix has not been set");
            }
        }

        private void getElement()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix has not been set");
                return;
            }
            int i = -1;
            Console.WriteLine("Write row number:");
            try
            {
                i = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Should be integer");
                return;
            }
            if (i >= matrix.Size)
            {
                Console.WriteLine("Incorrect insex");
                return;
            }
            int j = -1;
            Console.WriteLine("Write column number:");
            try
            {
                j = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Should be integer");
                return;
            }
            if (j >= matrix.Size)
            {
                Console.WriteLine("Incorrect insex");
                return;
            }
            Console.WriteLine(matrix[i, j]);
        }

        private void sumMatrix()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix has not been set");
                return;
            }
            NMatrix b = new NMatrix(matrix.Size);
            if (initMatrix(b))
            {
                Console.WriteLine("Result:");
                NMatrix result = matrix + b;
                printMatrix(result);
            }
        }
        private void multMatrix()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix has not been set");
                return;
            }
            NMatrix b = new NMatrix(matrix.Size);
            if (initMatrix(b))
            {
                Console.WriteLine("Result:");
                NMatrix result = matrix * b;
                printMatrix(result);
            }
        }

    }
}