using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_mvc1.Models
{
    [Table("soba")]
    public class Soba
    {
        [Key]
        [Display(Name = "Id")]
        public int idsoba { get; set; }

        public int brojSobe { get; set; }

        public int brojKreveta { get; set; }
    }
}