using AbsenderAPI.Models.UniversityModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Seance
    {
        public string Start_Time { get; set; }
        public string End_Time { get; set; }

        public int Fk_Matiere { get; set; }
        public Matiere Ref_Matiere { get; set; }

        public int Fk_Professeur { get; set; }
        public Professeur Ref_Professeur { get; set; }

        public int Fk_Groupe { get; set; }
        public Groupe Ref_Groupe { get; set; }
    }
}
