﻿using DemoAPI.Models;

namespace DemoAPI.Extensions
{
    public static class ScoreExtensions
    {
        public static double GetDurationMinutes (this Score score)
        {
            return (score.EndedPlaying - score.StartedPlaying).TotalMinutes;
        }

        public static double GetDurationSeconds(this Score score)
        {
            return (score.EndedPlaying - score.StartedPlaying).TotalSeconds;
        }

        public static bool IsWithinWeekNumber(this Score score, int weekNumber)
        {
            return DateTimeExtensions.IsWithinWeekNumber(score.StartedPlaying, score.EndedPlaying, weekNumber);
        }
    }
}
