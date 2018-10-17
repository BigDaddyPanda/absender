using Newtonsoft.Json;
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
        public string DesignationGroupe { get; set; } //DSEN-2-Cours-Soir
        public string NombreEtudiant { get; set; } // 69

        public bool EstCoursSoire { get; set; } // True
        [JsonIgnore]
        public List<ApplicationUser> EtudiantsFiliere { get; set; }

        public int IdFiliere { get; set; }
        [ForeignKey("IdFiliere")]
        public Filiere FiliereGroupe { get; set; }
    }
}
