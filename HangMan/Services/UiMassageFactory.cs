using HangMan.Interfaces;
using HangManDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan.Services
{
    public class UiMassageFactory : IUiMassageFactory
    {
        private readonly IPictureFactory _pictureFactory;
        public UiMassageFactory()
        {
            _pictureFactory = new PictureFactory();
        }
        public int WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("[[===> HangMan Game <===]]");
            Console.WriteLine("Pasirinkite ką norite veikti");
            Console.WriteLine("1. Statistika ");
            Console.WriteLine("2. Zaidimas");
            Console.WriteLine();
            int choiceNumber = 0;
            while (choiceNumber == 0)
            {
                var choice = Console.ReadKey().KeyChar;
                int.TryParse(choice.ToString(), out choiceNumber);
                if (choiceNumber == 0) Console.WriteLine("\nKlaida! Galima įvesti tik skaičių. Bandykite iš naujo");

            }
            return choiceNumber;
        }
        public string LoginMesage()
        {
            Console.Clear();
            Console.WriteLine("Iveskite savo varda");
            Console.WriteLine();
            return Console.ReadLine();
        }
        public string WordInputMessage()
        {
            Console.WriteLine("\n\nSpekite raide ar zodi");
            return Console.ReadLine();
        }

        public void LostGameMessage(string zodis)
        {
            Console.WriteLine();
            Console.WriteLine("  PRALAIMEJOTE  ");
            Console.WriteLine("Zodis buvo {0} ", zodis);
        }
        public void WinGameMessage(string zodis)
        {
            Console.WriteLine();
            Console.WriteLine("!!! SVEIKINAME !!!! ");
            Console.WriteLine("   ZODIS TEIINGAS   ");
            Console.WriteLine();
            Console.WriteLine("Zodis buvo: {0}", zodis);
        }
        public void HangmanPictureMessage(int incorrectGuessCount)
        {
            _pictureFactory.DisplayPicture(incorrectGuessCount);
        }
        public bool RepeatGameMessage()
        {
            Console.WriteLine("Pakartoti zaidima T/N");
            return Console.ReadKey().KeyChar.ToString().ToUpper() == "T";
        }
        public void IncorrectLettersListMessage(List<string> neteisingiSpejimai)
        {
            Console.WriteLine("\nSpėtos raidės: ");
            foreach (var neteisingasSpejimas in neteisingiSpejimai)
            {
                Console.Write($"{neteisingasSpejimas} ");
            }
        }
        public void PlayerStatisticsMessage(Player player)
        {
            Console.WriteLine($"Žaidėjas {player.Name} žaidė {player.ScoreBoards.Count} kartus.");
            Console.WriteLine($"Iš jų laimėjo {player.ScoreBoards.Count(z=>z.IsCorrect)}");
            Console.WriteLine();
            Console.WriteLine("-=Press any key to continue=-");
            Console.ReadKey();
        }
        public void GeneralStatisticsMessage(List<Player> players)
        {
            Console.Clear();
            foreach (var player in players)
            {
                Console.WriteLine($"Žaidėjas {player.Name} žaidė {player.ScoreBoards.Count} kartus.");
                Console.WriteLine($"Iš jų laimėjo {player.ScoreBoards.Count(z => z.IsCorrect)}");
                Console.WriteLine();
            }
            
            Console.WriteLine("-=Press any key to continue=-");
            Console.ReadKey();
        }
    }

}
