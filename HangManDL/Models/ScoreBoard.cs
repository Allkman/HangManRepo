using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HangManDL.Models
{
    [Table("ScoreBoard")]
    public class ScoreBoard
    {
        [Key]
        public int ScoreBoardId { get; set; }
        public int PlayerId { get; set; }
        public DateTime DataPlayed { get; set; }
        public int WordId { get; set; }
        public int GuessCount { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Word Word { get; set; }
        public virtual Player Player { get; set; }
    }
}
