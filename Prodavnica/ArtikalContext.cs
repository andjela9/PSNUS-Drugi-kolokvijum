using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Prodavnica
{
    public class ArtikalContext : DbContext
    {
        private static ArtikalContext instance;
        public static ArtikalContext Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ArtikalContext();
                }
                return instance;
            }
        }
        private ArtikalContext()
        {

        }
        public DbSet<Artikal> Artikli { get; set; }



    }
}
