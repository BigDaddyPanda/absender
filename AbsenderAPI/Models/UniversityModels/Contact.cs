using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Contact
    {
        [Key]
        public int IdContact { get; set; }



        //RS
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public ApplicationUser User { get; set; }

    }
}
