using SE1_work1;

namespace TestProject1
{
    [TestClass]
    public sealed class StringCalculatorTests
    {
        [TestMethod]
        public void EmptyStringReturnsZero()
        {
            StringCalculator sc = new StringCalculator();

            int result = sc.Calculate("");

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void SingleNumberReturnsValue()
        {
            StringCalculator sc = new StringCalculator();

            int r1 = sc.Calculate("5");
            Assert.AreEqual(5, r1);

            int r2 = sc.Calculate("367");
            Assert.AreEqual(367, r2);

        }


        [TestMethod]
        public void DoubleNumberCommaDelimitedValue()
        {
            StringCalculator sc = new StringCalculator();

            int result = sc.Calculate("5,6");

            Assert.AreEqual(11, result);
        }


        [TestMethod]
        public void DoubleNumberNewlineDelimitedValue()
        {
            StringCalculator sc = new StringCalculator();

            int result = sc.Calculate("5\n9");

            Assert.AreEqual(14, result);
        }



        [TestMethod]
        public void ThreeNumbersAnyDelimitedValue()
        {
            StringCalculator sc = new StringCalculator();

            int res1 = sc.Calculate("5,9,7");

            Assert.AreEqual(21, res1);

            int res2 = sc.Calculate("5\n10\n7");

            Assert.AreEqual(22, res2);
        }




        [TestMethod]
        public void NegativeNumbersThrowException()
        {
            StringCalculator sc = new StringCalculator();
            Assert.ThrowsException<ArgumentException>(() => sc.Calculate("-5,6"));
        }




        [TestMethod]
        public void NumbersGreaterThan1000AreIgnored()
        {
            StringCalculator sc = new StringCalculator();
            int result = sc.Calculate("5,1001");
            Assert.AreEqual(5, result);
        }




        [TestMethod]
        public void SingleCharDelimiterDefinedOnFirstLine()
        {
            StringCalculator sc = new StringCalculator();
            int result = sc.Calculate("//#\n5#6");
            Assert.AreEqual(11, result);
        }



        [TestMethod]
        public void MultiCharDelimiterDefinedOnFirstLine()
        {
            StringCalculator sc = new StringCalculator();
            int result = sc.Calculate("//[###]\n###6");
            Assert.AreEqual(11, result);
        }



        [TestMethod]
        public void MultipleDelimitersDefinedOnFirstLine()
        {
            StringCalculator sc = new StringCalculator();
            int result = sc.Calculate("//[*][%]\n5*6%7");
            Assert.AreEqual(18, result);
        }
    }
}
