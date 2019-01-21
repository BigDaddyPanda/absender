using AbsenderAPI.Models.UniversityModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Absence
    {
        public string Justificatif { get; set; }
        public DateTime Date_sauvegarde { get; set; }
        public bool estAbsent { get; set; }


        public string Fk_Etudiant { get; set; }
        public Etudiant Ref_Etudiant { get; set; }

        public int Fk_Seance { get; set; }
        public Seance Ref_Seance { get; set; }


    }
}
