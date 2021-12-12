using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.ScoreData
{
    public class SqlScoreData : IScoreData
    {
        private ApiContext _playerContext;

        public SqlScoreData(ApiContext playerContext)
        {
            _playerContext = playerContext;
        }

        public Score AddScore(Guid playerId, int scoreValue, DateTime startedPlaying, DateTime endedPlaying)
        {
            var newScore = new Score
            {
                Id = Guid.NewGuid(),
                PlayerId = playerId,
                ScoreValue = scoreValue,
                StartedPlaying = startedPlaying,
                EndedPlaying = endedPlaying
            };

            _playerContext.Scores.Add(newScore);
            _playerContext.SaveChanges();

            return newScore;
        }

        public void DeleteScore(Score score)
        {
            _playerContext.Scores.Remove(score);
            _playerContext.SaveChanges();
        }

        public Score GetScore(Guid id)
        {
            var score = _playerContext.Scores.Find(id);
            return score; 
        }

        public List<Score> GetScores()
        {
            return _playerContext.Scores.ToList();
        }

        public List<Score> GetScoresForPlayer(Guid id)
        {
            var playerScores = _playerContext.Scores.Where(x => x.PlayerId == id).ToList();
            return playerScores; 
        }
    }
}
