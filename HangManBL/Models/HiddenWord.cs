using System.Collections.Generic;
using System.Linq;

namespace HangManBL.Models
{
    public class HiddenWord
    {
        public HiddenWord(int  wordSize)
        {
            CorrectGuesses = new string[wordSize];
            IncorrectGuesses = new List<string>();
        }
        public List<string> IncorrectGuesses { get; set; }
        public string[] CorrectGuesses { get; set; }
        public int HiddenLetterCount => CorrectGuesses.Count(z => z == null);
    }
}
