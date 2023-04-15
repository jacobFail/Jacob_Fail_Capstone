using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob_Fail_Capstone
{
	public class NonFictionBook:Book
	{
		public string Subject { get; set; }

		public override string ToString()
		{
			return "Title: " + BookTitle + " Author: " + AuthorName + " Copies: " + NumberInStock + " Date Added:" + DateAdded + " Subject: " + Subject + " (Non-Fiction)";
		}

	}
}
