using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AbsenderAPI.Models;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Absence
    {
        [Key]
        public int IdAbsence { get; set; }
        public int TauxAbsence { get; set; }
        public string MessageAbsence { get; set; }

        public string IdUtilisateur { get; set; }
        public int IdMatiere { get; set; }
        [ForeignKey("IdMatiere")]
        public Matiere Matiere { get; set; }

        [ForeignKey("IdUtilisateur")]
        public ApplicationUser User{ get; set; }
    }
}
