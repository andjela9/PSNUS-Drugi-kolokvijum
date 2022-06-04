using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prodavnica
{
    public class Artikal : INotifyPropertyChanged
    {
        private string naziv;
        private string proizvodjac;
        private double cena;
        private int barKod;
        private double porez;
        private double akciza;
        private string poreklo;
        private string posno;
        private string maloletni;
        private double carina;
        private string osnovnaNamirnica; 
        private int rokTrajanja;

        public Artikal(string naziv, string proizvodjac, double cena, int barKod, double porez, double akciza, string poreklo, string posno, string maloletni, double carina, string osnovnaNamirnica, int rokTrajanja)
        {
            this.naziv = naziv;
            this.proizvodjac = proizvodjac;
            this.cena = cena;
            this.barKod = barKod;
            this.porez = porez;
            this.akciza = akciza;
            this.poreklo = poreklo;
            this.posno = posno;
            
            this.maloletni = maloletni;
            this.carina = carina;
            this.osnovnaNamirnica = osnovnaNamirnica;
            this.rokTrajanja = rokTrajanja;
        }
        public Artikal() { }
        public event PropertyChangedEventHandler PropertyChanged;


        #region Geteri i seteri

        [Key]
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
            
        }
        //TODO za sektor
        
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }
        public int BarKod
        {
            get {  return barKod; }
            set
            {
                barKod = value;
                OnPropertyChanged("BarKod");
            }
         }

        public string Posno
        {
            get { return posno; }
            set
            {
                posno = value;
                OnPropertyChanged("Posno");
            }
        }

    
        public double Porez
        {
            get { return porez; }
            set
            {
                porez = value;
                OnPropertyChanged("Porez");
            }
        }
        public double Akciza
        {
            get { return akciza; }
            set
            {
                akciza = value;
                OnPropertyChanged("Akciza");
            }
        }
        public string Poreklo
        {
            get { return poreklo; }
            set
            {
                poreklo = value;
                OnPropertyChanged("Poreklo");
            }
        }
        
        public string Maloletni
        {
            get
            {
                return maloletni;
            }
            set
            {
                maloletni = value;
                OnPropertyChanged("Maloletni");
            }
         }
        public double Carina
        {
            get
            {
                return carina;
            }
            set
            {
                carina = value;
                OnPropertyChanged("Carina");
            }
         }
        public string OsnovnaNamirnica
        {
            get
            {
                return osnovnaNamirnica;
            }
            set
            {
                osnovnaNamirnica = value;
                OnPropertyChanged("OsnovnaNamirnica");
            }
         }
        public string Proizvodjac
        {
            get
            {
                return proizvodjac;
            }
            set
            {
                proizvodjac = value;
                OnPropertyChanged("Proizvodjac");
            }
         }
        public int RokTrajanja
        {
            get
            {
                return rokTrajanja;
            }
            set
            {
                rokTrajanja = value;
                OnPropertyChanged("RokTrajanja");
            }
         }
        #endregion 

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        

    }
}
