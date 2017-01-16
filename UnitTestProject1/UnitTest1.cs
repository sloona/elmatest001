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
            var calc = new C.Calc(new Calc.IOperation[] { new Calc.SumOperation() });
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3);
        }
    }
}
