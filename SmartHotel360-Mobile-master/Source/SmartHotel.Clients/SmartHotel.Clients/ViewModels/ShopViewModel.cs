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
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        readonly IDismissKeyboardService dismissKeyboardService;

        Shop shop;
        string search;        
        IEnumerable<ShopItem> products;
        IEnumerable<string> suggestions;
        string suggestion;
        bool isNextEnabled;

        public ShopViewModel(
            IAnalyticService analyticService,
            IHotelService hotelService)
        {
            this.analyticService = analyticService;
            this.hotelService = hotelService;
            dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();

            products = new List<ShopItem>();
            suggestions = new List<string>();
        }

        public Shop Shop
        {
            get => shop;
            set => SetProperty(ref shop, value);
        }

        public string Search
        {
            get => search;
            set
            {
                search = value;
                FilterAsync(search);
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> Suggestions
        {
            get => suggestions;
            set => SetProperty(ref suggestions, value);
        }

        public string Suggestion
        {
            get => suggestion;
            set
            {
                suggestion = value;

                IsNextEnabled = string.IsNullOrEmpty(suggestion) ? false : true;

                dismissKeyboardService.DismissKeyboard();

                OnPropertyChanged();
            }
        }

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => SetProperty(ref isNextEnabled, value);
        }

        public ICommand NextCommand => new AsyncCommand(NextAsync);

        async void FilterAsync(string search)
        {
            try
            {
                IsBusy = true;

                Suggestions = new List<string>(
                    products.Select(c => c.ToString())
                           .Where(c => c.ToLowerInvariant().Contains(search.ToLowerInvariant())));

                analyticService.TrackEvent("Filter", new Dictionary<string, string>
                {
                    { "Search", search }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking] Error: {ex}");
                await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand HotelSelectedCommand => new Command<Models.ShopItem>(OnSelectProductAsync);
        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Shop = navigationData as Shop;
            }

            products = Shop.Items;

            Suggestions = new List<string>(products.Select(c => c.ToString()));

            return base.InitializeAsync(navigationData);
        }

        Task NextAsync()
        {
            var product = products.FirstOrDefault(c => c.ToString().Equals(Suggestion));
            if (product != null)
            {
                return NavigationService.NavigateToAsync<ProductDetailsViewModel>(product);
            }
            // just return Task, but have to provide an argument because there is no overload
            return Task.FromResult(true);
        }

        async void OnSelectProductAsync(Models.ShopItem item)
        {
            await NavigationService.NavigateToAsync<BookingHotelViewModel>(item);
        }

    }
}
