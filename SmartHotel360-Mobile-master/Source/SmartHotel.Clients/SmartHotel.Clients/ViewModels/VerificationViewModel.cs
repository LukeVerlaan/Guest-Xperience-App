using SmartHotel.Clients.Core.Services.Analytic;
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
    public class VerificationViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IAuthenticationService authenticationService;

        ValidatableObject<string> verificationCode;

        public bool IsValid { get; set; }

        Models.OldHotel hotel;
        bool isNextEnabled;

        public VerificationViewModel(
            IAnalyticService analyticService,
            IAuthenticationService authenticationService)
        {
            this.analyticService = analyticService;
            this.authenticationService = authenticationService;

            verificationCode = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> VerificationCode
        {
            get => verificationCode;
            set => SetProperty(ref verificationCode, value);
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
                var isAuth = await authenticationService.VerificationAsync(verificationCode.Value);

                if (isAuth)
                {
                    IsBusy = false;

                    analyticService.TrackEvent("SignIn");
                    await NavigationService.NavigateToAsync<MainViewModel>();
                }
            }

            MessagingCenter.Send(this, MessengerKeys.SignInRequested);

            IsBusy = false;
        }

        void AddValidations()
        {
            verificationCode.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Verification Code should not be empty" });
        }

        bool Validate()
        {
            var isValidCode = verificationCode.Validate();

            return isValidCode;
        }

        Task NextAsync()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Hotel", Hotel }
            };

            return NavigationService.NavigateToAsync<MainViewModel>(navigationParameter);
        }
    }
}
