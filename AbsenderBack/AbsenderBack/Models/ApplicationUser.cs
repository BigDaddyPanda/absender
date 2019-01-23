using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace AbsenderAPI.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id_Utilisateur { get; set; }
        public string IdNational{ get; set; }
        public string IdUniversitaire{ get; set; }
        public string NomPrenom { get; set; }
        public string PhotoProfil{ get; set; }
        public byte[] Fichier_Profil { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public string Standarized_Email { get; set; }

        [JsonIgnore]
        public string Hash_Password { get; set; }
        [JsonIgnore]
        public bool Email_Confirm { get; set; }
        [JsonIgnore]
        public bool Connect { get; set; }
    }
}
