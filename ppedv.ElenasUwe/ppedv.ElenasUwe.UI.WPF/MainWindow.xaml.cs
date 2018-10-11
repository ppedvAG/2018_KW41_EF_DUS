using ppedv.ElenasUwe.Logic;
using ppedv.ElenasUwe.Model;
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
            myGrid.ItemsSource = core.Repository.Query<Produkt>().ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Produkt p)
            {
                string txt = $"Soll das Produkt {p.Name} wirklich gelöscht werden.";
                if (MessageBox.Show(txt, "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    core.Repository.Delete(p);
                }
            }
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            core.Repository.Save();
        }
    }
}
