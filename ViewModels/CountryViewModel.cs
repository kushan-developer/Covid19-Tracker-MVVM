using Async_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_MVVM.ViewModels
{
    class CountryViewModel
    {
        public CountryViewModel(string CountryName)
        {
            CountryData = new NotifyTaskCompletion<CountryWiseData>(CovidData.GetCovidCountryData(CountryName));
        }
        public NotifyTaskCompletion<CountryWiseData> CountryData { get; private set; }
    }
}
