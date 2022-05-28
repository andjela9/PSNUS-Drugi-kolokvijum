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
        private int brFrizidera;
        private int brojMenadzera;
        private string bojaUniforme;
        private int zaposlenihUSmeni;

        #region Geteri
        public string getNaziv()
        {
            return naziv;
        }
        public int getBrojZaposlenih()
        {
            return brojZaposlenih;
        }
        public int getBrojMenadzera()
        {
            return brojMenadzera;
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
        public int getBrFrizidera()
        {
            return brFrizidera;
        }
        public string getBojaUniforme()
        {
            return bojaUniforme;
        }
        public int getZaposlenihUSmeni()
        {
            return zaposlenihUSmeni;
        }
        #endregion






    }
}
