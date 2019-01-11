using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityViewModels
{
    public class ContactViewModel
    {
        public string Designation { get; set; }
        public string Valeur { get; set; }
        public string IdUser { get; set; }

    }
}
