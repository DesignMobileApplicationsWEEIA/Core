using System;
using Domain.Model.Math;
using FluentAssertions;
using Xunit;
using Math = Domain.Utils.Math;

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
            result.Should().BeGreaterOrEqualTo(5);
            result.Should().BeLessOrEqualTo(6);
        }

        [Fact]
        public void Test_Dagrees_To_Radians_Conversion()
        {
            var res = Math.DagreeToReadians(30);
            res.Should().BeLessOrEqualTo(0.5236);
        }

        [Fact]
        public void Test_IsInPointViewMethod_Direction_East_North()
        {
            var achievementPoint = new Point(51.747134,  19.455754);
            var point = new Point(51.746798, 19.455300);
            bool isSearched = false;
            for (int i = 0; i < 90; i++)
            {
                if (Math.IsInPointOfView(point, achievementPoint, i))
                {
                    isSearched = true;
                }
            }

            Assert.True(isSearched);
        }

        [Fact]
        public void Test_IsInPointViewMethod_Direction_East_South()
        {
            var achievementPoint = new Point(51.746611,  19.455870);
            var point = new Point(51.746798, 19.455300);
            bool isSearched = false;
            for (int i = 91; i < 180; i++)
            {
                if (Math.IsInPointOfView(point, achievementPoint, i))
                {
                    isSearched = true;
                }
            }

            Assert.True(isSearched);
        }

        [Fact]
        public void Test_IsInPointViewMethod_Direction_East_South2()
        {
            var achievementPoint = new Point(51.746611, 19.455870);
            var point = new Point(51.746798, 19.455300);
            Assert.True(Math.IsInPointOfView(point, achievementPoint, 108));
        }

        [Fact]
        public void Test_IsInPointViewMethod_Direction_West_South()
        {
            var achievementPoint = new Point(51.746496,  19.454816);
            var point = new Point(51.746798, 19.455300);
            bool isSearched = false;
            for (int i = 181; i < 270; i++)
            {
                if (Math.IsInPointOfView(point, achievementPoint, i))
                {
                    isSearched = true;
                }
            }

            Assert.True(isSearched);
        }

        [Fact]
        public void Test_IsInPointViewMethod_Direction_West_North()
        {
            var achievementPoint = new Point(51.747066,  19.454666);
            var point = new Point(51.746798, 19.455300);
            bool isSearched = false;
            for (int i = 271; i < 360; i++)
            {
                if (Math.IsInPointOfView(point, achievementPoint, i))
                {
                    isSearched = true;
                }
            }

            Assert.True(isSearched);
        }
    }
}