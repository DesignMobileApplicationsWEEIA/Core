using Domain.Model.Math;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Model
{
    public class LineFunctionTests
    {
        [Fact]
        public void Test_Cratating_Line_Function_From_Two_Points()
        {
            var point1 = new Point(3, 7);
            var point2 = new Point(-2, -8);
            var lineFunction = LineFunction.GetFromTwoPoints(point1, point2);
            lineFunction.A.Should().BeGreaterOrEqualTo(3);
            lineFunction.B.Should().BeGreaterOrEqualTo(-2);
        }
    }
}