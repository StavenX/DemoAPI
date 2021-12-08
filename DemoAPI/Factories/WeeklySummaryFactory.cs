using DemoAPI.Extensions;
using DemoAPI.Models;
using DemoAPI.PlayerData;
using DemoAPI.ScoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            weeklyScores.OrderByDescending(s => s.ScoreValue); // sort by score??

            // calculate duration too ?
            var uniqueScoresByPlayer = weeklyScores.DistinctBy(s => s.PlayerId);

            foreach (var score in uniqueScoresByPlayer)
            {
                WeeklySummary summary = new WeeklySummary()
                {
                    PlayerName = _playerData.GetPlayer(score.PlayerId).Name,
                    HighestScore = score.ScoreValue,
                    HighestDuration = score.GetDurationMinutes()
                };

                weeklySummaries.Add(summary);
            }

            return weeklySummaries.OrderByDescending(s => s.HighestScore)
                .Take(WeeklyReportAmount)
                .ToList();
        }
    }
}
