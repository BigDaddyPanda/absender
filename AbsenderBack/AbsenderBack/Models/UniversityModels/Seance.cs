using AbsenderAPI.Models.UniversityModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Seance
    {
        [Key]
        public int Id_Seance { get; set; }
        public string Day_Of_The_Week { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }

        public int? Fk_Matiere { get; set; }
        [ForeignKey("Fk_Matiere")]
        public Matiere Ref_Matiere { get; set; }

        public string Fk_Professeur { get; set; }
        [ForeignKey("Fk_Professeur")]
        public Professeur Ref_Professeur { get; set; }

        public int? Fk_Groupe { get; set; }
        [ForeignKey("Fk_Groupe")]
        public Groupe Ref_Groupe { get; set; }
    }
}
