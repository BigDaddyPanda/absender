using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Filiere
    {
        [Key]
        public int IdFiliere { get; set; }
        public string TagFiliere { get; set; } // CII
        public string DesignationFiliere { get; set; } // Complete Internation Inst.
        public string TagOption { get; set; } // DSEN
        public string DesignationOption { get; set; } //DataScienceENgineering
        //[JsonIgnore]
        public List<Module> ModuleAssocies { get; set; }
    }
}
