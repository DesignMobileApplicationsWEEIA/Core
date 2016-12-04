using Domain.Model.Math;
using Domain.Utils;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Utils
{
    public class MathTest
    {
        [Fact]
        public void Test_Compute_Lenght_Of_Line()
        {
            var point1 = new Point(1, 1);
            var ponit2 = new Point(4, 5);
            var result = Math.LenghtOfLine(point1, ponit2);
            result.Should().BeGreaterOrEqualTo(5);
        }
    }
}