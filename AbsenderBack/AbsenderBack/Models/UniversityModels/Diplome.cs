using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Diplome
    {
        [Key]
        public int Id_Diplome { get; set; }
        public string Designation_Orientation { get; set; }
        public string Designation_Formation { get; set; }
        public string Type_Cours { get; set; }

    }
}
