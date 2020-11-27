using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HangManDL.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
    [Required]
        public string Name { get; set; }
        public virtual List<Word> Words { get; set; }
        public virtual List<ScoreBoard> ScoreBoards { get; set; }
    }
}
