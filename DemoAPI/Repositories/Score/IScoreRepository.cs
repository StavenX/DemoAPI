using DemoAPI.Models;
using System;
using System.Collections.Generic;

namespace DemoAPI.Repositories
{
    public interface IScoreRepository
    {
        List<Score> GetScores();
        List<Score> GetScoresForPlayer(Guid id);
        Score GetScore(Guid id);
        Score AddScore(Guid playerId, int scoreValue, DateTime startedPlaying, DateTime endedPlaying);
        void DeleteScore(Score score);
    }
}
