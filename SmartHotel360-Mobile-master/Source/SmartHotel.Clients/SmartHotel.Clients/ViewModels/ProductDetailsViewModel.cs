using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Repository;
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
        List<ShopOrderModel> orders;
        ShopOrderModel order;
        ShopItem product;
        Models.Size productSize;
        int productQuantity = 1;
        bool isNextEnabled;

        readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        readonly IDismissKeyboardService dismissKeyboardService;
        readonly IAuthenticationService authenticationService;



        public ICommand AddQuantityCommand => new Command(AddQuantity);
        public ICommand MinusQuantityCommand => new Command(MinusQuantity);
        public ICommand AddToCartCommand => new AsyncCommand(AddToCartAsync);

        public ProductDetailsViewModel(
            IAnalyticService analyticService,
            IHotelService hotelService)
        {
            this.analyticService = analyticService;
            this.hotelService = hotelService;
            dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();
        }


        public ShopOrderModel Order
        {
            get => order;
            set => SetProperty(ref order, value);
        }

        public ShopItem Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        public Models.Size ProductSize
        {
            get => productSize;
            set => SetProperty(ref productSize, value);
        }

        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                if (productQuantity == value)
                {
                    return;
                }

                productQuantity = value;
                OnPropertyChanged(nameof(ProductQuantity));

            }
        }

        private void AddQuantity()
        {
            ProductQuantity = ProductQuantity + 1;
        }

        private void MinusQuantity()
        {
            if(ProductQuantity > 1)
            {
                ProductQuantity = ProductQuantity - 1;
            }
        }

        async Task AddToCartAsync()
        {
            try
            {
                orders = await App.Database.GetShopOrdersAsync();
                if (orders.Count > 0)
                {
                    Order = orders.LastOrDefault();
                }
                else
                {
                    await App.Database.CreateShopOrder();
                    orders = await App.Database.GetShopOrdersAsync();
                    Order = orders.LastOrDefault();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Product Where Step] Error: {ex}");

                await DialogService.ShowAlertAsync(
                    Resources.ExceptionMessage,
                    Resources.ExceptionTitle,
                    Resources.DialogOk);
            }
            if (ProductQuantity > 0)
            {
                OrderItemModel orderItem = new OrderItemModel
                {
                    ShopId = Product.ShopId,
                    OrderId = Order.OrderId,
                    ProductImage = Product.ProductImage,
                    Name = Product.Name,
                    Description = Product.Description,
                    Price = Product.Price,
                    Rating = Product.Rating,
                    Size = "m",
                    Category = Product.Category,
                    Quantity = ProductQuantity
                };
                await App.Database.SaveOrderItemAsync(orderItem);
                bool action = await Application.Current.MainPage.DisplayAlert("Added", "Product has been added to cart", "Stay", "Show cart");
                if (!action)
                {
                    ShowCartAsync();
                }
            }
        }

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => SetProperty(ref isNextEnabled, value);
        }

        public override async  Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var navigationParameter = navigationData as Dictionary<string, object>;
                Product = navigationParameter["product"] as ShopItem;
            }

        }

        Task ShowCartAsync() 
        { 
             return NavigationService.NavigateToAsync<ShoppingCartViewModel>();
        }

    }
}
