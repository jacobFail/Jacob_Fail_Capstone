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
	public partial class ManageStockCountPage : ContentPage
	{
		public ManageStockCountPage()
		{
			InitializeComponent();
		}

		async public void OnSearchButtonClicked(object sender, EventArgs e)
		{
			
			var fictionBookList = await Database.GetFictionBooksByAuthorAndTitleAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text);
			var nonFictionBookList = await Database.GetNonFictionBooksByAuthorAndTitleAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text);
			var bookList = new List<Book>();
			bookList.AddRange(fictionBookList);
			bookList.AddRange(nonFictionBookList);

			if (fictionBookList.Count == 0 && nonFictionBookList.Count == 0)
			{
				await DisplayAlert("Alert", "Book or author not found.", "OK");
			}

			else
			{
				numberOfCopiesEditor.Text = bookList[0].NumberInStock;
			}
		}

		async public void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var fictionBookList = await Database.GetFictionBooksByAuthorAndTitleAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text);
			var nonFictionBookList = await Database.GetNonFictionBooksByAuthorAndTitleAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text);
			var bookList = new List<Book>();
			bookList.AddRange(fictionBookList);
			bookList.AddRange(nonFictionBookList);

			if (fictionBookList.Count == 0 && nonFictionBookList.Count == 0)
			{
				await DisplayAlert("Alert", "Book or author not found.", "OK");
			}

			else
			{
				if (nonFictionBookList.Count == 0)
				{
					int number;
					bool numberInStockIsNumber = int.TryParse(numberOfCopiesEditor.Text, out number);
					if (numberInStockIsNumber)
					{
						Database.UpdateFictionNumberInStockAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text, numberOfCopiesEditor.Text);
						await DisplayAlert("Alert", "Number of copies updated.", "OK");
						searchAuthorEditor.Text = "";
						searchBookTitleEditor.Text = "";
						numberOfCopiesEditor.Text = "";
					}
					else
					{
						await DisplayAlert("Alert", "Please enter a number for number of copies in stock.", "OK");
					}
				}
				else
				{
					if (fictionBookList.Count == 0)
					{
						int number;
						bool numberInStockIsNumber = int.TryParse(numberOfCopiesEditor.Text, out number);
						if (numberInStockIsNumber)

						{
							Database.UpdateNonFictionNumberInStockAsync(searchAuthorEditor.Text, searchBookTitleEditor.Text, numberOfCopiesEditor.Text);
							await DisplayAlert("Alert", "Number of copies updated.", "OK");
							searchAuthorEditor.Text = "";
							searchBookTitleEditor.Text = "";
							numberOfCopiesEditor.Text = "";
						}
						else
						{
							await DisplayAlert("Alert", "Please enter a number for number of copies in stock.", "OK");
						}
					}
				}
			}
		}
	}
}