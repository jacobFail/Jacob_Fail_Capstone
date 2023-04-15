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
	public partial class AddBookPage : ContentPage
	{
		public AddBookPage()
		{
			InitializeComponent();
		}

		
		

		public async void OnSaveBookButtonClicked(object sender, EventArgs e)
		{
			var authorList = await Database.GetAuthorAsync(AuthorNameEditor.Text);
			if (authorList.Count != 0)
			{
				if (CopiesInStockEditor.Text != "" && CopiesInStockEditor != null && AuthorNameEditor.Text != "" && AuthorNameEditor.Text != null && BookTitleEditor.Text != "" && BookTitleEditor.Text != null && FictionOrNonFictionPicker.SelectedIndex != -1 && BookGenreOrSubjectEditor.Text != null && BookGenreOrSubjectEditor.Text != "")
				{
					int number;
					bool numberInStockIsNumber = int.TryParse(CopiesInStockEditor.Text, out number);
					if (numberInStockIsNumber)
					{

						if (FictionOrNonFictionPicker.SelectedIndex == 0)
						{
							var book = new FictionBook();
							book.BookTitle = BookTitleEditor.Text;
							book.Genre = BookGenreOrSubjectEditor.Text;
							book.AuthorID = authorList[0].AuthorID;
							book.AuthorName = AuthorNameEditor.Text;
							book.NumberInStock = CopiesInStockEditor.Text;
							Database.SaveFictionBookAsync(book);
							await DisplayAlert("Alert", "Book Added", "OK");
							BookTitleEditor.Text = "";
							BookGenreOrSubjectEditor.Text = "";
							AuthorNameEditor.Text = "";
							CopiesInStockEditor.Text = "";

						}
						else
						{
							var book = new NonFictionBook();
							book.BookTitle = BookTitleEditor.Text;
							book.Subject = BookGenreOrSubjectEditor.Text;
							book.AuthorID = authorList[0].AuthorID;
							book.AuthorName = AuthorNameEditor.Text;
							book.NumberInStock = CopiesInStockEditor.Text;
							Database.SaveNonFictionBookAsync(book);
							await DisplayAlert("Alert", "Book Added", "OK");
							BookTitleEditor.Text = "";
							BookGenreOrSubjectEditor.Text = "";
							AuthorNameEditor.Text = "";
							CopiesInStockEditor.Text = "";
						}


					}
					else
					{
						await DisplayAlert("Alert" , "Please enter a number for number of copies in stock", "OK");
					}
				}

				else
				{
					await DisplayAlert("Alert", "Please enter data for all fields.", "OK");
				}
			}
			else
			{
				await DisplayAlert("Alert", "Author not Found", "OK");
			}
		}
	}
}