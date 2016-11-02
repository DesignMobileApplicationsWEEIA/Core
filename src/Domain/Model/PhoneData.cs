﻿namespace Core.Domain.Model
{
    public class PhoneData
    {
        public double Direction { get; set; }
        public PhoneLocation PhoneLocation { get; set; }

        public bool IsInVisualField(Building building)
        {
            return true;
        }
    }
}