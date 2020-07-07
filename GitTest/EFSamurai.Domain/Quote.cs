using System;
using System.Collections.Generic;
using System.Text;

namespace EFSamurai.Domain
{

	public class Quote
	{
		public int Id { get; set; }
		public string Text { get; set; }

		public QuoteStyle? QuoteStyle { get; set; }

		// Foreign key for Samurai
		public int SamuraiId { get; set; }
		public Samurai Samurai { get; set; }



	}
}
