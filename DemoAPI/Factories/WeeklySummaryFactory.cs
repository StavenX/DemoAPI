using DemoAPI.Extensions;
using DemoAPI.Models;
using DemoAPI.Repositories;
using DemoAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Factories
{
    public class WeeklySummaryFactory : IWeeklySummaryFactory
    {
        private IPlayerRepository _playerRepository;
        private IScoreRepository _scoreRepository;

        private readonly int WeeklyReportAmount = 10; 

        public WeeklySummaryFactory(IPlayerRepository playerRepository, IScoreRepository scoreRepository)
        {
            _playerRepository = playerRepository;
            _scoreRepository = scoreRepository; 
        }

        public List<WeeklySummary> GetWeeklySummaries(int weekNumber)
        {
            List<WeeklySummary> weeklySummaries = new List<WeeklySummary>();

            var weeklyScores = _scoreRepository.GetScores().Where(x => x.IsWithinWeekNumber(weekNumber));
            weeklyScores = weeklyScores.OrderByDescending(x => x.ScoreValue); // sort by score??

            var uniqueScoresByPlayer = weeklyScores.DistinctBy(x => x.PlayerId);

            foreach (var score in uniqueScoresByPlayer)
            {
                WeeklySummary summary = new WeeklySummary()
                {
                    PlayerName = _playerRepository.GetPlayer(score.PlayerId).Name,
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
