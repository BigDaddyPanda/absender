using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels.Users
{
    public class Etudiant:ApplicationUser
    {
        public string ContactParent { get; set; }

        public int Fk_Groupe { get; set; }
        [ForeignKey("Fk_Groupe")]
        public Groupe Ref_Groupe { get; set; }

        public List<Absence> Progres_absence { get; set; }

    }
}
