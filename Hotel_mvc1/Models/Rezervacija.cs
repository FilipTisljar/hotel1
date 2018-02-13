using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Hotel_mvc1.Models
{
    [Table("rezervacija")]
    public class Rezervacija
    {
        [Key]
        [Display(Name = "Id")]
        public int idrezervacija { get; set; }

        public int id_korisnik { get; set; }
        [Required]
        [Display(Name = "Broj sobe")]
        public int id_soba { get; set; }

        [Display(Name = "Cijena")]
        public string cijena { get; set; }

        [Display(Name = "Datum rezervacije")]
        public DateTime datumRezervacije{ get; set; }

        [Required]
        [Display(Name = "Rezervirano od")]
        public DateTime rezerviranoOd { get; set; }

        [Required]
        [Display(Name = "Rezervirano do")]
        public DateTime rezerviranoDo { get; set; }
    }
}