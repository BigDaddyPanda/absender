using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class PanierViewModel
    {
        public int IdPanier { get; set; }
        public string DesignationPanier { get; set; }
        public string TagPanier { get; set; }
    }
}
