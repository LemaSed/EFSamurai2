using System;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.Data
{
	public class SamuraiContext : DbContext
	{
		public DbSet<Samurai> Samurais { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				@"Server = (localdb)\MSSQLLocalDB; " +
				@"Database = EFSamurai; " +
				@"Trusted_Connection = True; ");

		}
	}
}
