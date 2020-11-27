using System;
using System.Collections.Generic;
using System.Linq;
using HangMan.Interfaces;
using HangManBL.Interfaces;
using HangManBL;
using HangManDL.Models;

namespace HangMan.Services
{
    public class GameService : IGameService
    {
        private readonly IUiMassageFactory _massageFactory;
        private readonly List<Subject> _subjects;
        private readonly IRandomUtils _randomUtils;
        private readonly IPlayerManager _playerManager;
        private IHiddenWordManager _hiddenWordManager;
        const int gyvybiuKiekis = 7;

        List<Word> panaudotiZodziai = new List<Word>();

        public GameService()
        {
            _massageFactory = new UiMassageFactory();
            _randomUtils = new RandomUtils();
            IReadRepository wordManager = new WordManager();            
            _subjects = wordManager.GetAllSubjects();
            _playerManager = new PlayerManager();
        }
        public void Begin()
        {
            var userName = _massageFactory.LoginMesage();
            var user = _playerManager.GetByUserName(userName);

            if (user == null)
            {
               var key = _playerManager.Add(new Player { Name = userName });
                user = _playerManager.Get(key);
            }
            _massageFactory.PlayerStatisticsMessage(user);

            bool kartoti = true;

            while (kartoti)
            {
                Console.Clear();
                var tema = SelectSubject();
                var zodis = AtsitiktinisZodzioPasirinkimas(tema);
                if (zodis == null)
                {
                    Console.WriteLine("Temoje nebėra žodžiu, ar norite rinktis kitą temą T/N");
                }
                else
                {
                    _hiddenWordManager = new HiddenWordManager(zodis);
                    bool leidziamaSpeti = true;
                    panaudotiZodziai.Add(zodis);
                    _massageFactory.HangmanPictureMessage(0);
                    Console.WriteLine();
                    Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());
                    while (leidziamaSpeti)
                    {
                        string spejimas = _massageFactory.WordInputMessage();
                        bool arSpetasZodis = ArSpetasZodis(spejimas);
                        if (arSpetasZodis)
                        {
                            bool arTeisinga = ArZodisTeisingas(zodis.Text, spejimas);
                            if(arTeisinga)
                            {
                                _massageFactory.WinGameMessage(zodis.Text);
                            }
                            else
                            {
                                _massageFactory.HangmanPictureMessage(gyvybiuKiekis);
                                _massageFactory.LostGameMessage(zodis.Text);
                            }
                            leidziamaSpeti = false;
                        }
                        else
                        {
                            bool arBuvoSpeta = _hiddenWordManager.HiddenWord.IncorrectGuesses.Contains(spejimas);
                            if(!arBuvoSpeta)
                            {
                                _hiddenWordManager.CheckLetter(spejimas);
                            }
                            if (_hiddenWordManager.HiddenWord.IncorrectGuesses.Count == gyvybiuKiekis)
                            {
                                _massageFactory.HangmanPictureMessage(gyvybiuKiekis);
                                _massageFactory.LostGameMessage(zodis.Text);
                                leidziamaSpeti = false;
                            }
                            else
                            {
                                Console.Clear();
                                _massageFactory.HangmanPictureMessage(_hiddenWordManager.HiddenWord.IncorrectGuesses.Count);
                                _massageFactory.IncorrectLettersListMessage(_hiddenWordManager.HiddenWord.IncorrectGuesses);
                                Console.WriteLine(_hiddenWordManager.GetHiddedWordStructure());
                                if (_hiddenWordManager.HiddenWord.HiddenLetterCount == 0)
                                {
                                    _massageFactory.WinGameMessage(zodis.Text);
                                    leidziamaSpeti = false;
                                }
                            }
                        }
                    }
                }
                _playerManager.AddScoreBoard(GetScoreBoard(zodis, user.PlayerId));

                kartoti = _massageFactory.RepeatGameMessage();
            }
        }
        private ScoreBoard GetScoreBoard(Word word, int userId)
        {
            return new ScoreBoard
            {
                PlayerId    = userId,
                DataPlayed  = DateTime.Now,
                GuessCount  = _hiddenWordManager.HiddenWord.IncorrectGuesses.Count + _hiddenWordManager.HiddenWord.CorrectGuesses.Count(z => z != null),
                IsCorrect   = _hiddenWordManager.HiddenWord.HiddenLetterCount == 0,
                WordId      =  word.WordId,
            };
        }
        private Word AtsitiktinisZodzioPasirinkimas(Subject tema)
        {
            var zodziai = tema.Words;
            //jeigu temoje neliko zodziu
            if (zodziai.Count == 0) return null; //jei nebeturime likusiu zodziu nieko negraziname
            var atsitiktinisSk = _randomUtils.Random(0, zodziai.Count);
            return zodziai[atsitiktinisSk];
        }
        static bool ArSpetasZodis(string spejimas)
        {
            return spejimas.Length > 1; //patikinu ar ivestis yra daugiau nei vienas simbolis
        }
        static bool ArZodisTeisingas(string zodis, string spejimas)
        {
            return zodis == spejimas;
        }     
        private Subject SelectSubject()
        {
            Console.WriteLine("Pasirinkite tema: ");
            int ivestasTemosNr = 0;
            IsveskTemuPavadinimus();
            while (ivestasTemosNr > _subjects.Count || ivestasTemosNr == 0)
            {
                var temosChar = Console.ReadKey().KeyChar;
                int.TryParse(temosChar.ToString(), out ivestasTemosNr);
                if (ivestasTemosNr > _subjects.Count || ivestasTemosNr == 0) Console.WriteLine("\n {0} temos nėra, bandykite iš naujo", ivestasTemosNr);
            }
            Console.Clear();
            Console.WriteLine("\n Temos: {0}", _subjects[ivestasTemosNr - 1]);

            return _subjects[ivestasTemosNr - 1];
        }
        private void IsveskTemuPavadinimus()
        {
            for (int i = 0; i < _subjects.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _subjects[i].Name);
            }
        }
    }
}
