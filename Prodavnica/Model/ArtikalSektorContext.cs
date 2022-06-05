using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Prodavnica
{
    public class ArtikalSektorContext : DbContext
    {
        private static ArtikalSektorContext instance;
        public static ArtikalSektorContext Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ArtikalSektorContext();
                }
                return instance;
            }                   //ne treba set da ne bi neko mogao da setuje instance na null
        }
        public ArtikalSektorContext()                //ovo mora da bude private zbog singletona
        {

        }
        public DbSet<Artikal> Artikli { get; set; }             //ovim se pravi tabela preko entity
        public DbSet<Sektor> Sektori { get; set; }



    }
}
