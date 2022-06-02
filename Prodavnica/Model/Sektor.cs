using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prodavnica
{
    public class Sektor : INotifyPropertyChanged
    {
        private string nazivSektora;
        private int idSektora;
        private double povrsinaSektora;
        private int maxBrojArtikalaSektora;
        private int brojZaposlenihSektora;
        private double plataSektora;
        private int brFrizideraSektora;
        private int brojMenadzeraSektora;
        private string bojaUniformeSektora;
        private int zaposlenihUSmeniSektora;

        public Sektor(string naziv, int brojZaposlenih, double povrsina, int maxBrojArtikala, int idSektora, double plata, int brFrizidera, int brojMenadzera, string bojaUniforme, int zaposlenihUSmeni)
        {
            this.nazivSektora = naziv;
            this.brojZaposlenihSektora = brojZaposlenih;
            this.povrsinaSektora = povrsina;
            this.maxBrojArtikalaSektora = maxBrojArtikala;
            this.idSektora = idSektora;
            this.plataSektora = plata;
            this.brFrizideraSektora = brFrizidera;
            this.brojMenadzeraSektora = brojMenadzera;
            this.bojaUniformeSektora = bojaUniforme;
            this.zaposlenihUSmeniSektora = zaposlenihUSmeni;
        }
        public Sektor() { }
        public event PropertyChangedEventHandler PropertyChanged;
        #region Geteri i seteri

        [Key]
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
        public int IdSektora
        {
            get
            {
                return idSektora;
            }
            set
            {
                idSektora = value;
                OnPropertyChanged("IdSektora");
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
                OnPropertyChanged("PlataSektora");
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
                OnPropertyChanged("BrFrizideraSektora");
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
                OnPropertyChanged("ZaposlenihUSmeni");
            }
        }
        #endregion


        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }



    }
}
