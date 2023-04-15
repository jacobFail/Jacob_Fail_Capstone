using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Jacob_Fail_Capstone
{
	class Author
	{
		[PrimaryKey, AutoIncrement]

		public int AuthorID { get; set; }
		public string AuthorName { get; set; }

		public DateTime DateAdded { get; set; }


		public override string ToString()
		{
			return (AuthorName + " Dated Added:" + DateAdded);
		}


	}
}
