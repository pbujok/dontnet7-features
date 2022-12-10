using FluentAssertions;

namespace DotnetSevenFeatures;

public class Records
{
    [Fact]
    public void ComparingRecords()
    {
        // Arrange
        var money1 = new MoneyRecord(100, "PLN");
        var money2 = new MoneyRecord(100, "PLN");
        
        // Act
        var result = money1 == money2;
        
        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public void ComparingClasses()
    {
        // Arrange
        var money1 = new MoneyClass(100, "PLN");
        var money2 = new MoneyClass(100, "PLN");
        
        // A
        (money1 == money2).Should().BeFalse();
        (money1.Equals(money2)).Should().BeTrue();
    }

    [Fact]
    public void CreatingNew()
    {
        // Arrange
        var money = new MoneyRecord(100, "PLN");
        
        // Act
        var newMoney = money with { Amount = 200 };
        
        // Assert
        var expected = new MoneyRecord(200, "PLN");
        newMoney.Should().Be(expected);
    }
}

file record MoneyRecord(int Amount, string Currency);
    
file class MoneyClass
{
    public int Amount { get; }
    public string Currency { get; }
        
    public MoneyClass(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override bool Equals(object? obj)
    {
        if (obj is MoneyClass other)
        {
            return Amount == other.Amount && Currency == other.Currency;
        }

        return false;
    }
}