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


        [Required(ErrorMessage = "Upišite ime.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Koristite samo slova")]
        [DataType(DataType.Text)]
        [Display(Name = "Ime")]
        public string ime { get; set; }


        [Required(ErrorMessage = "Upišite prezime.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Koristite samo slova")]
        [Display(Name = "Prezime")]
        public string prezime { get; set; }

        [Display(Name = "Pamti lozinku.")]
        public bool pamtiLozinku { get; set; }

        public string uloga { get; set; }

        [Required(ErrorMessage = "Upišite lozinku.")]
        [MinLength(7, ErrorMessage = "Upišite minimalno 7 znakova.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }

        [Required(ErrorMessage = "Upišite email.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }
    }
}