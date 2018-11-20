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

        //Relationships
        public List<Option> niveauoptions { get; set; }
    }
}
