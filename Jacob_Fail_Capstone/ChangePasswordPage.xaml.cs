using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jacob_Fail_Capstone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePasswordPage : ContentPage
	{
		public ChangePasswordPage()
		{
			InitializeComponent();
		}

		public async void OnConfirmButtonClicked(object sender, EventArgs e)
		{
			if (PasswordEditor.Text != null && PasswordEditor.Text != "")
			{
				if (PasswordEditor.Text == confirmPasswordEditor.Text)
				{

					Database.UpdateEmployeeLoginAsync(PasswordEditor.Text);

					await DisplayAlert("Alert", "Password Saved", "OK");

					await Navigation.PushAsync(new MainPage());
				}
				else
				{
					await DisplayAlert("Alert", "Passwords do not match.", "OK");
				}
			}
			else
			{
				await DisplayAlert("Alert", "Please enter a password to be saved.", "OK");
			}
		}
	}
}