using System;
using Domain.Model.Database;

namespace Domain.Model.Math
{
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public static implicit operator Point(PhoneLocation phoneData)
        {
            return new Point(phoneData.Latitude, phoneData.Longitude);
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return (System.Math.Abs(point1.X - point2.X) < double.Epsilon) && (System.Math.Abs(point1.Y - point2.Y) < double.Epsilon);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }
    }
}