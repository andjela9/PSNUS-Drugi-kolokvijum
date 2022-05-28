using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavnica
{
    class Artikal
    {
        private double cena;
        private int barKod;
        private double porez;
        private double pdv;
        private string poreklo;
        private bool vegan;
        private bool maloletni;
        private double carina;
        private bool osnovnaNamirnica;

        #region Geteri

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
        public double getPdv()
        {
            return pdv;
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


        #endregion 

    }
}
