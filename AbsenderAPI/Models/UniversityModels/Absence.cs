using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Absence
    {
        [Key]
        public int IdAbsence { get; set; }
        public string JustificatifAbsence { get; set; } = "aucun";
        public DateTime DateAbsence { get; set; } = DateTime.Now;

        //RS
        public string IdEtudiant { get; set; }
        [ForeignKey("IdEtudiant")]
        public virtual ApplicationUser Etudiant { get; set; }

        public int IdSeance { get; set; }
        [ForeignKey("IdSeance")]
        public virtual Seance Seance { get; set; }
    }
}
