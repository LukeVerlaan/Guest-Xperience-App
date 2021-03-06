﻿using SmartHotel.Clients.Core.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Converters
{
    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;

            var platform = Device.RuntimePlatform == Device.UWP;

            switch (menuItemType)
            {
                case MenuItemType.Home:
                    return platform ? "Assets/ic_home.png" : "ic_home.png";
                case MenuItemType.BookRoom:
                    return platform ? "Assets/ic_bed.png" : "ic_bed.png";
                case MenuItemType.MyRoom:
                    return platform ? "Assets/ic_key.png" : "ic_key.png";
                case MenuItemType.Suggestions:
                    return platform ? "Assets/ic_beach.png" : "ic_beach.png";
                case MenuItemType.Events:
                    return platform ? "Assets/ic_event.png" : "ic_event.png";
                case MenuItemType.Restaurant:
                    return platform ? "Assets/ic_restaurant.png" : "ic_restaurant.png";
                case MenuItemType.Chat:
                    return platform ? "Assets/ic_chat.png" : "ic_chat.png";
                case MenuItemType.Shop:
                    return platform ? "Assets/ic_shop.png" : "ic_shop.png";
                case MenuItemType.ShoppingCart:
                    return platform ? "Assets/ic_cart.png" : "ic_cart.png";
                case MenuItemType.Concierge:
                    return platform ? "Assets/ic_bot.png" : "ic_bot.png";
                case MenuItemType.Info:
                    return platform ? "Assets/ic_info.png" : "ic_info.png";
                case MenuItemType.Account:
                    return platform ? "Assets/ic_account.png" : "ic_account.png";
                case MenuItemType.Logout:
                    return platform ? "Assets/ic_logout.png" : "ic_logout.png";
                case MenuItemType.Test:
                    return platform ? "Assets/ic_paperbin.png" : "ic_paperbin.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}