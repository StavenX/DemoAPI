﻿using DemoAPI.Models;
using System;
using System.Collections.Generic;

namespace DemoAPI.ScoreData
{
    public interface IScoreData
    {
        List<Score> GetScores();
        List<Score> GetScoresForPlayer(Guid id);
        Score GetScore(Guid id);
        Score AddScore(Guid playerId, int scoreValue, DateTime startedPlaying, DateTime endedPlaying);
        void DeleteScore(Score score);
    }
}
