﻿using SmartHotel.Clients.Core.Exceptions;
using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
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
    public class ChatListViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IHotelService hotelService;
        readonly IDismissKeyboardService dismissKeyboardService;

        string search;
        IEnumerable<Models.Chat> chats;
        IEnumerable<string> suggestions;
        string suggestion;
        bool isNextEnabled;

        public ChatListViewModel(
            IAnalyticService analyticService,
            IHotelService hotelService)
        {
            this.analyticService = analyticService;
            this.hotelService = hotelService;
            dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();

            chats = new List<Models.Chat>();
            suggestions = new List<string>();
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

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                chats = await hotelService.GetChatsAsync();

                Suggestions = new List<string>(chats.Select(c => c.ToString()));
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                if (!string.IsNullOrEmpty(httpEx.Message))
                {
                    await DialogService.ShowAlertAsync(
                        string.Format(Resources.HttpRequestExceptionMessage, httpEx.Message),
                        Resources.HttpRequestExceptionTitle,
                        Resources.DialogOk);
                }
            }
            catch (ConnectivityException cex)
            {
                Debug.WriteLine($"[Booking Where Step] Connectivity Error: {cex}");
                await DialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking Where Step] Error: {ex}");

                await DialogService.ShowAlertAsync(
                    Resources.ExceptionMessage,
                    Resources.ExceptionTitle,
                    Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void FilterAsync(string search)
        {
            try
            {
                IsBusy = true;

                Suggestions = new List<string>(
                    chats.Select(c => c.ToString())
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

        Task NextAsync()
        {
            var chat = chats.FirstOrDefault(c => c.ToString().Equals(Suggestion));
            //return NavigationService.NavigateToAsync<ChatViewModel>();
            if (chat != null)
            {
                return NavigationService.NavigateToAsync<ChatViewModel>(chat);                
            }
            // just return Task, but have to provide an argument because there is no overload
            return Task.FromResult(true);
        }
    }
}
