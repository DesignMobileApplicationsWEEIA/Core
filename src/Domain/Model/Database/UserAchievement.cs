﻿namespace Domain.Model.Database
{
    public class UserAchievement
    {
        public long Id { get; set; }

        public string MacAddress { get; set; }

        public Achievement Achievement { get; set; }

        public long AchievementId { get; set; }
    }
}