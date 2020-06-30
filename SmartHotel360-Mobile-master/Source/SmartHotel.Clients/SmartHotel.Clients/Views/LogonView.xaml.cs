using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Clients.Core.Views
{
    public partial class LogonView : ContentPage
    {
        public LogonView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            RoomNumberEntry.Completed += (s, e) => LastNameEntry.Focus();

            MessagingCenter.Subscribe<LogonViewModel>(this, MessengerKeys.SignInRequested, OnSignInRequested);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);
        }

        void OnSignInRequested(LogonViewModel logonViewModel)
        {
            if (!logonViewModel.IsValid)
            {
                VisualStateManager.GoToState(RoomNumberEntry, "Invalid");
                VisualStateManager.GoToState(LastNameEntry, "Invalid");
            }
        }
    }
}