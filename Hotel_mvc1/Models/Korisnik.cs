using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_mvc1.Models
{
    [Table("korisnik")]
    public class Korisnik
    {
        [Key]
        [Display(Name = "Id")]
        public int idkorisnik { get; set; }

        public string ime { get; set; }

        public string prezime { get; set; }

        public bool pamtiLozinku { get; set; }

        public string uloga { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string lozinka { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }
    }
}