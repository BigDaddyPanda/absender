using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Contact
    {
        [Key]
        public int IdContact { get; set; }
        public string TypeContact { get; set; }
        public string ValeurContact { get; set; }
        public string ClassificationContact { get; set; }
    }
}
