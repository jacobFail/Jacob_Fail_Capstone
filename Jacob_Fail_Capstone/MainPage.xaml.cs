using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jacob_Fail_Capstone
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}



		public async void OnAuthorSearchClicked(object sender, EventArgs e)
		{
			var fictionBookList = await Database.GetFictionBooksByAuthorAsync(searchEditor.Text);
			var nonFictionBooklist = await Database.GetNonFictionBooksByAuthorAsync(searchEditor.Text);
			var bookList = new List<Book>();
			bookList.AddRange(fictionBookList);
			bookList.AddRange(nonFictionBooklist);
			resultList.ItemsSource = bookList;		
		}

		public async void OnFictionTitleSearchClicked(object sender, EventArgs e)
		{
			resultList.ItemsSource = await Database.GetFictionBooksAsync(searchEditor.Text);
		}

		public async void OnNonFictionTitleSearchClicked(object sender, EventArgs e)
		{
			resultList.ItemsSource = await Database.GetNonFictionBooksAsync(searchEditor.Text);
		}

		public async void OnNewArrivalsClicked(object sender, EventArgs e)
		{
			var fictionBookList = await Database.GetNewFictionBooksAsync();
			var nonFictionBooklist = await Database.GetNewNonFictionBooksAsync();
			var bookList = new List<Book>();
			bookList.AddRange(fictionBookList);
			bookList.AddRange(nonFictionBooklist);
			resultList.ItemsSource = bookList;
		}
		public async void OnAllFictionClicked(object sender, EventArgs e)
		{
			resultList.ItemsSource = await Database.GetAllFictionBooksAsync();
		}

		public async void OnAllNonFictionClicked(object sender, EventArgs e)
		{
			resultList.ItemsSource = await Database.GetAllNonFictionBooksAsync();
		}

		public async void OnEmployeeLoginClicked(object sender, EventArgs e)
		{

			var storePasswordList = await Database.CheckForStorePassword();

			if (storePasswordList.Count == 1)
			{
				await Navigation.PushAsync(new EmployeeLoginPage());
			}
			else
			{
				await Navigation.PushAsync(new SetupPage());
			}
		}

		public async void OnSearchResultTapped(object sender, EventArgs e)
		{
			var currentBook = resultList.SelectedItem;

			if (currentBook != null)
			{
				await DisplayAlert("Book Information", currentBook.ToString(), "OK");
			}
			
		}

	}
	
}
