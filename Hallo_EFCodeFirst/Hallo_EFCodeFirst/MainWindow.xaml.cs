using Hallo_EFCodeFirst.Model;
using System;
using System.Collections.Generic;
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

namespace Hallo_EFCodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EfContext context = new EfContext();
        private void Laden(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = context.Mahlzeiten.ToList();
        }

        private void Demo(object sender, RoutedEventArgs e)
        {
            var t1 = new Tier() { Art = "Oranutan", AnzahlBeine = 2, Oberfläche = Tieroberfläche.Fell };
            var t2 = new Tier() { Art = "Gabelweihe", AnzahlBeine = 2, Oberfläche = Tieroberfläche.Federn };
            var t3 = new Tier() { Art = "Fisch", AnzahlBeine = 0, Oberfläche = Tieroberfläche.Schuppen };

            var m1 = new Mahlzeit() { Bezeichnung = "Wiener Schnitzel" };
            m1.Tiere.Add(t1);
            m1.Tiere.Add(t2);
            m1.Tiere.Add(t3);

            var m2 = new Mahlzeit() { Bezeichnung = "Affenhirn auf Eis" };
            m2.Tiere.Add(t1);

            var m3 = new Mahlzeit() { Bezeichnung = "Döner" };
            m3.Tiere.Add(t2);
            m3.Tiere.Add(t3);

            context.Mahlzeiten.Add(m1);
            context.Mahlzeiten.Add(m2);
            context.Mahlzeiten.Add(m3);

            context.SaveChanges();
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
