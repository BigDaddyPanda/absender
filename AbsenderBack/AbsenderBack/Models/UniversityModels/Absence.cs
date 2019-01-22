using AbsenderAPI.Models.UniversityModels.Users;
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
        public int Id_Absence { get; set; }
        public string Justificatif { get; set; }
        public DateTime Date_sauvegarde { get; set; }
        public bool EstAbsent { get; set; }


        public string Fk_Etudiant { get; set; }
        [ForeignKey("Fk_Etudiant")]
        public Etudiant Ref_Etudiant { get; set; }

        public int Fk_Seance { get; set; }
        [ForeignKey("Fk_Seance")]
        public Seance Ref_Seance { get; set; }


    }
}
