using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class Panier
    {
        [Key]
        public int IdPanier { get; set; }
        public string DesignationPanier { get; set; }
        public string TagPanier { get; set; }

        public List<Matiere> Matieres { get; set; }
    }
}
