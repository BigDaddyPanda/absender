using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class SeanceViewModel
    {
        public int IdSeance { get; set; }
        public string TempsDebut { get; set; }
        public string TempsFin { get; set; }
        public string IdEnseignant { get; set; }
        public int IdMatiere { get; set; }
        public int IdGroupe { get; set; }
    }
}
