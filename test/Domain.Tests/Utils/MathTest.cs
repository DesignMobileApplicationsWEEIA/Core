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

        [Fact]
        public void Test_Compute_Distance_In_Map()
        {
            var point1 = new Point(51.747162, 19.455941);
            var ponit2 = new Point(51.747207, 19.455923);
            var result = Math.LenghtOfLineInMap(point1, ponit2);
            result.Value.Should().BeGreaterOrEqualTo(5);
            result.Value.Should().BeLessOrEqualTo(6);
        }
    }
}