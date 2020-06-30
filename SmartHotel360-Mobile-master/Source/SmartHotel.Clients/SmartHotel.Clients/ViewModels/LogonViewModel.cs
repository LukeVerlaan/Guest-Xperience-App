﻿using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.Authentication;
using SmartHotel.Clients.Core.Validations;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class LogonViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IAuthenticationService authenticationService;

        ValidatableObject<string> roomNumber;
        ValidatableObject<string> lastName;

        public bool IsValid { get; set; }

        Models.OldHotel hotel;
        bool isNextEnabled;

        public LogonViewModel(
            IAnalyticService analyticService,
            IAuthenticationService authenticationService)
        {
            this.analyticService = analyticService;
            this.authenticationService = authenticationService;

            roomNumber = new ValidatableObject<string>();
            lastName = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> RoomNumber
        {
            get => roomNumber;
            set => SetProperty(ref roomNumber, value);
        }

        public ValidatableObject<string> LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public Models.OldHotel Hotel
        {
            get => hotel;
            set => SetProperty(ref hotel, value);
        }

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => SetProperty(ref isNextEnabled, value);
        }

        public ICommand SignInCommand => new AsyncCommand(SignInAsync);
        public ICommand NextCommand => new AsyncCommand(NextAsync);

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Hotel = navigationData as Models.OldHotel;
            }

            return base.InitializeAsync(navigationData);
        }

        async Task SignInAsync()
        {
            IsBusy = true;

            IsValid = Validate();

            if (IsValid)
            {
                var isAuth = await authenticationService.LoginAsync(RoomNumber.Value, LastName.Value);

                if (isAuth)
                {
                    IsBusy = false;

                    analyticService.TrackEvent("SignIn");
                    await NavigationService.NavigateToAsync<VerificationViewModel>();
                }
            }

            MessagingCenter.Send(this, MessengerKeys.SignInRequested);

            IsBusy = false;
        }

        void AddValidations()
        {
            roomNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Room Number should not be empty" });
            lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name should not be empty" });
        }

        bool Validate()
        {
            var isValidRoom = roomNumber.Validate();
            var isValidLastName = lastName.Validate();

            return isValidRoom && isValidLastName;
        }

        Task NextAsync()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Hotel", Hotel }
            };

            return NavigationService.NavigateToAsync<VerificationViewModel>(navigationParameter);
        }
    }
}
