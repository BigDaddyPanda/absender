using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class GroupeViewModel
    {
        public int IdGroupe { get; set; }
        public string Designation { get; set; }
        public bool EstCoursJour { get; set; }
        public int IdOption { get; set; }
    }
}
