using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Module
    {
        [Key]
        public int Id_Module { get; set; }
        public string Designation_Module { get; set; }

        public int Fk_Filiere { get; set; }
        [Display(Name ="Filiere")]
        [ForeignKey("Fk_Filiere")]
        public Filiere Ref_Filiere { get; set; }

        public List<Matiere> Matiere_Associees { get; set; }
    }
}
