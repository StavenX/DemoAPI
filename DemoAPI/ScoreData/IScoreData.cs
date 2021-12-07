using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.ScoreData
{
    public interface IScoreData
    {
        List<Score> GetScores();
        Score GetScore(Guid id);
        Score AddScore(Score score);
        void DeleteScore(Score score);
    }
}
