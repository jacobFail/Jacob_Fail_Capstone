using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Jacob_Fail_Capstone
{
	public class Book
	{
		[PrimaryKey, AutoIncrement]

		public int BookID { get; set; }
		public string BookTitle { get; set; }
		public int AuthorID { get; set; }

		public string AuthorName { get; set; }
		public string NumberInStock { get; set; }		
		public string DateAdded  { get; set; }

		public override string ToString()
		{
			return "Title: " + BookTitle + " Author: " + AuthorName + " Copies: " + NumberInStock + " Date Added:" + DateAdded;
		}
	

	}
}
