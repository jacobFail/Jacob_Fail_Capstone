using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob_Fail_Capstone
{
	public class FictionBook:Book
	{
		public string Genre { get; set; }

		public override string ToString()
		{
			return "Title: " + BookTitle + " Author: " + AuthorName + " Copies: " + NumberInStock + " Date Added:" + DateAdded + " Genre: " + Genre + " (Fiction)";
		}
	}
}
