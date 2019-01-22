using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Matiere
    {
        [Key]
        public int Id_Matiere { get; set; }
        public string Designation_Matiere { get; set; }
        public float Coefficient { get; set; }
        public float Limite_Absence { get; set; }

        public int Fk_Module { get; set; }
        [Display(Name ="Module")]
        [ForeignKey("Fk_Module")]
        public Module Ref_Module { get; set; }

        public List<Seance> List_Seances { get; set; }
    }
}
