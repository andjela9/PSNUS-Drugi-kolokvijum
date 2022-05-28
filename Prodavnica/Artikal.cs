using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavnica
{
    class Artikal
    {
        private string naziv;
        private string proizvodjac;
        private double cena;
        private int barKod;
        private double porez;
        private double akciza;
        private string poreklo;
        private bool vegan;
        private bool maloletni;
        private double carina;
        private bool osnovnaNamirnica;
        private int rokTrajanja;
        

        #region Geteri
        public string getNaziv()
        {
            return naziv;
        }
        public double getCena()
        {
            return cena;
        }
        public int getBarKod()
        {
            return barKod;
        }
        public double getPorez()
        {
            return porez;
        }
        public double getAkciza()
        {
            return akciza;
        }
        public string getPoreklo()
        {
            return poreklo;
        }
        public bool getVegan()
        {
            return vegan;
        }
        public bool getMaloletni()
        {
            return maloletni;
        }
        public double getCarina()
        {
            return carina;
        }
        public bool getOsnovnaNamirnica()
        {
            return osnovnaNamirnica;
        }
        public string getProizvodjac()
        {
            return proizvodjac;
        }
        public int getRokTrajanja() 
        {
            return rokTrajanja;
        }


        #endregion 

    }
}
