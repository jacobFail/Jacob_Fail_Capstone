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
	public partial class AddAuthorPage : ContentPage
	{
		public AddAuthorPage()
		{
			InitializeComponent();
		}

		public async void OnSaveAuthorButtonClicked(object sender, EventArgs e)
		{
			if (authorNameEditor.Text != "" && authorNameEditor.Text != null)
			{
				var author = new Author();
				author.AuthorName = authorNameEditor.Text;
				Database.SaveAuthorAsync(author);
				await DisplayAlert("Alert", "Author added", "OK");
				await Navigation.PushAsync(new ManageInventoryPage());
			}
			else
			{
				await DisplayAlert("Alert", "Please enter an author name to be added", "OK");
			}
		}
	}
}