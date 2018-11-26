using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Groupe
    {
        [Key]
        public int IdGroupe { get; set; }
        public string Designation { get; set; }
        public bool EstCoursJour { get; set; } = true;

        //Relationships
        public int IdOption { get; set; }
        [ForeignKey("IdOption")]
        public Option Option { get; set; }

        public List<ApplicationUser> Etudiants{ get; set; }
        public List<Seance> Seances { get; set; }
    }
}
