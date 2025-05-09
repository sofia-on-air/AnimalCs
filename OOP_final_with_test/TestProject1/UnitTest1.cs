using OOP_task.Matrix.Matrix;
using static OOP_task.Matrix.Matrix.NMatrix;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SetMatrix()
        {
            NMatrix a = new NMatrix(3);

            Assert.AreEqual(a[0, 0], 0);
            Assert.AreEqual(a[1, 1], 0);
            Assert.AreEqual(a[2, 2], 0);
            Assert.AreEqual(a[0, 2], 0);
            Assert.AreEqual(a[2, 0], 0);
            Assert.AreEqual(a[1, 0], 0);
            Assert.AreEqual(a[1, 2], 0);


            a[0, 0] = 1;
            a[1, 1] = 2;
            a[2, 2] = 3;
            a[1, 0] = 4;
            a[2, 0] = 5;
            a[0, 2] = 6;
            a[1, 2] = 7;


            Assert.ThrowsException<NMatrix.ReferenceToNullPartException>(() => _ = a[0,1]=9);

            Assert.AreEqual(a[0, 0], 1);
            Assert.AreEqual(a[1, 1], 2);
            Assert.AreEqual(a[2, 2], 3);
            Assert.AreEqual(a[0, 2], 6);
            Assert.AreEqual(a[2, 0], 5);
            Assert.AreEqual(a[1, 0], 4);
            Assert.AreEqual(a[1, 2], 7);

        }

        [TestMethod]
        public void createMatrix()
        {
            Assert.ThrowsException<NMatrix.NegativeSizeException>(() => _ = new NMatrix(0));
            NMatrix a = new(1);
            Assert.AreEqual(a[0, 0], 0);
            Assert.AreEqual(a.Size, 1);

            NMatrix b = new(4);
            Assert.AreNotEqual(b.Size, 2);

            NMatrix c = new(3);

            c[0, 0] = 1;
            c[1, 1] = 1;
            c[2, 2] = 1;
            c[1, 0] = 1;
            c[2, 0] = 1;
            c[0,2] = 1;
            c[1, 2] = 1;



            Assert.AreNotEqual(c.Size, 5);
        }


        [TestMethod]
        public void compMatrix()
        {
            NMatrix a = new NMatrix(3);
            a[0, 0] = 1;
            a[1, 1] = 2;
            a[2, 2] = 3;
            a[1, 0] = 4;
            a[2, 0] = 3;
            a[0, 2] = 2;
            a[1, 2] = 1;
            NMatrix b = new NMatrix(a);
            Assert.IsTrue(a[2, 0].Equals(b[2, 0]));
            Assert.IsTrue(a[0, 0].Equals(b[0, 0]));
            Assert.IsTrue(a[1, 1].Equals(b[1, 1]));
            Assert.IsTrue(a[2, 2].Equals(b[2, 2]));
            Assert.IsTrue(a[1, 0].Equals(b[1, 0]));
            Assert.IsTrue(a[0, 2].Equals(b[0, 2]));
            Assert.IsTrue(a[1, 2].Equals(b[1, 2]));
            b[2, 0] = 10;
            Assert.IsFalse(a[2, 0].Equals(b[2, 0]));
            Assert.IsTrue(a[0, 0].Equals(b[0, 0]));
            Assert.IsTrue(a[1, 1].Equals(b[1, 1]));
            Assert.IsTrue(a[2, 2].Equals(b[2, 2]));
            Assert.IsTrue(a[1, 0].Equals(b[1, 0]));
            Assert.IsTrue(a[0, 2].Equals(b[0, 2]));
            Assert.IsTrue(a[1, 2].Equals(b[1, 2]));
            a = a;
            Assert.IsTrue(a[2, 0].Equals(a[2, 0]));
            Assert.IsTrue(a[0, 0].Equals(a[0, 0]));
            Assert.IsTrue(a[1, 1].Equals(a[1, 1]));
            Assert.IsTrue(a[2, 2].Equals(a[2, 2]));
            Assert.IsTrue(a[1, 0].Equals(a[1, 0]));
            Assert.IsTrue(a[0, 2].Equals(a[0, 2]));
            Assert.IsTrue(a[1, 2].Equals(a[1, 2]));
        }

        [TestMethod]
        public void sumMatrix()
        {
            NMatrix a = new(3);
            NMatrix b = new(3);
            NMatrix zero = new(3);
            NMatrix d = new(4);
            NMatrix c = new(3);

            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;
            a[1, 0] = 1;
            a[2, 0] = 1;
            a[0, 2] = 1;
            a[1, 2] = 1;

            b[0, 0] = 1;
            b[1, 1] = 1;
            b[2, 2] = 1;
            b[1, 0] = 1;
            b[2, 0] = 1;
            b[0, 2] = 1;
            b[1, 2] = 1;


            c = a + b;

            Assert.AreEqual(c[0, 0], 2);
            Assert.AreEqual(c[1, 1], 2);
            Assert.AreEqual(c[2, 2], 2);
            Assert.AreEqual(c[1, 2], 2);
            Assert.AreEqual(c[2, 0], 2);
            Assert.AreEqual(c[0, 2], 2);
            Assert.AreEqual(c[1, 0], 2);
            
            Assert.IsTrue(a[1, 0].Equals((zero + a)[1, 0]));
            Assert.IsTrue(a[0, 0].Equals((zero + a)[0, 0]));
            Assert.IsTrue(a[1, 1].Equals((zero + a)[1, 1]));
            Assert.IsTrue(a[2, 2].Equals((zero + a)[2, 2]));
            Assert.IsTrue(a[2, 0].Equals((zero + a)[2, 0])); 
            Assert.IsTrue(a[0, 2].Equals((zero + a)[0, 2]));
            Assert.IsTrue(a[1, 2].Equals((zero + a)[1, 2]));

            Assert.IsTrue((a + b)[0, 0].Equals((b + a)[0, 0]));
            Assert.IsTrue((a + b)[1, 1].Equals((b + a)[1, 1]));
            Assert.IsTrue((a + b)[2, 2].Equals((b + a)[2, 2]));
            Assert.IsTrue((a + b)[1, 0].Equals((b + a)[1, 0]));
            Assert.IsTrue((a + b)[2, 0].Equals((b + a)[2, 0]));
            Assert.IsTrue((a + b)[0, 2].Equals((b + a)[0, 2]));
            Assert.IsTrue((a + b)[1, 2].Equals((b + a)[1, 2]));

            Assert.IsTrue(((a + b) + c)[1, 1].Equals((a + (b + c))[1, 1]));
            Assert.IsTrue(((a + b) + c)[0, 0].Equals((a + (b + c))[0, 0]));
            Assert.IsTrue(((a + b) + c)[2, 2].Equals((a + (b + c))[2, 2]));
            Assert.IsTrue(((a + b) + c)[2, 0].Equals((a + (b + c))[2, 0]));
            Assert.IsTrue(((a + b) + c)[0, 2].Equals((a + (b + c))[0, 2]));
            Assert.IsTrue(((a + b) + c)[1, 0].Equals((a + (b + c))[1, 0]));
            Assert.IsTrue(((a + b) + c)[1, 2].Equals((a + (b + c))[1, 2]));


            Assert.ThrowsException<NMatrix.DifferentSizeException>(() => a + d);
        }

        [TestMethod]
        public void mulMatrix()
        {
            NMatrix a = new(3);
            NMatrix b = new(3);
            NMatrix zero = new(3);
            NMatrix d = new(4);
            NMatrix c;

            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;
            a[1, 0] = 1;
            a[2, 0] = 1;
            a[0, 2] = 1;
            a[1, 2] = 1;

            b[0, 0] = 1;
            b[1, 1] = 1;
            b[2, 2] = 1;
            b[1, 0] = 1;
            b[2, 0] = 1;
            b[0, 2] = 1;
            b[1, 2] = 1;


            c = a * b;

            Assert.AreEqual(c[0, 0], 2);
            Assert.AreEqual(c[1, 2], 3);
            Assert.AreEqual(c[1, 1], 1);
            Assert.AreEqual(c[2, 2], 2);
            Assert.AreEqual(c[2, 0], 2);
            Assert.AreEqual(c[1, 0], 3);
            Assert.AreEqual(c[0, 2], 2);

            Assert.IsTrue(zero[1, 1].Equals((a * zero)[1, 1]));
            Assert.IsTrue(zero[2, 2].Equals((a * zero)[2, 2]));
            Assert.IsTrue(zero[0, 0].Equals((a * zero)[0, 0]));
            Assert.IsTrue(zero[1, 2].Equals((a * zero)[1, 2]));
            Assert.IsTrue(zero[1, 0].Equals((a * zero)[1, 0]));
            Assert.IsTrue(zero[2, 0].Equals((a * zero)[2, 0]));
            Assert.IsTrue(zero[0, 2].Equals((a * zero)[0, 2]));

            Assert.IsFalse(b[2, 2].Equals((a * b)[2, 2]));
            Assert.IsFalse(b[0, 0].Equals((a * b)[0, 0]));
            Assert.IsTrue(b[1, 1].Equals((a * b)[1, 1]));
            Assert.IsFalse(b[2, 0].Equals((a * b)[2, 0]));
            Assert.IsFalse(b[0, 2].Equals((a * b)[0, 2]));
            Assert.IsFalse(b[1, 0].Equals((a * b)[1, 0]));
            Assert.IsFalse(b[1, 2].Equals((a * b)[1, 2]));

            Assert.IsTrue(((a * (b * c))[0,0]).Equals((((a * b) * c))[0, 0]));
            Assert.IsTrue(((a * (b * c))[1, 1]).Equals((((a * b) * c))[1, 1]));
            Assert.IsTrue(((a * (b * c))[2, 2]).Equals((((a * b) * c))[2, 2]));
            Assert.IsTrue(((a * (b * c))[2, 0]).Equals((((a * b) * c))[2, 0]));
            Assert.IsTrue(((a * (b * c))[1, 0]).Equals((((a * b) * c))[1, 0]));
            Assert.IsTrue(((a * (b * c))[0, 2]).Equals((((a * b) * c))[0, 2]));
            Assert.IsTrue(((a * (b * c))[1, 2]).Equals((((a * b) * c))[1, 2]));

            Assert.ThrowsException<NMatrix.DifferentSizeException>(() => a * d);
        }
    }
}