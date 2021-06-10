using LeaveMgt.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeaveMgt
{
    class Splash : ContentPage
    {
        Image SplashImage;
        public Splash()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "logo2",
                WidthRequest = 100,
                HeightRequest = 100,
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(SplashImage);
            this.BackgroundColor = Color.FromHex("F5F5F5");
            this.Padding = 10;
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(1, 5000);
            Application.Current.MainPage = new OptionsPage();
        }
    }
}
