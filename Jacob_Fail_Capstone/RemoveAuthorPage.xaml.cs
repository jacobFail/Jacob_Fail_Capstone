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
	public partial class RemoveAuthorPage : ContentPage
	{
		public RemoveAuthorPage()
		{
			InitializeComponent();
		}
		public async void OnRemoveAuthorButtonClicked(object sender, EventArgs e)
		{
			string authorName = EnterAuthorNameEditor.Text;
			var authorList = await Database.GetAuthorAsync(authorName);
			if (authorList.Count == 1)
			{
				Database.RemoveAuthorAsync(authorList[0]);
				await DisplayAlert("Alert", "Author Removed", "OK");
				EnterAuthorNameEditor.Text = "";
			}
			else
			{
				await DisplayAlert("Alert", "Author not found", "OK");
			}

		}
	}
}