using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.Services.Hotel;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ProductDetailsViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        readonly IDismissKeyboardService dismissKeyboardService;

        ShopItem product;
        bool isNextEnabled;

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

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => SetProperty(ref isNextEnabled, value);
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Product = navigationData as ShopItem;
            }

            return base.InitializeAsync(navigationData);
        }

    }
}
