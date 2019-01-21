using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels.Users
{
    public class Professeur:ApplicationUser
    {
        public string Domaine { get; set; }

        public int Fk_Seance { get; set; }
        [ForeignKey("Fk_Seance")]
        public Seance Ref_Seance { get; set; }

    }
}
