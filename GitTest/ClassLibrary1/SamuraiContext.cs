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

		public DbSet<Quote> Quotes;
		public DbSet<SecretIdentity> SecretIdentities;

		public DbSet<SamuraiBattle> SamuraiBattles;

		public DbSet<BattleLog> BattleLogs;
		public DbSet<BattleEvent> BattleEvents;
		public DbSet<Battle> Battles;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SamuraiBattle>().HasKey(c => new {c.BattleId, c.SamuraiId});
		}
		
	}
}
