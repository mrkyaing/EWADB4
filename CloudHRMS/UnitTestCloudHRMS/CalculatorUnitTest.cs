using System;
namespace UnitTestCloudHRMS
{
    
    public class CalculatorUnitTest
    {
       [Fact]
        public void ReturnCorrectAddResut()
        {
            // 1) Arrange
            Calculator calculator = new Calculator();
            int n1 = 1;
            int n2= 2;
            int expectedResult = 3;
            //2 ) Act
            int realResult=calculator.Add(n1, n2);
            //3) Assert
            Assert.Equal(expectedResult, realResult);//true >> Unit Test Pass
        }
        [Fact]
        public void ReturnWrongAddResut()
        {
            // 1) Arrange
            Calculator calculator = new Calculator();
            int n1 = 1;
            int n2 = 2;
            int expectedResult = 7;
            //2 ) Act
            int realResult = calculator.Add(n1, n2);
            //3) Assert
            Assert.NotEqual(expectedResult, realResult);//true >> Unit Test Pass
        }
        [Fact]
        public void ReturnCorrectSayHi()
        {
            //arrange
            Calculator calculator= new Calculator();
            string name = "MG";
            string expectedOutputed = "Hi,MG";
            //act
            string responseOutputted = calculator.SayHi(name);
            //assert
            Assert.Equal(expectedOutputed, responseOutputted);
        }
    }
}
