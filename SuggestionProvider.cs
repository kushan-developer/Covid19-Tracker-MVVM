using Async_MVVM.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAutoCompleteControls.Editors;

namespace Async_MVVM
{
    internal sealed class SuggestionProvider : ISuggestionProvider
    {
        public readonly List<CountryListData> countriesList = new List<CountryListData>();

        private readonly TimeSpan Delay = TimeSpan.FromSeconds(0);

        public SuggestionProvider()
        {
            DataFetch();
        }

        public async void DataFetch()
        {
            try
            {
                RootObject covidData = await CovidData.GetCovidData();
                covidData.Countries.ForEach(country => countriesList.Add(new CountryListData(country.Country)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public IEnumerable GetSuggestions(string filter)
        {
            Thread.Sleep(Delay);

            if (string.IsNullOrWhiteSpace(filter))
            {
                return countriesList;
            }

            filter = filter.Trim();
            return countriesList.Where(x => x.Name.StartsWith(filter, StringComparison.OrdinalIgnoreCase));
            /*.Where(x => x.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);*/
        }

        IEnumerable ISuggestionProvider.GetSuggestions(string filter)
        {
            IEnumerable suggestions = GetSuggestions(filter);
            return suggestions;
        }
    }

    public class CountryListData
    {
        public string Name { get; set; }

        public CountryListData(string country)
        {
            this.Name = country;
        }
    }
}

