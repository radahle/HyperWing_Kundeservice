using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KundeService.Models
{
    public class brukerSprsml
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[\\w\\W]{2,250}$")]
        public string sprsml { get; set; }
        [Required]
        public string email { get; set; }
    }

    public class faq
    {
        public int id { get; set; }
        public string kategori { get; set; }
        public string sprsml { get; set; }
        public string svar { get; set; }
    }

}