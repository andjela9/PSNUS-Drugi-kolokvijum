using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavnica
{
    class Sektor
    {
        private string naziv;
        private int brojZaposlenih;
        private double povrsina;
        private int maxBrojArtikala;
        private int sifraSektora;
        private double plata;

        #region Geteri
        public string getNaziv()
        {
            return naziv;
        }
        public int getBarKod()
        {
            return barkod;
        }
        public int getbrojZaposlenih()
        {
            return brojZaposlenih;
        }
        public double getPovrsina()
        {
            return povrsina;
        }
        public int getMaxBrojArtikala()
        {
            return maxBrojArtikala;
        }
        public int getSifraSektora()
        {
            return sifraSektora;
        }
        public double getPlata()
        {
            return plata;
        }
        #endregion






    }
}
