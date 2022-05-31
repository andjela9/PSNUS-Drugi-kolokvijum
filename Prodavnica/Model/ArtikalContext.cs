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
            }                   //ne treba set da ne bi neko da setuje instance na null
        }
        private ArtikalContext()                //ovo mora da bude private zbog singletona
        {

        }
        public DbSet<Artikal> Artikli { get; set; }



    }
}
