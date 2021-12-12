using System;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long.")]
        public string Name { get; set; }
    }
}
