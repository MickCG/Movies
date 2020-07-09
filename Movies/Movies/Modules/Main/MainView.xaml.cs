// ***********************************************************************
// Assembly         : Movies
// Author           : mick_
// Created          : 07-07-2020
//
// Last Modified By : mick_
// Last Modified On : 07-07-2020
// ***********************************************************************
// <copyright file="MainView.xaml.cs" Application="Movies">
//     Copyright (c) Happy Troll Computing. All rights reserved.
// </copyright>
// <summary>This matches the example</summary>
// ***********************************************************************

namespace Movies.Modules.Main
{
    using Xamarin.Forms;

    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}