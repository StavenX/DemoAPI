using DemoAPI.Extensions;
using DemoAPI.Models;
using DemoAPI.PlayerData;
using DemoAPI.ScoreData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Services
{
    public class ImpactReportFactory : IImpactReportFactory
    {
        private IScoreData _scoreData;
        private IPlayerData _playerData;

        public ImpactReportFactory(IPlayerData playerData, IScoreData scoreData)
        {
            _scoreData = scoreData;
            _playerData = playerData;
        }

        public List<ImpactReport> GetAllImpactReports()
        {
            List<ImpactReport> reports = new List<ImpactReport>();

            var players = _playerData.GetPlayers();

            foreach (var player in players)
            {
                reports.Add(GetImpactReportForPlayer(player.Id));
            }

            return reports; 
        }

        public ImpactReport GetImpactReportForPlayer(Guid playerId)
        {
            var player = _playerData.GetPlayer(playerId);

            var playerScores = _scoreData.GetScoresForPlayer(playerId);
            var totalScoreSum = playerScores.Sum(x => x.ScoreValue);
            var totalPlaythroughSeconds = playerScores.Sum(x => (x.GetDurationSeconds()));
            var totalPlaythroughs = playerScores.Count;
            var firstScore = playerScores.OrderBy(x => x.StartedPlaying).FirstOrDefault();
            var bestScore = playerScores.OrderByDescending(x => x.ScoreValue).FirstOrDefault();

            var impactReport = new ImpactReport()
            {
                PlayerId = playerId,
                PlayerName = player.Name,
                TotalScore = totalScoreSum,
                AmountPlayedSeconds = totalPlaythroughSeconds,
                Playthroughs = totalPlaythroughs
            };

            /* Calculate how much this player has improved */
            if (impactReport.Playthroughs > 0)
            {
                impactReport.FirstScore = firstScore.ScoreValue;
                impactReport.BestScore = bestScore.ScoreValue;

                var change = bestScore.ScoreValue - firstScore.ScoreValue;
                var improvedPercentage = ((double)change / firstScore.ScoreValue) * 100;
                impactReport.ImprovedPercentage = improvedPercentage;
            }

            return impactReport;
        }
    }
}
