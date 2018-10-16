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
        public string DesignationFiliere { get; set; }//CII
        public string DesignationOption { get; set; }//DSEN
        public string DesignationClasse { get; set; }//DSEN1
        public bool EstCoursSoire { get; set; }
        [JsonIgnore]
        public List<ApplicationUser> EtudiantsFiliere{ get; set; }
        [JsonIgnore]
        public List<Module> ModuleAssocies { get; set; }
    }
}
