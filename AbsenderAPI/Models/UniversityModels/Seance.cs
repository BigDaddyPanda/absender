using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Seance
    {
        [Key]
        public int IdSseance { get; set; }
        public int HeureSeance { get; set; }
    }
}
