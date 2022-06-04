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


            if(unetArtikal != null)
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
                noviArtikal.Vegan = unetArtikal.Vegan;
                noviArtikal.RokTrajanja = unetArtikal.RokTrajanja;

                AddOrUpdate.Title = "Update artikla";
                IsUpdate = true;
                nazivTxt.IsReadOnly = true;
                Zaglavlje.Text = "Update postojeceg artikla";
            }
            else
            {
                AddOrUpdate.Title = "Dodavanje novog artikla";
                nazivTxt.IsReadOnly = false;
                IsUpdate = false;
                Zaglavlje.Text = "Unos novog artikla";
            }


            this.DataContext = noviArtikal;


            //this.departmentCombo.ItemsScource = new List<string> {"DA", "NE"};
            
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
                        updateArtikal.Naziv = noviArtikal.Naziv;
                        updateArtikal.BarKod = noviArtikal.BarKod;
                        updateArtikal.Akciza = noviArtikal.Akciza;
                        updateArtikal.Carina = noviArtikal.Carina;
                        updateArtikal.Cena = noviArtikal.Cena;
                        updateArtikal.Maloletni = noviArtikal.Maloletni;
                        updateArtikal.OsnovnaNamirnica = noviArtikal.OsnovnaNamirnica;
                        updateArtikal.Poreklo = noviArtikal.Poreklo;
                        updateArtikal.Porez = noviArtikal.Porez;
                        updateArtikal.Proizvodjac = noviArtikal.Proizvodjac;
                        updateArtikal.Vegan = noviArtikal.Vegan;
                        updateArtikal.RokTrajanja = noviArtikal.RokTrajanja;

                        ArtikalSektorContext.Instance.Entry(updateArtikal).State = System.Data.Entity.EntityState.Modified;     //da se zna da je apdejtovano stanje objekta unutar baze
                    }
                }
                else
                {
                    ArtikalSektorContext.Instance.Artikli.Add(noviArtikal);
                }

                ArtikalSektorContext.Instance.SaveChanges();
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
                //indexValTxt.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                nazivTxt.ClearValue(Border.BorderBrushProperty);
                //indexValTxt.Visibility = Visibility.Hidden;
            }

            // validacija polja proizvodjac
            if (String.IsNullOrWhiteSpace(proizvodjacTxt.Text))
            {
                proizvodjacTxt.BorderBrush = Brushes.Red;
                //firstNameValTxt.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                proizvodjacTxt.ClearValue(Border.BorderBrushProperty);
                //firstNameValTxt.Visibility = Visibility.Hidden;
            }

           // if(VeganDa.IsChecked == false && VeganNe.IsChecked == false)
           // {
            //    VeganDa.BorderBrush = Brushes.Red;
            //    VeganNe.BorderBrush = Brushes.Red;
                
            //    retVal = false;
           // }

            //validacija polja cena
            if (String.IsNullOrWhiteSpace(cenaTxt.Text))
            {
                cenaTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
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
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        cenaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    cenaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            //validacija polja barkod
            if (String.IsNullOrWhiteSpace(barkodTxt.Text))
            {
                barkodTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
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
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        barkodTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
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
                porezTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
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
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        porezTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    porezTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja akciza
            if (String.IsNullOrWhiteSpace(akcizaTxt.Text))
            {
                akcizaTxt.Text = "Required field!";
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
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        akcizaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    akcizaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja poreklo
            if (String.IsNullOrWhiteSpace(porekloTxt.Text))
            {
                porekloTxt.BorderBrush = Brushes.Red;
                //lastNameValTxt.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                porekloTxt.ClearValue(Border.BorderBrushProperty);
                //lastNameValTxt.Visibility = Visibility.Hidden;
            }


            // validacija polja carina
            if (String.IsNullOrWhiteSpace(carinaTxt.Text))
            {
                carinaTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
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
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        carinaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    carinaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            // validacija polja rok trajanja
            if (String.IsNullOrWhiteSpace(rokTrajanjaTxt.Text))
            {
                rokTrajanjaTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
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
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        rokTrajanjaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    rokTrajanjaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            return retVal;
        }

    }
}
