//using Matrix;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using TextFIle;

namespace OOP_task.Matrix.Matrix
{
    public class NMatrix
    {
        // here should be all exceptoins
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };

        #endregion



        #region Attribute
        private List<int> numList = new();
        private int matrixSize;
        #endregion

        #region Constructors
        public NMatrix(int size)
        {
            if (size <= 0) throw new NegativeSizeException();
            matrixSize = size;

            for (int i = 0; i < matrixSize + matrixSize - 2 + matrixSize; i++)
            {
                numList.Add(0);
            }
        }

        public NMatrix(NMatrix a)
        {
            matrixSize = a.Size;
            for (int i = 0; i < a.Size + a.Size - 2 + a.Size; i++)
            {
                numList.Add(a.numList[i]);
            }
        }
        #endregion

        #region Properties

        public int Size
        {
            get { return matrixSize; }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new IndexOutOfRangeException();
                if (j == 0)
                {
                    return numList[i];
                }
                else if (j == Size - 1)
                {
                    return numList[Size + Size - 2 + i];
                }
                else
                {
                    if (i != j)
                        return 0;
                    else
                    {
                        return numList[Size + i - 1];
                    }
                }
            }
            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new IndexOutOfRangeException();
                if (j == 0)
                {
                    numList[i] = value;
                }
                else if (j == Size - 1)
                {
                    numList[Size + Size - 2 + i] = value;
                }
                else
                {
                    if (i != j)
                        throw new ReferenceToNullPartException();
                    else
                    {
                        numList[Size + i - 1] = value;
                    }
                }
            }
        }

        #endregion

        public void load(NMatrix a)
        {
            if (matrixSize != a.Size)
            {
                return;
            }
            numList.Clear();
            for (int i = 0; i < a.Size + a.Size - 2 + a.Size; i++)
            {
                numList.Add(a.numList[i]);
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    str += "\t" + this[i, j];
                }
                str += "\n";
            }
            return str;
        }


        public bool isZero(int i, int j)
        {
            if (j == 0 || j == matrixSize - 1)
            {
                return false;
            }
            else if (i == j)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region Operators

        public static NMatrix operator +(NMatrix a, NMatrix b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            NMatrix c = new(a.Size);
            for (int i = 0; i < a.Size + a.Size - 2 + a.Size; ++i)
            {
                c.numList[i] = a.numList[i] + b.numList[i];
            }
            return c;
        }

        public static NMatrix operator *(NMatrix a, NMatrix b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            NMatrix c = new NMatrix(a.Size);

            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    for (int k = 0; k < a.Size; k++)
                    {
                        if (!c.isZero(i, j))
                        {
                            c[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
            }
            return c;

        }

        #endregion
    }
}

