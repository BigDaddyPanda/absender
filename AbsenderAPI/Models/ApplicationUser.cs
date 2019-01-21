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
    public class ApplicationUser : IdentityUser
    {
        public string IdNational{ get; set; }
        public string IdUniversitaire{ get; set; }
        public string PhotoProfil{ get; set; }
    }
}
