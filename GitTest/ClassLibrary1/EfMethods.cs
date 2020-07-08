using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.Data
{
	public class EfMethods
	{
		public static void AddOneSamurai(string name)
		{
			IList<Samurai> newSamurai = new List<Samurai>()
			{
				new Samurai() {Name = name},
				
			};

			using (var context = new SamuraiContext())
			{
				context.Samurais.AddRange(newSamurai);
				context.SaveChanges();
			}
		}


		public static string [] GetAllSamuraiNames()
		{
			string[] samuraiNames;
			using (var context = new SamuraiContext())
			{
				samuraiNames = context
					.Samurais
					.Select(s => s.Name).ToArray();

			}

			return samuraiNames;


		}


	}
}
