using Prodavnica.Prozori_xaml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prodavnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Artikal SelectedArtikal { get; set; }
        public Sektor SelectedSektor { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ArtikalSektorContext.Instance.Artikli.Load();             //da je sigurno da je poslednja verzija iz baze
            artikliGrid.ItemsSource = ArtikalSektorContext.Instance.Artikli.Local;            //iz entity frameworka
            this.DataContext = this;

            ArtikalSektorContext.Instance.Sektori.Load();
            sektoriGrid.ItemsSource = ArtikalSektorContext.Instance.Sektori.Local;
            this.DataContext = this;
            //load sektora isto ovako

            //LoadData();

            //view - SQL server object explorer
            
        }
        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: napraviti lepsi prozor i otvoriti ga sa popunjenim podacima o studentu
            MessageBox.Show(SelectedArtikal.ToString(), "Details");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: ovo nije realna implementacija, treba implementirati funkcionalni prozor i logiku za update
            MessageBox.Show(SelectedArtikal.ToString(), "Update");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //otvaranje Yes/ No dijaloga
            var result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            // ako je korisnik kliknuo na Yes, obrisati artikal iz kolekcije
            if (result == MessageBoxResult.Yes)
            {
                ArtikalSektorContext.Instance.Artikli.Remove(SelectedArtikal);
                ArtikalSektorContext.Instance.SaveChanges();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ArtikalSektorContext.Instance.Dispose();
        }

        private void DodajArtikal_Click(object sender, RoutedEventArgs e)
        {
            UnosArtikla unosArtikla = new UnosArtikla();
            unosArtikla.ShowDialog();
        }

       
        private void DetailsBtnSektor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedSektor.ToString(), "Details");
        }

        private void UpdateBtnSektor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedSektor.ToString(), "Update");
        }

        private void DeleteBtnSektor_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            //// ako je korisnik kliknuo na Yes, obrisati sektor iz kolekcije
            if (result == MessageBoxResult.Yes)
            {
                ArtikalSektorContext.Instance.Sektori.Remove(SelectedSektor);
                ArtikalSektorContext.Instance.SaveChanges();
            }

        }

        private void DodajSektor_Click(object sender, RoutedEventArgs e)
        {
            UnosSektora unosSektora = new UnosSektora();
            unosSektora.ShowDialog();
        }
    }
}
