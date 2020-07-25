using Async_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_MVVM.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Covid19Data = new NotifyTaskCompletion<RootObject>(CovidData.GetCovidData());
        }
        public NotifyTaskCompletion<RootObject> Covid19Data { get; private set; }
    }
}
