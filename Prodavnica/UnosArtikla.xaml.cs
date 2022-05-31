using System;
using System.Collections.Generic;
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

        public UnosArtikla()
        {
            InitializeComponent();
            this.DataContext = noviArtikal;
            
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                ArtikalSektorContext.Instance.Artikli.Add(noviArtikal);
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
