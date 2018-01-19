using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}