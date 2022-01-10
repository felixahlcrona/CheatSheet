using Xunit;
using CheatSheet;

namespace Tests
{
    public class UnitTest1
    {

        //Testar en metod, denna bör addera två värden.
        //Importerar klassen/projektet jag vill testa med reference, kallar sen metoden som jag vill testa
        [Fact]
        public void CalculatorTest_Add()
        {

            //Arrange
            double expected = 2;

            //Act
            var answer = CheatSheet.CheatSheet.CalculatorAddTest(1, 1);

            //Assert

            Assert.Equal(expected, answer);

        }

        // Testar om metoden retunerar en double, annars fail
        [Fact]
        public void CalculatorTest_IsNotString()
        {

            //Act
            var answer = CheatSheet.CheatSheet.CalculatorAddTest(1, 1);

            //Assert
            Assert.IsType<double>(answer);

        }

        // Testar om metoden retunerar förväntat string värde
        [Fact]
        public void StringTestReturnName()
        {
            //Arrange
            string expected = "john";

            //Act
            var answer = CheatSheet.CheatSheet.StringReturnNameTest("john");

            //Assert
            Assert.Equal(expected, answer);

        }

        // Testar om metoden inte retunerar null
        [Theory]
        [InlineData("peter")]
        [InlineData(null)]
        [InlineData("mark")]
       
        public void StringTestReturnNameIsNotNull(string value)
        {
          
            //Act
            var answer = CheatSheet.CheatSheet.StringReturnNameTest(value);

            //Assert
            Assert.NotNull(answer);

        }

   
    }
    }