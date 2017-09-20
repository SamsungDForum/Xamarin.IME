using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using xamarin.ime.Interface;

namespace xamarin.ime
{
    public class App : Application
    {
        Entry entry;
        Button button;

        public StackLayout GetContent()
        {
            return new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms!"
                    },
                }
            };
        }

        public App()
        {
            StackLayout ly = GetContent();
            MainPage = new ContentPage
            {
                Content = ly,
                BackgroundColor = Color.Black,
            };

            StackLayout layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 20,
            };

            button = new Button
            {
                Text = "OK",
            };

            entry = new Entry
            {
                BackgroundColor = Color.White,
                WidthRequest = 600,
            };

            entry.Focused += (sender, ev) =>
            {
                MessagingCenter.Subscribe<IKeyEventSender, string>(this, "KeyDown", (s, e) =>
                {
                    if (e.Contains("Select") || e.Contains("Cancel"))
                    {
                        button.Focus();
                    }
                });
            };

            entry.Unfocused += (senders, ev) =>
            {
                MessagingCenter.Unsubscribe<IKeyEventSender, string>(this, "KeyDown");
            };

            layout.Children.Add(entry);
            layout.Children.Add(button);

            ly.Children.Add(layout);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
