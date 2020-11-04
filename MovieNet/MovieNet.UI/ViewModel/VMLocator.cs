using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.UI
{
    public class VMLocator 
    {
        public static MainViewModel MainVM { get; } = new MainViewModel();
        public static HomePageViewModel HomePageVM { get; } = new HomePageViewModel();
    }
}
