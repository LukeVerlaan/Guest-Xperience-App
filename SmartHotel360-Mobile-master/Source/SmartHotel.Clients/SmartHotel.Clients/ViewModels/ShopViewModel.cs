using MvvmHelpers;
using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.Extensions;
using SmartHotel.Clients.Core.Exceptions;
using SmartHotel.Clients.Core.Services.Hotel;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        //readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        //readonly IDismissKeyboardService dismissKeyboardService;

        Shop shop;      
        ObservableRangeCollection<ShopItem> products;

        public ShopViewModel(
            //IAnalyticService analyticService,
            IHotelService hotelService)
        {
            //this.analyticService = analyticService;
            this.hotelService = hotelService;
            //dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();

        }

        public Shop Shop
        {
            get => shop;
            set => SetProperty(ref shop, value);
        }

        public ObservableRangeCollection<ShopItem> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }

        public ICommand ProductSelectedCommand => new Command<ShopItem>(OnSelectProductAsync);

        async void OnSelectProductAsync(Models.ShopItem item)
        {
            if (item != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "product", item },
                };

                await NavigationService.NavigateToAsync<ProductDetailsViewModel>(navigationParameter);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Shop = navigationData as Shop;
            }

            var items = Shop.Items;
            Products = items.ToObservableRangeCollection();

            return base.InitializeAsync(navigationData);
        }

    }
}
