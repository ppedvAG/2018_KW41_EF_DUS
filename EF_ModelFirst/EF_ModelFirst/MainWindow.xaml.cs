using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Data.Entity;

namespace EF_ModelFirst
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

        Model1Container context = new Model1Container();

        private void Laden(object sender, RoutedEventArgs e)
        {
            var query = context.PersonSet.OfType<Mitarbeiter>().Include(x => x.Abteilung)
                                         .Where(x => x.Name.StartsWith("F") &&
                                                     x.GebDatum.HasValue &&
                                                     x.GebDatum.Value.Month >= 1)
                                         .OrderBy(x => x.GebDatum.Value.Year)
                                         .ThenByDescending(x => x.Abteilung.Where(y => y.Bezeichnung.Length > 2).Count());
            Trace.WriteLine(query.ToString());
            myGrid.ItemsSource = query.ToList();
        }

        private void Demo(object sender, RoutedEventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:000}",
                    Beruf = "Macht dinge",
                    Haarfarbe = "Ja",
                    GebDatum = DateTime.Now.AddYears(-50).AddDays(i * 17)
                };

                if (i % 2 == 0)
                    m.Abteilung.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilung.Add(abt2);

                context.PersonSet.Add(m);
            }
            context.SaveChanges();
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void Löscehn(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Mitarbeiter m)
            {
                if (MessageBox.Show($"Soll {m.Name} wirklich und endgültig für immer auf alle ewigkeit gelöscht werden?",
                    "",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning,
                    MessageBoxResult.No) != MessageBoxResult.Yes == !!!!!!!!!true)
                {
                    context.PersonSet.Remove(m);
                }
            }
        }

        private void ZeigeStatus(object sender, MouseButtonEventArgs e)
        {
            if (myGrid.SelectedItem is Mitarbeiter m)
            {
                context.Entry(m).State = EntityState.Detached;
                m.Name = "FFFF";
                context.Entry(m).State = EntityState.Modified;
                MessageBox.Show(context.Entry(m).State.ToString());
            }
        }
    }
}
