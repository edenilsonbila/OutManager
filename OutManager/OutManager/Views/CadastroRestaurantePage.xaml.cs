﻿using OutManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroRestaurantePage : ContentPage
    {
        public CadastroRestaurantePage()
        {
            InitializeComponent();
            BindingContext = new CadastroRestauranteViewModel();
        }
    }
}