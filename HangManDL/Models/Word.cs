using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HangManDL.Models
{
    [Table("Words")]
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        public int SubjectId { get; set; }
        public string Text { get; set; }
        public virtual Subject Subject { get; set; }
        public List<ScoreBoard> ScoreBoards { get; set; }
    }
}
