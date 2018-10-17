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
        public int IdMatiere { get; set; }
        public string DesignationMatiere{ get; set; }
        public int TauxTolereModule { get; set; }


        public int IdModule { get; set; }
        [ForeignKey("IdModule")]
        public Module ModuleMatiere { get; set; }
    }
}
