using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Niveau
    {
        [Key]
        public int IdNiveau { get; set; }
        public string DesignationNiveau{ get; set; }
        public string TagNiveau { get; set; }


        //Relationships
        public List<Option> Niveauoptions { get; set; }
    }
}
