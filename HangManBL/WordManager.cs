using System.Collections.Generic;
using System.Linq;
using HangManBL.Interfaces;
using HangManDL;
using HangManDL.Models;
using System.Data.Entity;

namespace HangManBL
{
    public class WordManager : IReadRepository
    {
        public List<Subject> GetAllSubjects()
        {
            List<Subject> list;
            using (var context = new HangmanContext())
            {
                list = context.Subjects.Include(e => e.Words).ToList();
            }
            return list;
        }
    }
}
