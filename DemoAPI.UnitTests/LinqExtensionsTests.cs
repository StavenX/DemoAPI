using DemoAPI.Extensions;
using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DemoAPI.Tests
{
    public class LinqExtensionstests
    {
        [Fact]
        public void LinqExtensions_PlayerHasTwoDuplicates_AssertSingle()
        {
            List<Player> players = new List<Player>();

            var duplicatePlayer = new Player()
            {
                Id = Guid.Parse("6935d7b0-22c4-4e5f-95c4-093232337b71"),
                Name = "Duplicato"
            };

            players.Add(duplicatePlayer);
            players.Add(duplicatePlayer);

            Assert.Single(players.DistinctBy(x => x.Id).ToList());
        }
    }
}
