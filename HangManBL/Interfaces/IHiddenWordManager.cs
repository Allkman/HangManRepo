using HangManBL.Models;

namespace HangManBL.Interfaces
{
    public interface IHiddenWordManager
    {
        HiddenWord HiddenWord { get; set; }      
        string GetHiddedWordStructure();
        HiddenWord GetHiddenWord();
        void CheckLetter(string spejimas);
    }
}
