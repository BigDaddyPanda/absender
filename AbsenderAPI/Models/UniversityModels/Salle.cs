using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Salle
    {
        [Key]
        public int IdSalle { get; set; }
        public string DesignationSalle { get; set; }

    }
}
