using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hotel_mvc1.Models
{
    public class hotelBazaContext : DbContext
    {
        //dodavanjae svih baza
        public DbSet<Soba> soba { get; set; }
        public DbSet<Korisnik> korisnik { get; set; }
        public DbSet<Rezervacija> rezervacija { get; set; }
    }
}