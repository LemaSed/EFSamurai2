using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EFSamurai.Data;
using EFSamurai.Data.Migrations;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SamuraiBattle = EFSamurai.Domain.SamuraiBattle;
using SecretIdentity = EFSamurai.Domain.SecretIdentity;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{

			/*
		
			AddSomeBattles();
			AddOneSamuraiWithRelatedData();
			PrintAllSamuraiNamesWithALiases();*/
			//AddOneSamurai();
			//Console.WriteLine(FindSamuraiWithRealName("OleNordMan").Name);
			/*
			List<Quote> newList = ListAllQuotesOfType(quoteStyle:null);
			
			foreach (var VARIABLE in newList)
			{
				Console.WriteLine(VARIABLE.Text);	
			} */
			using (var context = new SamuraiContext())
			{
				context.Database.EnsureDeleted();
				context.Database.Migrate();
			}
		}

		private static void AddOneSamurai()
		{
			var samurai = new Samurai()
				{Name = "Zelda", HairStyle = HairStyle.Western}; //Lagt inn hairenum properties. 


			//Lager en using for å få lagt inn den nye samurai inn i databasen.
			//Denne delen snakker med databasen.
			using (var context = new SamuraiContext())
			{
				context.Samurais.Add(samurai);
				context.SaveChanges();
			}
		}


		//Metode for å legge til flere samurai samtidig. 
		private static void AddSomeSamurais()
		{
			IList<Samurai> newSamurai = new List<Samurai>()
			{
				new Samurai() {Name = "Lema"},
				new Samurai() {Name = "Pia"},
				new Samurai() {Name = "Gopitha"}
			};

			using (var context = new SamuraiContext())
			{
				context.Samurais.AddRange(newSamurai);
				context.SaveChanges();
			}
		}

		private static void AddSomeBattles()
		{
			List<Battle> CollectionBattles = new List<Battle>()
			{

				new Battle()
				{
					Description = "Corona krigen",
					StartDate = new DateTime(2020,12,01),
					EndDate = new DateTime(2020, 12, 15),
					Name = "FirstBattle",
					IsBrutal = true,
					BattleLog = new BattleLog()
					{
						BattleEvents = new List<BattleEvent>()
						{
							new BattleEvent() {Description = "FirstEvent"},
							new BattleEvent() {Description = "SecondBattleEvent"},
							new BattleEvent() {Description = "ThirdBattleEvent"}
						}
					}
				},

				new Battle()
				{
					Description = "What u gonna do ? ",
					StartDate = new DateTime(1987, 05, 01),
					EndDate = new DateTime(1989, 06 , 10),
					Name = "SecondBattle",
					IsBrutal = true,
					BattleLog = new BattleLog()
					{
						BattleEvents = new List<BattleEvent>()
						{
							new BattleEvent() {Description = "FirstEvent"},
							new BattleEvent() {Description = "SecondBattleEvent"},
							new BattleEvent() {Description = "ThirdBattleEvent"}
						}
					}
				},
				new Battle()
				{
					Description = "Helt greit",
					StartDate = new DateTime( 2015, 08 , 08 ),
					EndDate = new DateTime(1999, 12,12),
					Name = "ThirdBattle",
					IsBrutal = true,
					BattleLog = new BattleLog()
					{
						BattleEvents = new List<BattleEvent>()
						{
							new BattleEvent() {Description = "FirstEvent"},
							new BattleEvent() {Description = "SecondBattleEvent"},
							new BattleEvent() {Description = "ThirdBattleEvent"}
						}
					}
				}
			};

			using (var context = new SamuraiContext())
			{
				
				context.Battles.AddRange(CollectionBattles);
				context.SaveChanges();
			}

		}

		private static void AddOneSamuraiWithRelatedData()
		{

			

			using (var context = new SamuraiContext())
			{
				var samurai = new Samurai()
				{
					Name = "Ninja",
					HairStyle = HairStyle.Chonmage,
					Quotes = new List<Quote>()
					{
						new Quote() {Text = "FirstQuote"},
						new Quote() {Text = "SecondQuote"},
						new Quote() {Text = "ThirdQuote"}
					},
					SecretIdentity = new SecretIdentity() { RealName = "OleNordMan" },

					SamuraiBattles = new List<SamuraiBattle>()
					{
						new SamuraiBattle(){BattleId=1 },
						new SamuraiBattle(){BattleId = 2}
					}

				};
				context.Samurais.Add(samurai);
				context.SaveChanges();
			}
		}

		private static void ClearDatabase()
		{
			using (var context = new SamuraiContext())
			{
				// Note: As cascading delete is on (by default), it is enough to remove Samurais and Battles.
				//       Deleteing the rows in these two tables drags ("cascades") everything else with them.
				context.RemoveRange(context.Samurais);
				context.RemoveRange(context.Battles);

				//To restart IDENTITY counting from the tables, do like this:

				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Samurais', RESEED, 0)");
				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SecretIdentities', RESEED, 0)");
				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Quotes', RESEED, 0)");
				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Battles', RESEED, 0)");
				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleLogs', RESEED, 0)");
				context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleEvents', RESEED, 0)");

				context.SaveChanges();

			}
		}

		private  static List<string> ListAllSamuraiNames()
		{
			List<string> samuraiNames = new List<string>();

			using (var contex = new SamuraiContext())
			{
				foreach (string name in contex.Samurais.Select(s=> s.Name))
				{
					samuraiNames.Add(name);
				}
			}

			return samuraiNames;
		}

		private static List<string> ListAllSamuraiNames_OrderByName()
		{
			List<string> samuraiNames = new List<string>();

			using (var contex = new SamuraiContext())
			{
				foreach (string name in contex.Samurais.OrderBy(s=>s.Name).Select(s=>s.Name))
				{
					samuraiNames.Add(name);
				}
			}

			return samuraiNames;
		}

		private static List<string> ListAllSamuraiNames_OrderByIdDescending()
		{
			List<string> samuraiNames = new List<string>();

			using (var contex = new SamuraiContext())
			{
				foreach (string name in contex.Samurais.OrderByDescending(s => s.Name).Select(s => s.Name))
				{
					samuraiNames.Add(name);
				}
			}

			return samuraiNames;
		}

		private static Samurai FindSamuraiWithRealName(string name)
		{

			//returnerer en samurai basert på navn som er lagt inn. 
			using (var context = new SamuraiContext())
			{
				
				var nameSearch = context
					.Samurais
					.Include(s => s.SecretIdentity)
					.Where(s => s.SecretIdentity.RealName == name)
					.First();
			
				return nameSearch;
			}


		}

		private static List<Quote> ListAllQuotesOfType(QuoteStyle? quoteStyle)
		{
			List<Quote>  quoteStyleEnum = new List<Quote>();

			using (var contex = new SamuraiContext())
			{
				foreach (var quotes in contex.Quotes.Where(q=> q.QuoteStyle== quoteStyle))
				{
					quoteStyleEnum.Add(quotes);
				}
			}

			return quoteStyleEnum;
		}

		private static List<string> ListAllQuotesOfType_WithSamurai(QuoteStyle quoteStyle)
		{
			List<string> returnList = new List<string>();
			using (var context = new SamuraiContext())
			{
				var quoteList = context.Quotes
					.Include(q=>q.Samurai)
					.Where(q=> q.QuoteStyle==quoteStyle)
					.ToList();


				foreach (var quote in quoteList)
				{
					string quoteInfo = quote.Text + " is a " + quote.QuoteStyle + " by " + quote.Samurai.Name;
					returnList.Add((quoteInfo));
				}
			}

			return returnList;
		}

		private static List<string> ListAllBattles(DateTime from, DateTime to, bool? isBrutal)
		{
			List<string> returnbattleList = new List<string>();

			using (var context = new SamuraiContext())
			{
				var battleList = context.Battles
					.Where(b => b.StartDate == from).Where(b => b.EndDate == to).Where(b => b.IsBrutal == true).ToList();
				
				
				
				foreach (var battle in battleList)
				{
					string battlestring;

					if (battle.IsBrutal)
					{
						battlestring = battle.Name + " is a brutal battle within the period.";
					}

					else
					{
						battlestring = battle.Name + "is not a brutal battle within the period.";
					}

					returnbattleList.Add(battlestring);
					
				}
			}

			return returnbattleList;
		}

		private static ICollection<string> AllSamuraiNamesWithAliases()
		{
			ICollection <string> returnList = new List<string>();
			using (var context = new SamuraiContext())
			{
				var samuraiCollection = context.Samurais
					.Include(s => s.SecretIdentity).ToList();
				string print;

				foreach (var samurai in samuraiCollection)
				{
					if (samurai.SecretIdentity.Id != null)
					{
						print = samurai.SecretIdentity.RealName + " alias " + samurai.Name;
						returnList.Add(print);
					}
				}
			}

			return returnList;


		}

		private static void PrintAllSamuraiNamesWithALiases()
		{
			foreach (var print in AllSamuraiNamesWithAliases())
			{
				Console.WriteLine(print);
			}
		}
	}
}
