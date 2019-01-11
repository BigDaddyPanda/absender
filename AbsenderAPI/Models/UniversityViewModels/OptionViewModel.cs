using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class OptionViewModel
    {
        public int IdOption { get; set; }
        public string DesignationOption { get; set; }
        public string TagOption { get; set; }
        public int IdNiveau { get; set; }

    }
}
