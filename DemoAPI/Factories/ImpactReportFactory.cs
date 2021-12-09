using DemoAPI.Extensions;
using DemoAPI.Models;
using DemoAPI.PlayerData;
using DemoAPI.ScoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var impactReport = new ImpactReport()
            {
                PlayerId = playerId,
                PlayerName = player.Name,
                TotalScore = totalScoreSum,
                AmountPlayedSeconds = totalPlaythroughSeconds,
                Playthroughs = totalPlaythroughs
            };

            return impactReport;
        }
    }
}
