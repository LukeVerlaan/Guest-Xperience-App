using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.Authentication;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.Services.Hotel;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ProductDetailsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        readonly IDismissKeyboardService dismissKeyboardService;
        readonly IAuthenticationService authenticationService;

        ShopItem product;
        int quantity = 1;
        bool isNextEnabled;

        public ICommand AddQuantityCommand => new Command(AddQuantity);
        public ICommand MinusQuantityCommand => new Command(MinusQuantity);
        public ICommand AddToCartCommand => new Command(AddToCartAsync);

        public ProductDetailsViewModel(
            IAnalyticService analyticService,
            IHotelService hotelService)
        {
            this.analyticService = analyticService;
            this.hotelService = hotelService;
            dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();
        }

        public ShopItem Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity == value)
                {
                    return;
                }

                quantity = value;
                OnPropertyChanged(nameof(Quantity));

            }
        }

        private void AddQuantity()
        {
            Quantity = Quantity + 1;
        }

        private void MinusQuantity()
        {
            if(Quantity > 1)
            {
                Quantity = Quantity - 1;
            }
        }

        async Task AddToCartAsync()
        {
        }

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => SetProperty(ref isNextEnabled, value);
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var navigationParameter = navigationData as Dictionary<string, object>;
                Product = navigationParameter["product"] as ShopItem;
            }

            return base.InitializeAsync(navigationData);
        }

    }
}
