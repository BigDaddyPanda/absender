using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class FiliereModuleAssociation
    {
        public int IdFiliere { get; set; }
        public int IdModule { get; set; }
        [ForeignKey("IdModule")]
        public Module Module { get; set; }
        [ForeignKey("IdFiliere")]
        public Filiere Filiere { get; set; }

    }
}
