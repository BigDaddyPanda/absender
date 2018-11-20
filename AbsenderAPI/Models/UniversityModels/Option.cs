using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Option
    {
        [Key]
        public int IdOption { get; set; }

        //Relationships
        public int IdNiveau { get; set; }
        [ForeignKey("IdNiveau")]
        public virtual Niveau Niveau { get; set; }

        public List<Groupe> Groupes { get; set; }
    }
}
