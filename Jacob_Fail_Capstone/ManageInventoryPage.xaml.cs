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
	public partial class ManageInventoryPage : ContentPage
	{
		public ManageInventoryPage()
		{
			InitializeComponent();
		}

		async public void OnAddAuthorButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddAuthorPage());
		}

		async public void OnRemoveAuthorButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RemoveAuthorPage());
		}

		
		async public void OnAddBookButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddBookPage());
		}

		async public void OnRemoveBookButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RemoveBookPage());
		}

		async public void OnLogOutButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

		async public void OnManageStockCountButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ManageStockCountPage());
		}

		async public void OnChangePasswordButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ChangePasswordPage());
		}

	}
}