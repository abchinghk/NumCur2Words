using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumCur2Words;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$0");
        }

        [TestMethod]
        public void TestMethod2()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$10.00");
        }

        [TestMethod]
        public void TestMethod4()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$75.00");
        }

        [TestMethod]
        public void TestMethod5()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$653.00");
        }

        [TestMethod]
        public void TestMethod6()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$1024.00");
        }

        [TestMethod]
        public void TestMethod7()
        {
            NumCur2Words.NumCur2Words.NumericalCurrencyToWords("$512.75");
        }
    }
}
