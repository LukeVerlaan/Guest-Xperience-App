using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class InfoViewModel : ViewModelBase
    {
        public ICommand SendToWebsite => new Command<string>(OpenBrowser);

        public InfoViewModel()
        {

        }

        private void OpenBrowser(string url)
        {
            Launcher.OpenAsync(new Uri(url));
        }
    }

    
}
