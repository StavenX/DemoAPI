using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.ScoreData
{
    public class MockScoreData : IScoreData
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

        public Score AddScore(Score score)
        {
            score.Id = Guid.NewGuid();
            score.ScoreValue = 0;
            score.StartedPlaying = DateTime.Now;
            score.EndedPlaying = DateTime.Now;
            score.PlayerId = Guid.NewGuid();

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
    }
}
