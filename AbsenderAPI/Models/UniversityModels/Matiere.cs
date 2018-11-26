using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }
        public string DesignationMatiere { get; set; }
        public string TagMatiere { get; set; }
        public int Coefficient { get; set; }

        public decimal VolumeHoraire { get; set; }
        public decimal TauxTolere { get; set; }
        //RS
        public int IdPanier { get; set; }
        [ForeignKey("IdPanier")]
        public Panier Panier { get; set; }

        public List<Seance> Seances { get; set; }

    }
}
