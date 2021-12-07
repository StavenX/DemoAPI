using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Score
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public int ScoreValue { get; set; }

        [Required]
        public DateTime StartedPlaying { get; set; }

        [Required]
        public DateTime EndedPlaying { get; set; }
    }
}
