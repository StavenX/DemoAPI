﻿using DemoAPI.Extensions;
using DemoAPI.Models;
using DemoAPI.PlayerData;
using DemoAPI.ScoreData;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Factories
{
    public class WeeklySummaryFactory : IWeeklySummaryFactory
    {
        private IPlayerData _playerData;
        private IScoreData _scoreData;

        private readonly int WeeklyReportAmount = 10; 

        public WeeklySummaryFactory(IPlayerData playerData, IScoreData scoreData)
        {
            _playerData = playerData;
            _scoreData = scoreData; 
        }

        public List<WeeklySummary> GetWeeklySummaries(int weekNumber)
        {
            List<WeeklySummary> weeklySummaries = new List<WeeklySummary>();

            var weeklyScores = _scoreData.GetScores().Where(x => x.IsWithinWeekNumber(weekNumber));
            weeklyScores = weeklyScores.OrderByDescending(x => x.ScoreValue); // sort by score??

            var uniqueScoresByPlayer = weeklyScores.DistinctBy(x => x.PlayerId);

            foreach (var score in uniqueScoresByPlayer)
            {
                WeeklySummary summary = new WeeklySummary()
                {
                    PlayerName = _playerData.GetPlayer(score.PlayerId).Name,
                    HighestScore = score.ScoreValue,
                    HighestDurationSeconds = score.GetDurationSeconds()
                };

                weeklySummaries.Add(summary);
            }

            return weeklySummaries.OrderByDescending(x => x.HighestScore)
                .Take(WeeklyReportAmount)
                .ToList();
        }
    }
}
