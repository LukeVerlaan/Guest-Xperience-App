using MvvmHelpers;
using SmartHotel.Clients.Core.Extensions;
using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Repository;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        List<ShopOrderModel> orders;
        ShopOrderModel order;
        ObservableRangeCollection<OrderItemModel> products;

        public ICommand ShowOrdersCommand => new AsyncCommand(ShowOrdersAsync);
        public ICommand SubmitOrderCommand => new AsyncCommand(SubmitOrder);
        public ShoppingCartViewModel()
        {
            orders = new List<ShopOrderModel>();
        }

        public ShopOrderModel Order
        {
            get => order;
            set => SetProperty(ref order, value);
        }

        public ObservableRangeCollection<OrderItemModel> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        async Task SubmitOrder()
        {
            //if (Products.Count() > 0)
            //{
            //    ShopOrderModel order = new ShopOrderModel
            //    {
            //        ShopId = Product.ShopId,
            //        OrderId = Order.OrderId,
            //        ProductImage = Product.ProductImage,
            //        Name = Product.Name,
            //        Description = Product.Description,
            //        Price = Product.Price,
            //        Rating = Product.Rating,
            //        Size = "m",
            //        Category = Product.Category,
            //        Quantity = ProductQuantity
            //    };
            //    await App.Database.SaveOrderItemAsync(orderItem);
            //var items = App.Database.GetOrderItemsAsync();
            //var items = await App.Database.GetOrderItemsAsync();
            //Order.Items.Add(orderItem);
            //await App.Database.SaveShopOrderAsync(Order);
            await App.Database.CreateShopOrder();
            bool action = await Application.Current.MainPage.DisplayAlert("Order Submit", "Order has been submitted", "Stay", "Ok");
            if (!action)
            {
                ShowShopAsync();
            }
        }


        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                orders = await App.Database.GetShopOrdersAsync();
                Order = orders.LastOrDefault();
                List<OrderItemModel> items = await App.Database.GetOrderItemsAsync(order.OrderId);
                ObservableRangeCollection<OrderItemModel> collection = new ObservableRangeCollection<OrderItemModel>(items);
                Products = collection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking Where Step] Error: {ex}");

                await DialogService.ShowAlertAsync(
                    Resources.ExceptionMessage,
                    Resources.ExceptionTitle,
                    Resources.DialogOk);
            }
        }


        Task ShowShopAsync()
        {
            return NavigationService.NavigateToAsync<ShopListViewModel>();
        }

        Task ShowOrdersAsync()
        {
            return NavigationService.NavigateToAsync<OrderHistoryViewModel>();
        }
    }
}
