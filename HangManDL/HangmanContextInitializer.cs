using System.Collections.Generic;
using System.Data.Entity;
using HangManDL.Models;

namespace HangManDL
{
    class HangmanContextInitializer: CreateDatabaseIfNotExists<HangmanContext>
    {
        protected override void Seed(HangmanContext context)
        {
            const string temaVardai = "VARDAI";
            const string temaMiestai = "LIETUVOS MIESTAI";
            const string temaValstybes = "VALSTYBES";
            const string temaBaldai = "BALDAI";

            List<Subject> temos = new List<Subject> {
                     new Subject {
                      Name = temaVardai,
                         Words = new List<Word>
                         {
                         new Word {Text = "Mindaugas"},
                         new Word {Text = "Gediminas"},
                         new Word {Text = "Vytautas"},
                         new Word {Text = "Kestutis"},
                         new Word {Text = "Algirdas"},
                         new Word {Text = "Zygimantas"},
                         new Word {Text = "Birute"},
                         new Word {Text = "Barbora"},
                         new Word {Text = "Augustas"},
                         new Word {Text = "Morta"}
                         }
                     },
            new Subject
            { Name = temaMiestai,
                Words = new List<Word>
                         {
                         new Word {Text = "Vilnius"},
                         new Word {Text = "Klaipeda"},
                         new Word {Text = "Ukmerge"},
                         new Word {Text = "Kaunas"},
                         new Word {Text = "Siauliai"},
                         new Word {Text = "Utena"},
                         new Word {Text = "Varena"},
                         new Word {Text = "Skuodas"},
                         new Word {Text = "Panevezys"},
                         new Word {Text = "Raseiniai"}
                         }
            },
            new Subject { Name = temaValstybes,
                Words = new List<Word>
                         {
                         new Word {Text = "Kinija"},
                         new Word {Text = "Prancuzija"},
                         new Word {Text = "Estija"},
                         new Word {Text = "Norvegija"},
                         new Word {Text = "Taivanas"},
                         new Word {Text = "Indija"},
                         new Word {Text = "Meksika"},
                         new Word {Text = "Suomija"},
                         new Word {Text = "Indija"},
                         new Word {Text = "Portugalija"}
                         }
            },
                     new Subject {Name = temaBaldai,
                     Words =new List<Word>
                         {
                         new Word {Text = "Stalas"},
                         new Word {Text = "Kede"},
                         new Word {Text = "Spinta"},
                         new Word {Text = "Lova"},
                         new Word {Text = "Suolas"},
                         new Word {Text = "Sofa"},
                         new Word {Text = "Lempa"},
                         new Word {Text = "Durys"},
                         new Word {Text = "Kilimas"},
                         new Word {Text = "Veidrodis"},
                         }
                 },
            };
            context.Subjects.AddRange(temos);
        }
    }
}
