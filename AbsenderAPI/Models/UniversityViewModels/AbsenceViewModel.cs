using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class AbsenceViewModel
    {
        public int IdAbsence { get; set; }
        public string JustificatifAbsence { get; set; }
        public DateTime DateAbsence { get; set; }
        public string IdEtudiant { get; set; }
        public int IdSeance { get; set; }
    }
}
