using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Seance
    {
        [Key]
        public int IdSeance { get; set; }
        /**
         * Ce modèle relie le triplet ( Enseignant, Matière, Groupe )
         * Pour l'absence, cette entité refere l'information du triplet precedent.
         * Ainsi le modèle absence contiendra de plus la date précise
         */
        //0900
        public string TempsDebut { get; set; }
        [ForeignKey("TempsDebut")]
        public virtual TempsSeance Debut { get; set; }
        //13:15
        public string TempssFin { get; set; }
        [ForeignKey("TempssFin")]
        public virtual TempsSeance Fin { get; set; }

        //RS
        public string IdEnseignant { get; set; }
        [ForeignKey("IdEnseignant")]
        public ApplicationUser Enseignant { get; set; }

        public int IdMatiere { get; set; }
        [ForeignKey("IdMatiere")]
        public Matiere Matiere { get; set; }

        public int IdGroupe { get; set; }
        [ForeignKey("IdGroupe")]
        public Groupe Groupe { get; set; }
        //Toute absence ayant cette seance 
        public List<Absence> Absences { get; set; }

    }
}
