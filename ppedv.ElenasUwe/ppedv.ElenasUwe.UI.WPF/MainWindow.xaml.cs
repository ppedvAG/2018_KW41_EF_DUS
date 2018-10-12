using ppedv.ElenasUwe.Logic;
using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Exceptions;
using System.Linq;
using System.Windows;

namespace ppedv.ElenasUwe.UI.WPF
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

        Core core = new Core();
        private void Laden(object sender, RoutedEventArgs e)
        {
            core = new Core();
            myGrid.ItemsSource = core.UnitOfWork.GetRepository<Produkt>().Query().ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Produkt p)
            {
                string txt = $"Soll das Produkt {p.Name} wirklich gelöscht werden.";
                if (MessageBox.Show(txt, "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    core.UnitOfWork.ProduktRepository.Delete(p);
                }
            }
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            try
            {

                core.UnitOfWork.Save();
            }
            catch (MyConcurrencyException ex)
            {

                var msg = "In der zwischenzeit wurde die Daten von jemand anderen geändert!\n Soll die Änderungen überschieben werden?[UserWins] (Sonst werden die eigen Änderungen verworfen!)";
                if (MessageBox.Show(msg, "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    ex.UserWins.Invoke();
                }
                else
                {
                    ex.DbWins.Invoke();
                    Laden(null, null);
                }
            }
        }
    }
}
