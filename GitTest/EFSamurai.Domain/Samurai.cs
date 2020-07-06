using System;
using System.Collections;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
	public class Samurai
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection <Quote> Quotes { get; set; }
	}
}
