using HangManBL.Interfaces;
using HangManBL.Models;
using HangManDL.Models;
using System.Collections.Generic;
using System.Text;

namespace HangManBL
{
    public class HiddenWordManager : IHiddenWordManager
    {
        private readonly Word _word;
        public HiddenWord HiddenWord { get; set; }
        public HiddenWordManager(Word word)
        {
            _word = word;
            HiddenWord = new HiddenWord(_word.Text.Length);
        }
        public HiddenWord GetHiddenWord()
        {
            return HiddenWord;
        }
        public string GetHiddedWordStructure()
        {

            var sb = new StringBuilder("Zodis: ");
            foreach (var raide in HiddenWord.CorrectGuesses) // praiteruoja pro teisingus spejimus, //teisingi spejimai formuoja masyva
            {
                if (string.IsNullOrWhiteSpace(raide)) sb.Append("_ "); //tikrinu ar raide irasyta ar neirasyta, jei neirasyta parodau _ 
                else sb.Append($"{raide} "); //jei raide  istatyta i savo vieta, tai parodau ta raide
            }
            return sb.ToString();
  
        }
        public void CheckLetter(string spejimas)
        {
            var zodisArr = _word.Text.ToCharArray();//tikrina ar zodyje, kuri pasirinkome speti yra raide  kuria pasirinkau
            var raidesIndeksai = new List<int>();
            for (int i = 0; i < _word.Text.Length; i++)
            {
                // pagal verslo logika programa neturi reaguoti i mazasias ar didziasias taigi toupper idziasias
                if (zodisArr[i].ToString().ToUpper() == spejimas.ToUpper()) raidesIndeksai.Add(i);
            }
            if(raidesIndeksai.Count ==0)
            {
               HiddenWord.IncorrectGuesses.Add(spejimas);
            }
            else
            {
                PridetiRaideITeisingaVietaZodyje(spejimas, raidesIndeksai);
            }
        }
        private void PridetiRaideITeisingaVietaZodyje(string spejimas, List<int> raidesIndeksai)
        {
            foreach (int indeksas in raidesIndeksai) // iteruojame per raidziu indeksus ir irasome i teisinga vieta raide
            {
               HiddenWord.CorrectGuesses[indeksas] = spejimas;
            }
        }
    }
}
