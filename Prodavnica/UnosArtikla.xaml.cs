using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prodavnica
{
    /// <summary>
    /// Interaction logic for UnosArtikla.xaml
    /// </summary>
    public partial class UnosArtikla : Window
    {
        private Artikal noviArtikal = new Artikal();
        public bool IsUpdate { get; set; }
        
        public UnosArtikla(Artikal unetArtikal)
        {
            InitializeComponent();
            

            if (unetArtikal != null)
            {
                //deep copy
                noviArtikal.Naziv = unetArtikal.Naziv;
                noviArtikal.BarKod = unetArtikal.BarKod;
                noviArtikal.Akciza = unetArtikal.Akciza;
                noviArtikal.Carina = unetArtikal.Carina;
                noviArtikal.Cena = unetArtikal.Cena;
                noviArtikal.Maloletni = unetArtikal.Maloletni;
                noviArtikal.OsnovnaNamirnica = unetArtikal.OsnovnaNamirnica;
                noviArtikal.Poreklo = unetArtikal.Poreklo;
                noviArtikal.Porez = unetArtikal.Porez;
                noviArtikal.Proizvodjac = unetArtikal.Proizvodjac;
                noviArtikal.Posno = unetArtikal.Posno;
                noviArtikal.RokTrajanja = unetArtikal.RokTrajanja;
                noviArtikal.NazivSektora = unetArtikal.NazivSektora;

                AddOrUpdate.Title = "Azuriranje artikla";
                IsUpdate = true;
                nazivTxt.IsReadOnly = true;
                Zaglavlje.Text = "Azuriranje postojeceg artikla";
            }
            else
            {
                AddOrUpdate.Title = "Dodavanje novog artikla";
                nazivTxt.IsReadOnly = false;
                IsUpdate = false;
                Zaglavlje.Text = "Unos novog artikla";
            }


            this.DataContext = noviArtikal;
            this.posnoCombo.ItemsSource = new List<String> { "DA", "NE", "NEPOZNATO"};
            this.maloletniCombo.ItemsSource = new List<String> { "DA", "NE" };
            this.osnovnaNamirnicaCombo.ItemsSource = new List<String> { "DA", "NE" };
            
            var sektori = ArtikalSektorContext.Instance.Sektori.Local;
            List<String> naziviSektora = new List<string>();
            foreach(var sektor in sektori)
            {
                naziviSektora.Add(sektor.NazivSektora);
            }
            this.SektorListBox.ItemsSource = naziviSektora;
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (IsUpdate)
                {
                    Artikal updateArtikal = ArtikalSektorContext.Instance.Artikli.SingleOrDefault(art => art.Naziv == noviArtikal.Naziv);               //onaj objekat ciji je naziv isti
                    if(updateArtikal != null)
                    {
                        MainWindow.SelectedArtikal.Naziv = noviArtikal.Naziv;
                        MainWindow.SelectedArtikal.BarKod = noviArtikal.BarKod;
                        MainWindow.SelectedArtikal.Akciza = noviArtikal.Akciza;
                        MainWindow.SelectedArtikal.Carina = noviArtikal.Carina;
                        MainWindow.SelectedArtikal.Cena = noviArtikal.Cena;
                        MainWindow.SelectedArtikal.Maloletni = noviArtikal.Maloletni;
                        MainWindow.SelectedArtikal.OsnovnaNamirnica = noviArtikal.OsnovnaNamirnica;
                        MainWindow.SelectedArtikal.Poreklo = noviArtikal.Poreklo;
                        MainWindow.SelectedArtikal.Porez = noviArtikal.Porez;
                        MainWindow.SelectedArtikal.Posno = noviArtikal.Posno;
                        MainWindow.SelectedArtikal.RokTrajanja = noviArtikal.RokTrajanja;
                        MainWindow.SelectedArtikal.NazivSektora = noviArtikal.NazivSektora;

                        ArtikalSektorContext.Instance.Entry(updateArtikal).State = System.Data.Entity.EntityState.Modified;     //da se zna da je apdejtovano stanje objekta unutar baze
                    }
                }
                else
                {
                    ArtikalSektorContext.Instance.Artikli.Add(noviArtikal);
                }

                try
                {
                    ArtikalSektorContext.Instance.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unet je artikal sa istim nazivom. Artikal nece biti dodat!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    ArtikalSektorContext.Instance.Artikli.Remove(noviArtikal);
                    
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Greska u unosu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            bool retVal = true;

            // validacija polja naziv
            if (String.IsNullOrWhiteSpace(nazivTxt.Text))
            {
                nazivTxt.BorderBrush = Brushes.Red;
                nazivVal.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                nazivTxt.ClearValue(Border.BorderBrushProperty);
                nazivVal.Visibility = Visibility.Hidden;
            }

            // validacija polja proizvodjac
            if (String.IsNullOrWhiteSpace(proizvodjacTxt.Text))
            {
                proizvodjacTxt.BorderBrush = Brushes.Red;
                proizvodjacVal.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                proizvodjacTxt.ClearValue(Border.BorderBrushProperty);
                proizvodjacVal.Visibility = Visibility.Hidden;
            }


            //validacija posno
            if(posnoCombo.SelectedIndex == -1)
            {
                retVal = false;
                //posnoCombo.BorderBrush = Brushes.Red;
                posnoVal.Visibility = Visibility.Visible;
                posnoCombo.ClearValue(Border.BorderBrushProperty);
            }
            else
            {
                //posnoCombo.BorderBrush = Brushes.Black;
                posnoVal.Visibility = Visibility.Hidden;
                posnoCombo.ClearValue(Border.BorderBrushProperty);
            }

            //validacija sektora
            if(SektorListBox.SelectedIndex == -1)
            {
                retVal = false;
                sektorVal.Visibility = Visibility.Visible;
            }
            else
            {
                SektorListBox.ClearValue(Border.BorderBrushProperty);
                sektorVal.Visibility = Visibility.Hidden;
            }

            //validacija maloletni
            if (maloletniCombo.SelectedIndex == -1)
            {
                retVal = false;
                maloletniVal.Visibility = Visibility.Visible;
                maloletniCombo.BorderBrush = Brushes.Red;
            }
            else
            {
                posnoCombo.BorderBrush = Brushes.Black;
                maloletniVal.Visibility = Visibility.Hidden;
            }

            //validacija osnovna namirnica
            if (osnovnaNamirnicaCombo.SelectedIndex == -1)
            {
                retVal = false;
                osnovnaNamirnicaCombo.BorderBrush = Brushes.Red;
                osnovnaVal.Visibility = Visibility.Visible;
            }
            else
            {
                osnovnaNamirnicaCombo.BorderBrush = Brushes.Black;
                osnovnaVal.Visibility = Visibility.Hidden;
            }

            //validacija polja cena
            if (String.IsNullOrWhiteSpace(cenaTxt.Text))
            {
                cenaTxt.BorderBrush = Brushes.Red;
                cenaVal.Visibility = Visibility.Visible;
                retVal = false;

            }
            else
            {
                double cena;
                if (Double.TryParse(cenaTxt.Text, out cena))
                {
                    if (cena <= 0)
                    { 
                        cenaTxt.BorderBrush = Brushes.Red;
                        cenaVal.Visibility = Visibility.Visible;
                        cenaVal.Text = "Cena mora biti pozitivan broj!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        cenaTxt.ClearValue(Border.BorderBrushProperty);
                        cenaVal.Visibility = Visibility.Hidden;
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    cenaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    cenaVal.Text = "Cena mora biti pozitivan broj!";
                    retVal = false;
                }
            }

            //validacija polja barkod
            if (String.IsNullOrWhiteSpace(barkodTxt.Text))
            {
                //barkodTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
                barkodVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int barkod;
                if (Int32.TryParse(barkodTxt.Text, out barkod))
                {
                    if (barkod <= 0)
                    {
                        barkodTxt.BorderBrush = Brushes.Red;
                        barkodVal.Text = "Bar kod mora biti pozitivan broj!";
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        barkodVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        barkodTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                        barkodVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    barkodTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja porez
            if (String.IsNullOrWhiteSpace(porezTxt.Text))
            {
                porekloTxt.BorderBrush = Brushes.Red;
                porezVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                double porez;
                if (Double.TryParse(porezTxt.Text, out porez))
                {
                    if (porez <= 0)
                    {
                        porezTxt.BorderBrush = Brushes.Red;
                        porezVal.Visibility = Visibility.Visible;
                        porezVal.Text = "Porez mora biti pozitivan broj!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        
                        retVal = false;
                    }
                    else
                    {
                        porezTxt.ClearValue(Border.BorderBrushProperty);
                        porezVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    porezTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    porezVal.Text = "Porez mora biti pozitivan broj!";
                    retVal = false;
                }
            }


            // validacija polja akciza
            if (String.IsNullOrWhiteSpace(akcizaTxt.Text))
            {
                akcizaTxt.BorderBrush = Brushes.Red;
                akcizaVal.Visibility = Visibility.Visible;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                double akciza;
                if (Double.TryParse(akcizaTxt.Text, out akciza))
                {
                    if (akciza <= 0)
                    {
                        akcizaTxt.BorderBrush = Brushes.Red;
                        akcizaVal.Visibility = Visibility.Visible;
                        akcizaVal.Text = "Akciza mora biti pozitivan broj!";
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        akcizaTxt.ClearValue(Border.BorderBrushProperty);
                        akcizaVal.Visibility = Visibility.Hidden;
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    akcizaTxt.BorderBrush = Brushes.Red;
                    akcizaVal.Text = "Akciza mora biti pozitivan broj!";
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja poreklo
            if (String.IsNullOrWhiteSpace(porekloTxt.Text))
            {
                porekloTxt.BorderBrush = Brushes.Red;
                porekloVal.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                porekloTxt.ClearValue(Border.BorderBrushProperty);
                porekloVal.Visibility = Visibility.Hidden;
            }


            // validacija polja carina
            if (String.IsNullOrWhiteSpace(carinaTxt.Text))
            {
                carinaTxt.Text = "Obavezno polje!";
                carinaTxt.BorderBrush = Brushes.Red;
                carinaVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                double carina;
                if (Double.TryParse(carinaTxt.Text, out carina))
                {
                    if (carina <= 0)
                    {
                        carinaTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        carinaVal.Text = "Carina mora biti pozitivan broj";
                        carinaVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        carinaTxt.ClearValue(Border.BorderBrushProperty);
                        carinaVal.Visibility = Visibility.Hidden;
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    carinaTxt.BorderBrush = Brushes.Red;
                    carinaVal.Text = "Carina mora biti pozitivan broj!";
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            // validacija polja rok trajanja
            if (String.IsNullOrWhiteSpace(rokTrajanjaTxt.Text))
            {
                rokTrajanjaTxt.Text = "Obavezno polje";
                //ageValTxt.Visibility = Visibility.Visible;
                rokVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int rokTrajanja;
                if (Int32.TryParse(rokTrajanjaTxt.Text, out rokTrajanja))
                {
                    if (rokTrajanja <= 0)
                    {
                        rokTrajanjaTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        rokVal.Text = "Rok trajanja mora biti pozitivan broj!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        rokVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        rokTrajanjaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                        rokVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    rokTrajanjaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    rokVal.Text = "Rok trajanja mora biti broj!";
                    retVal = false;
                }
            }


            return retVal;
        }

    }
}
