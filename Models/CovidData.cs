using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Async_MVVM.Models
{
    class CovidData
    {
        public async static Task<RootObject> GetCovidData()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.covid19api.com/summary");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

        public async static Task<CountryWiseData> GetCovidCountryData(string CountryName)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.covid19api.com/summary");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            var CountryData = data.Countries.Find(x => x.Country == CountryName);

            return CountryData;
        }
    }

    [DataContract]
    public class Global
    {
        [DataMember]
        public int NewConfirmed { get; set; }
        [DataMember]
        public int TotalConfirmed { get; set; }
        [DataMember]
        public int NewDeaths { get; set; }
        [DataMember]
        public int TotalDeaths { get; set; }
        [DataMember]
        public int NewRecovered { get; set; }
        [DataMember]
        public int TotalRecovered { get; set; }

    }

    [DataContract]
    public class CountryWiseData
    {
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string Slug { get; set; }
        [DataMember]
        public int NewConfirmed { get; set; }
        [DataMember]
        public int TotalConfirmed { get; set; }
        [DataMember]
        public int NewDeaths { get; set; }
        [DataMember]
        public int TotalDeaths { get; set; }
        [DataMember]
        public int NewRecovered { get; set; }
        [DataMember]
        public int TotalRecovered { get; set; }

    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Global Global { get; set; }
        [DataMember]
        public List<CountryWiseData> Countries { get; set; }


    }


}
