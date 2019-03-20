using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Form.PhoneWordApp
{
	public class MainPage : ContentPage
	{
        Entry phoneNumberText;
        Button buttonTranslate;
        Button buttonCall;
        string translateNumber;

		public MainPage ()
		{
            this.Padding = new Thickness(20, 20, 20, 20);
            StackLayout panel = new StackLayout();
            panel.Spacing = 15;

            panel.Children.Add(new Label { Text = "Enter a phone word", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) });

            panel.Children.Add(phoneNumberText = new Entry { Text = "1-855-XAMARIN"});

            panel.Children.Add(buttonTranslate = new Button { Text = "Translate Button"});
            panel.Children.Add(buttonCall = new Button { Text = "Call", IsEnabled = false });

            buttonTranslate.Clicked += ButtonTranslate_Clicked;

            this.Content = panel;
        }

        private void ButtonTranslate_Clicked(object sender, EventArgs e)
        {
            translateNumber = Core.PhoneTranslatetor.toNumber(phoneNumberText.Text);

            if (string.IsNullOrWhiteSpace(translateNumber))
            {
                buttonCall.IsEnabled = false;
                buttonCall.Text = "Call";
            }
            else
            {
                buttonCall.IsEnabled = true;
                buttonCall.Text = "Call " + translateNumber;
            }
        }
    }
}
