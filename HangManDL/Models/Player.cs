using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HangManDL.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<ScoreBoard> ScoreBoards { get; set; }
    }
}
