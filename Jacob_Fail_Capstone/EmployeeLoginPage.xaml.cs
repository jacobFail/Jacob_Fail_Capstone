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
	public partial class EmployeeLoginPage : ContentPage
	{
		public EmployeeLoginPage()
		{
			InitializeComponent();
		}

		public async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			string enteredPassword = EmployeePasswordEditor.Text;
			var storePasswordList = await Database.GetStorePasswordAsync(enteredPassword);
			if (storePasswordList.Count == 1)
			{
				await Navigation.PushAsync(new ManageInventoryPage());
			}

			else
			{
				await DisplayAlert("Alert", "Password is incorrect", "OK");
			}
		}

	}
}