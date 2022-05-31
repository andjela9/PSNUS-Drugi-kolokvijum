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
            ArtikalContext.Instance.Artikli.Load();             //da je sigurno da je poslednja verzija iz baze
            artikliGrid.ItemsSource = ArtikalContext.Instance.Artikli.Local;            //iz entity frameworka
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
            // otvaranje Yes/No dijaloga
            var result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            // ako je korisnik kliknuo na Yes, obrisati studenta iz kolekcije
            if (result == MessageBoxResult.Yes)
            {
                ArtikalContext.Instance.Artikli.Remove(SelectedArtikal);
                ArtikalContext.Instance.SaveChanges();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ArtikalContext.Instance.Dispose();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UnosArtikla unosArtikla = new UnosArtikla();
            unosArtikla.ShowDialog();
        }

        private void DodajArtikal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DetailsBtnSektor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBtnSektor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtnSektor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
