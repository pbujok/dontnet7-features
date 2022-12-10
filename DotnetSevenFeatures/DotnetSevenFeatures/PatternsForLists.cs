using FluentAssertions;

namespace DotnetSevenFeatures;

public class PatternsForLists
{
    [Fact]
    public void PatternMatchingWorksForLists()
    {
        // Arrange
        int[] numbers = { 1, 2, 3 };

        // Act & Assert
        (numbers is [1, 2, 3]).Should().BeTrue();
        (numbers is [1, 2, 4]).Should().BeFalse();
        (numbers is [1, 2, 3, 4]).Should().BeFalse();
        (numbers is [0 or 1, <= 2, >= 3]).Should().BeTrue();
    }
} 