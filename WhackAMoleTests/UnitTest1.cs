namespace WhackAMoleTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        
        // Arrange
        int firstNumber = 5;
        int secondNumber = 10;
        
        // Act
        bool result = addition(firstNumber, secondNumber);

        // Assert
        Assert.True(result);
        Assert.Equal(15, firstNumber + secondNumber);


    }

    public bool addition(int a, int b)
    {
        if (a + b >= a && a + b >= b)
        {
            return true;
        }
        return false;
    }
}