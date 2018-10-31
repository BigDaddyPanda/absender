using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class JustificatifAbsence
    {
        [Key]
        public int IdJA{ get; set; }
        public string PreviewJA { get; set; }
        public bool EstAccepte { get; set; }

        public int IdAbsence { get; set; }

        [ForeignKey("IdAbsence")]
        public Absence Absence { get; set; }
    }
}
