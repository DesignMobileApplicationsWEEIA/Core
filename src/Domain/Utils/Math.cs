using Domain.Model.Math;

namespace Domain.Utils
{
    public static class Math
    {
        public const int MaxDistance = 160;
        public const int MeterPerDagree = 111000;

        /// <summary>
        ///
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="azimuth">Dagree</param>
        /// <returns></returns>
        public static bool IsInPointOfView(Point p1, Point p2, double azimuth)
        {
            var distanceBetween = LenghtOfLineInMap(p1, p2);
            var newAzimuth = ToBearing(System.Math.Atan2(p2.Y - p1.Y, p2.X - p1.X));
            return System.Math.Abs(azimuth - newAzimuth) < 20 && distanceBetween < MaxDistance;
        }

        public static double LenghtOfLine(Point point1, Point point2)
        {
            return
                System.Math.Sqrt((System.Math.Pow((point2.X - point1.X), 2)) +
                                 (System.Math.Pow((point2.Y - point1.Y), 2)));
        }

        public static double LenghtOfLineInMap(Point point1, Point point2)
        {
            return LenghtOfLine(point1, point2) * MeterPerDagree;
        }

        public static double DagreeToReadians(double dagree)
        {
            return dagree * (System.Math.PI / 180d);
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / System.Math.PI);
        }

        public static double ToBearing(double radians)
        {
            return (RadianToDegree(radians) + 360) % 360;
        }


    }
}