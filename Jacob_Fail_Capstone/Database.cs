using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;





namespace Jacob_Fail_Capstone
{
    class Database
    {
        static SQLiteAsyncConnection database;

        static async Task Init()
        {


            if (database == null)
            {
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Database231");

                database = new SQLiteAsyncConnection(databasePath);
                database.CreateTableAsync<Book>().Wait();
                database.CreateTableAsync<Author>().Wait();
                database.CreateTableAsync<NonFictionBook>().Wait();
                database.CreateTableAsync<FictionBook>().Wait();
                database.CreateTableAsync<EmployeeLogin>().Wait();

            }
        }

        public static async Task<List<EmployeeLogin>> GetStorePasswordAsync(string enteredPassword)
        {
            await Init();
            return await database.QueryAsync<EmployeeLogin>("SELECT * FROM EmployeeLogin WHERE StorePassword = ?", enteredPassword);
        }

        public static async Task<List<EmployeeLogin>> CheckForStorePassword()
        {
            await Init();
            return await database.QueryAsync<EmployeeLogin>("SELECT * FROM EmployeeLogin;");
        }

        public static async void SaveEmployeeLoginAsync(EmployeeLogin employeeLogin)
        {
            await Init();
            await database.InsertAsync(employeeLogin);
        }

        public static async void UpdateEmployeeLoginAsync(string storePassword)
        {
            await Init();
            await database.QueryAsync<EmployeeLogin>("UPDATE EmployeeLogin SET StorePassword = ?" , storePassword);
        }

        public static async void SaveAuthorAsync(Author author)
        {
            await Init();
            author.DateAdded = DateTime.Now;
            author.AuthorID = await database.InsertAsync(author);
        }

        public static async Task<List<Author>> GetAuthorAsync(string authorName)
        {
            await Init();
            return await database.QueryAsync<Author>("SELECT * FROM Author WHERE AuthorName = ?" , authorName);

        }

        public static async Task<List<Author>> GetAllAuthorsAsync()
        {
            await Init();
            return await database.Table<Author>().ToListAsync();
        }
        public static async void RemoveAuthorAsync(Author author)
        {
            await Init();
            await database.QueryAsync<FictionBook>("DELETE FROM FictionBook WHERE AuthorID = '" + author.AuthorID + "';");
            await database.QueryAsync<NonFictionBook>("DELETE FROM NonFictionBook WHERE AuthorID = '" + author.AuthorID + "';");
            await database.QueryAsync<Author>("DELETE FROM Author WHERE AuthorID = '" + author.AuthorID + "';");
            
        }

        public static async void SaveFictionBookAsync(FictionBook book)
        {
            await Init();
            book.DateAdded = DateTime.Now.ToString("yyyy-MM-dd");
            book.BookID = await database.InsertAsync(book);
        }


        public static async void SaveNonFictionBookAsync(NonFictionBook book)
        {
            await Init();
            book.DateAdded = DateTime.Now.ToString("yyyy-MM-dd");
            book.BookID = await database.InsertAsync(book);
        }

        public static async Task<List<FictionBook>> GetAllFictionBooksAsync()
        {
            await Init();
            return await database.QueryAsync<FictionBook>("SELECT * FROM FictionBook;");

        }

        public static async Task<List<NonFictionBook>> GetAllNonFictionBooksAsync()
        {
            await Init();
            return await database.QueryAsync<NonFictionBook>("SELECT * FROM NonFictionBook;");

        }

        public static async Task<List<FictionBook>> GetFictionBooksAsync(string bookTitle)
        {
            await Init();
 
            return await database.QueryAsync<FictionBook>("SELECT * FROM FictionBook WHERE BookTitle = ?" , bookTitle);
            
        }

        public static async Task<List<NonFictionBook>> GetNonFictionBooksAsync(string bookTitle)
        {
            await Init();
            
            return await database.QueryAsync<NonFictionBook>("SELECT * FROM NonFictionBook WHERE BookTitle = ?", bookTitle);
            
        }

        public static async Task<List<FictionBook>> GetFictionBooksByAuthorAndTitleAsync(string authorName, string bookTitle)
        {
            await Init();
            return await database.QueryAsync<FictionBook>("SELECT * FROM FictionBook WHERE AuthorName = ? AND BookTitle = ?",  authorName, bookTitle);
        }

        public static async Task<List<NonFictionBook>> GetNonFictionBooksByAuthorAndTitleAsync(string authorName, string bookTitle)
        {
            await Init();
            return await database.QueryAsync<NonFictionBook>("SELECT * FROM NonFictionBook WHERE AuthorName = ? AND BookTitle = ?", authorName, bookTitle);
        }

        public static async void UpdateFictionNumberInStockAsync(string authorName, string bookTitle, string numberInStock)
        {
            await Init();
            await database.QueryAsync<FictionBook>("UPDATE FictionBook SET NumberInStock = ?  WHERE AuthorName = ? AND BookTitle = ?", numberInStock, authorName, bookTitle);
        }

        public static async void UpdateNonFictionNumberInStockAsync(string authorName, string bookTitle, string numberInStock)
        {
            await Init();
            await database.QueryAsync<NonFictionBook>("UPDATE NonFictionBook SET NumberInStock = ?  WHERE AuthorName = ? AND BookTitle = ?", numberInStock, authorName, bookTitle);
        }


        public static async Task<List<FictionBook>> GetFictionBooksByAuthorAsync(string authorName)
        {
            await Init();
            return await database.QueryAsync<FictionBook>("SELECT * FROM FictionBook WHERE AuthorName = ?",  authorName);
        }

        public static async Task<List<NonFictionBook>> GetNonFictionBooksByAuthorAsync(string authorName)
        {
            await Init();
            return await database.QueryAsync<NonFictionBook>("SELECT * FROM NonFictionBook WHERE AuthorName = ?", authorName);
        }

        public static async Task<List<NonFictionBook>> GetNewNonFictionBooksAsync()
        {
            await Init();
            
            DateTime currentDate = DateTime.Now.Date;

            return await database.QueryAsync<NonFictionBook>("SELECT * FROM NonFictionBook WHERE strftime('%Y-%m', DateAdded) = strftime('%Y-%m', 'now');");
        }

        public static async Task<List<FictionBook>> GetNewFictionBooksAsync()
        {
            await Init();
            DateTime currentDate = DateTime.Now.Date;

            return await database.QueryAsync<FictionBook>("SELECT * FROM FictionBook WHERE strftime('%Y-%m', DateAdded) = strftime('%Y-%m', 'now');");
        }

        public static async void RemoveFictionBookAsync(string authorName, string bookTitle)
        {
                 await Init();
                 await database.QueryAsync<FictionBook>("DELETE FROM FictionBook WHERE BookTitle = ? AND AuthorName = ?",  bookTitle, authorName);

        }

        public static async void RemoveNonFictionBookAsync(string authorName, string bookTitle)
        {
            await Init();
            await database.QueryAsync<NonFictionBook>("DELETE FROM NonFictionBook WHERE BookTitle = ? AND AuthorName = ?", bookTitle, authorName);

        }

    }
}
