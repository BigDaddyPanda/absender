using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Module
    {
        [Key]
        public int IdModule { get; set; }
        public string DesignationModule{ get; set; }

    }
}
