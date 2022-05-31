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

namespace Prodavnica.Prozori_xaml
{
    /// <summary>
    /// Interaction logic for UnosSektora.xaml
    /// </summary>
    public partial class UnosSektora : Window
    {
        private Sektor noviSektor = new Sektor();
        public UnosSektora()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                ArtikalSektorContext.Instance.Sektori.Add(noviSektor);
                ArtikalSektorContext.Instance.SaveChanges();
                this.Close();
                MessageBox.Show("DEBUG", "DEBUG", MessageBoxButton.OK, MessageBoxImage.Error);
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

            //validacija polja id sektora
            if (String.IsNullOrWhiteSpace(idSektoraTxt.Text))
            {
                idSektoraTxt.BorderBrush = Brushes.Red;
                //idSektoraTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int id_sektora;
                if (Int32.TryParse(idSektoraTxt.Text, out id_sektora))
                {
                    if (id_sektora <= 0)
                    {
                        idSektoraTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        idSektoraTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    idSektoraTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            //validacija polja povrsina
            if (String.IsNullOrWhiteSpace(povrsinaTxt.Text))
            {
                povrsinaTxt.BorderBrush = Brushes.Red;
                //povrsinaTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int povrsina;
                if (Int32.TryParse(povrsinaTxt.Text, out povrsina))
                {
                    if (povrsina <= 0)
                    {
                        povrsinaTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        povrsinaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    povrsinaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja maksimalni broj artikala
            if (String.IsNullOrWhiteSpace(maxBrArtikalaTxt.Text))
            {
                //maxBrArtikalaTxt.Text = "Required field!";
                maxBrArtikalaTxt.BorderBrush = Brushes.Red;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int maxBrArtikala;
                if (Int32.TryParse(maxBrArtikalaTxt.Text, out maxBrArtikala))
                {
                    if (maxBrArtikala <= 0)
                    {
                        maxBrArtikalaTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        maxBrArtikalaTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    maxBrArtikalaTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }


            // validacija polja broj zaposlenih
            if (String.IsNullOrWhiteSpace(brZaposlenihTxt.Text))
            {
                brZaposlenihTxt.BorderBrush = Brushes.Red;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int brZaposlenih;
                if (Int32.TryParse(brZaposlenihTxt.Text, out brZaposlenih))
                {
                    if (brZaposlenih <= 0)
                    {
                        brZaposlenihTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        brZaposlenihTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    brZaposlenihTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            // validacija polja plata
            if (String.IsNullOrWhiteSpace(plataTxt.Text))
            {
                plataTxt.BorderBrush = Brushes.Red;
                //plataTxt.Text = "Required field!";
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                double plata;
                if (Double.TryParse(plataTxt.Text, out plata))
                {
                    if (plata <= 0)
                    {
                        plataTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        plataTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    plataTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }



            // validacija polja broj frizidera
            if (String.IsNullOrWhiteSpace(brFrizideraTxt.Text))
            {
                //brFrizideraTxt.Text = "Required field!";
                brFrizideraTxt.BorderBrush = Brushes.Red;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int brFrizidera;
                if (Int32.TryParse(brFrizideraTxt.Text, out brFrizidera))
                {
                    if (brFrizidera <= 0)
                    {
                        brFrizideraTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        brFrizideraTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    brFrizideraTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            // validacija polja broj menadzera
            if (String.IsNullOrWhiteSpace(brMenadzeraTxt.Text))
            {
                //brMenadzeraTxt.Text = "Required field!";
                brMenadzeraTxt.BorderBrush = Brushes.Red;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int brMenadzera;
                if (Int32.TryParse(brMenadzeraTxt.Text, out brMenadzera))
                {
                    if (brMenadzera <= 0)
                    {
                        brMenadzeraTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        brMenadzeraTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    brMenadzeraTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }

            // validacija polja zaposlenih u smeni
            if (String.IsNullOrWhiteSpace(zaposlenihUSmeniTxt.Text))
            {
                zaposlenihUSmeniTxt.BorderBrush = Brushes.Red;
                //indexValTxt.Visibility = Visibility.Visible;

                retVal = false;
            }
            else
            {
                zaposlenihUSmeniTxt.ClearValue(Border.BorderBrushProperty);
                //indexValTxt.Visibility = Visibility.Hidden;
            }

            // validacija polja broj menadzera
            if (String.IsNullOrWhiteSpace(zaposlenihUSmeniTxt.Text))
            {
                //zaposlenihUSmeniTxt.Text = "Required field!";
                zaposlenihUSmeniTxt.BorderBrush = Brushes.Red;
                //ageValTxt.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int zaposlenihUSmeni;
                if (Int32.TryParse(brMenadzeraTxt.Text, out zaposlenihUSmeni))
                {
                    if (zaposlenihUSmeni <= 0)
                    {
                        zaposlenihUSmeniTxt.BorderBrush = Brushes.Red;
                        //ageValTxt.Text = "Age must be positive number!";
                        //ageValTxt.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        zaposlenihUSmeniTxt.ClearValue(Border.BorderBrushProperty);
                        //ageValTxt.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    zaposlenihUSmeniTxt.BorderBrush = Brushes.Red;
                    //ageValTxt.Text = "Only digits allowed (0-9)!";
                    retVal = false;
                }
            }
            return retVal;
        }
    }
}
