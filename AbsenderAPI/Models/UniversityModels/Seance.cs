using Newtonsoft.Json;
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
        public int IdSseance { get; set; }
        public int HeureSeance { get; set; }
        [JsonIgnore]
        public int IdFiliere { get; set; }
        [JsonIgnore]
        [ForeignKey("IdGroupe")]
        public Groupe GroupeSeance { get; set; }

        [JsonIgnore]
        public string IdProfesseur{ get; set; }
        [JsonIgnore]
        [ForeignKey("IdProfesseur")]
        public ApplicationUser ProfesseurSeance { get; set; }

        [JsonIgnore]
        public int IdSalle { get; set; }
        [JsonIgnore]
        [ForeignKey("IdSalle")]
        public Salle SalleSeance { get; set; }
    }
}
