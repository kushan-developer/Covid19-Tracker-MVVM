using Async_MVVM.ViewModels;
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

namespace Async_MVVM.Views
{
    /// <summary>
    /// Interaction logic for CountryData.xaml
    /// </summary>
    public partial class CountryData : Page
    {
        string countryName;

        public CountryData(string SearchCountryName)
        {
            InitializeComponent();
            countryName = SearchCountryName;
            DataContext = new CountryViewModel(SearchCountryName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DataContext value: " + DataContext);
        }
    }
}
