using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Filiere
    {
        public int Id_Filiere { get; set; }
        public string Designation_Niveau { get; set; }
        public string Designation_Filiere { get; set; }
        public string Designation_Option { get; set; }

        public int Fk_Diplome { get; set; }
        [ForeignKey("fk_diplome")]
        public Diplome Ref_Diplome { get; set; }

        public List<Module> Plan_Modules { get; set; }
        public List<Groupe> Groupes { get; set; }
    }
}
