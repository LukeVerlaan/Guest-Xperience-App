﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Clients.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationView : ContentPage
    {
        public VerificationView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
    }
}