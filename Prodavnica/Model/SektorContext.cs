using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Prodavnica
{
    public class SektorContext : DbContext
    {
        private static SektorContext instance;
        public static SektorContext Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SektorContext();
                }
                return instance;
            }
        }

        private SektorContext() { }


        public DbSet<Sektor> Sektori { get; set; }
    }
}
