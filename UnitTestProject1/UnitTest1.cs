using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Calc;
using ConsoleApplication1;

namespace UnitTestProject1
{
    /// <summary>
    /// тестирование Calc
    /// </summary>
    [TestClass]
    public class CalsUnitTest
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new C.Calc(new Calc.IOperation[] { new Calc.SumOperation(), new Calc.MultiplyOperation(), new Calc.SquareOperation(), new Calc.ComplexSumOperation() });
            //var calc = new C.Calc(new Calc.IOperation[] { new Calc.SumOperation(), new Calc.MultiplyOperation()});
            //var result = calc.Sum(1, 2);
            var result1 = calc.Execute("Multiply", new object[] { 3, 5 });
            Assert.AreEqual(result1, 15);

            var result2 = calc.Execute("Sum", new object[] { 1, 2 });
            Assert.AreEqual(result2, 3);

            var result3 = calc.Execute("Square", new object[] { 5 });
            Assert.AreEqual(result3, 25);

            
            int result4 = ((int[])calc.Execute("ComplexSum", new object[] { 1, 2, 3, 6 }))[0];
            int result5 = ((int[])calc.Execute("ComplexSum", new object[] { 1, 2, 3, 6 }))[1];
            Assert.AreEqual(result4, 4);
            Assert.AreEqual(result5, 8);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            var calc = new C.Calc(new Calc.IOperation[] { new Calc.MultiplyOperation() });
            var result1 = calc.Execute("Multiply", new object[] { 3, 5 });
            Assert.AreEqual(result1, 15);
        }

        [TestMethod]
        public void SquareTest()
        {
            var calc = new C.Calc(new Calc.IOperation[] { new Calc.SquareOperation() });
            var result1 = calc.Execute("Square", new object[] { 5 });
            Assert.AreEqual(result1, 25);
        }
    }
}
