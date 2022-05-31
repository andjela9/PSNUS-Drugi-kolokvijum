using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prodavnica
{
    public class Sektor
    {
        private string nazivSektora;
        private int brojZaposlenihSektora;
        private double povrsinaSektora;
        private int maxBrojArtikalaSektora;
        private int idSektora;
        private double plataSektora;
        private int brFrizideraSektora;
        private int brojMenadzeraSektora;
        private string bojaUniformeSektora;
        private int zaposlenihUSmeniSektora;

        public Sektor(string naziv, int brojZaposlenih, double povrsina, int maxBrojArtikala, int sifraSektora, double plata, int brFrizidera, int brojMenadzera, string bojaUniforme, int zaposlenihUSmeni)
        {
            this.nazivSektora = naziv;
            this.brojZaposlenihSektora = brojZaposlenih;
            this.povrsinaSektora = povrsina;
            this.maxBrojArtikalaSektora = maxBrojArtikala;
            this.idSektora = sifraSektora;
            this.plataSektora = plata;
            this.brFrizideraSektora = brFrizidera;
            this.brojMenadzeraSektora = brojMenadzera;
            this.bojaUniformeSektora = bojaUniforme;
            this.zaposlenihUSmeniSektora = zaposlenihUSmeni;
        }
        public Sektor() { }
        public event PropertyChangedEventHandler PropertyChanged;
        #region Geteri

        public string NazivSektora
        {
            get
            {
                return nazivSektora;
            }
            set
            {
                nazivSektora = value;
                OnPropertyChanged("NazivSektora");
            }
        }
        public int BrojZaposlenihSektora
        {
            get{ return brojZaposlenihSektora; }
            set
            {
                brojZaposlenihSektora = value;
                OnPropertyChanged("BrojZaposlenihSektora");
            }
            
        }
        public int BrojMenadzeraSektora
        {
            get
            {
                return brojMenadzeraSektora;
            }
            set
            {
                brojMenadzeraSektora = value;
                OnPropertyChanged("BrojMenadzeraSektora");
            }
        }
        public double PovrsinaSektora
        {
            get
            {
                return povrsinaSektora;
            }
            set
            {
                povrsinaSektora = value;
                OnPropertyChanged("PovrsinaSektora");
            }
        }
        public int MaxBrojArtikalaSektora
        {
            get
            {
                return maxBrojArtikalaSektora;
            }
            set
            {
                maxBrojArtikalaSektora = value;
                OnPropertyChanged("MaxBrojArtikalaSektora");
            }
        }
        public int SifraSektora
        {
            get
            {
                return idSektora;
            }
            set
            {
                idSektora = value;
                OnPropertyChanged("SifraSektora");
            }
        }
        public double PlataSektora
        {
            get
            {
                return plataSektora;
            }
            set
            {
                plataSektora = value;
                OnPropertyChanged("Plata");
            }
        }
        public int BrFrizideraSektora
        {
            get
            {
                return brFrizideraSektora;
            }
            set
            {
                brFrizideraSektora = value;
                OnPropertyChanged("BrFrizidera");
            }
        }
        public string BojaUniforme
        {
            get
            {
                return bojaUniformeSektora;
            }
            set
            {
                bojaUniformeSektora = value;
                OnPropertyChanged("BojaUniforme");
            }
        }
        public int ZaposlenihUSmeni
        {
            get
            {
                return zaposlenihUSmeniSektora;
            }
            set
            {
                zaposlenihUSmeniSektora = value;
                OnPropertyChanged("ZaposlenihUSmeniSektora");
            }
        }
        #endregion


        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }



    }
}
