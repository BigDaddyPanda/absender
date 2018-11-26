using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Models.UniversityModels
{
    public class TempsSeance
    {
        [Key]
        public string RepresentationHHMM { get; set; }
        /*
         * 
         * 0900
         * 1030
         * 1045
         * 1215
         * 1315
         * 1445
         * 1500
         * 1630
         * 1345
         * 1515
         * 1530
         * 1700
         * 
         * */
    }
}
