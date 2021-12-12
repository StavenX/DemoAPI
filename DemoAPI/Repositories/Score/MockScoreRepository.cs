using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.ScoreData
{
    public class MockScoreRepository : IScoreRepository
    {
        private List<Score> scores = new List<Score>()
        {
            new Score()
            {
                Id = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                ScoreValue = 1,
                StartedPlaying = DateTime.Now,
                EndedPlaying = DateTime.Now
            },
            new Score()
            {
                Id = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                ScoreValue = 2,
                StartedPlaying = DateTime.Now,
                EndedPlaying = DateTime.Now
            },
            new Score()
            {
                Id = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                ScoreValue = 3,
                StartedPlaying = DateTime.Now,
                EndedPlaying = DateTime.Now
            },
            new Score()
            {
                Id = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                ScoreValue = 4,
                StartedPlaying = DateTime.Now,
                EndedPlaying = DateTime.Now
            }
        };

        public Score AddScore(Guid playerId, int scoreValue, DateTime startedPlaying, DateTime endedPlaying)
        {
            var score = new Score
            {
                Id = Guid.NewGuid(),
                ScoreValue = scoreValue,
                StartedPlaying = startedPlaying,
                EndedPlaying = endedPlaying,
                PlayerId = playerId
            };

            scores.Add(score);

            return score;
        }

        public void DeleteScore(Score score)
        {
            scores.Remove(score);
        }

        public Score GetScore(Guid id)
        {
            return scores.SingleOrDefault(x => x.Id == id);
        }

        public List<Score> GetScores()
        {
            return scores; 
        }

        public List<Score> GetScoresForPlayer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
