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
            var totalPlaythroughMinutes = playerScores.Sum(x => (x.EndedPlaying - x.StartedPlaying).TotalMinutes);
            var totalPlaythroughs = playerScores.Count;

            var impactReport = new ImpactReport()
            {
                PlayerId = playerId,
                PlayerName = player.Name,
                TotalScore = totalScoreSum,
                AmountPlayedMinutes = totalPlaythroughMinutes,
                Playthroughs = totalPlaythroughs
            };

            return impactReport;
        }
    }
}
