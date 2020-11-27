using HangManDL.Models;
using System.Collections.Generic;

namespace HangManBL.Interfaces
{
    public interface IReadRepository
    {
        List<Subject> GetAllSubjects();
    }
}
