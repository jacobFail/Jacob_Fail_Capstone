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
	public partial class RemoveBookPage : ContentPage
	{
		public RemoveBookPage()
		{
			InitializeComponent();
		}

		public async void OnRemoveBookButtonClicked(object sender, EventArgs e)
		{
			

			var fictionBookList = await Database.GetFictionBooksByAuthorAndTitleAsync(EnterAuthorNameEditor.Text, EnterBookTitleEditor.Text);
			var nonFictionBookList = await Database.GetNonFictionBooksByAuthorAndTitleAsync(EnterAuthorNameEditor.Text, EnterBookTitleEditor.Text);

			if (fictionBookList.Count == 0 && nonFictionBookList.Count == 0)
			{
				await DisplayAlert("Alert", "Book or Author not found", "OK");
			}
			else

			{
				if (fictionBookList.Count == 0)
				{
					Database.RemoveNonFictionBookAsync(EnterAuthorNameEditor.Text, EnterBookTitleEditor.Text);
					await DisplayAlert("Alert", "Book Removed", "OK");
					EnterAuthorNameEditor.Text = "";
					EnterBookTitleEditor.Text = "";
				}

				if (nonFictionBookList.Count == 0)
				{
					Database.RemoveFictionBookAsync(EnterAuthorNameEditor.Text, EnterBookTitleEditor.Text);
					await DisplayAlert("Alert", "Book Removed", "OK");
					EnterAuthorNameEditor.Text = "";
					EnterBookTitleEditor.Text = "";
				}
			}
				
			

		}
	}
	
}