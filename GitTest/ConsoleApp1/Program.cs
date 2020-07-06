using System;
using System.Collections;
using System.Collections.Generic;
using EFSamurai.Data;
using EFSamurai.Domain;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private static void AddOneSamurai()
		{
			var samurai = new Samurai() { Name = "Zelda", HairStyle = HairStyle.Western}; //Lagt inn hairenum properties. 


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
					StartDate = Convert.ToDateTime(15 / 02 / 2020),
					EndDate = Convert.ToDateTime(01 / 01 / 2020),
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
					StartDate = Convert.ToDateTime(15 / 05 / 1987),
					EndDate = Convert.ToDateTime(01 / 06 / 1991),
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
					StartDate = Convert.ToDateTime(15 / 08 / 2015),
					EndDate = Convert.ToDateTime(01 / 01 / 2018),
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
			var samurai = new Samurai()
			{
				Name = "Ninja", HairStyle = HairStyle.Chonmage, Quotes = new List<Quote>()
				{
					new Quote(){Text = "FirstQuote"},
					new Quote(){Text = "SecondQuote"},
					new Quote(){Text = "ThirdQuote"}
				}, 
				SecretIdentity = new SecretIdentity() {RealName = "OleNordMan"}

			};

			using (var context = new SamuraiContext())
			{
				context.Samurais.Add(samurai);
				context.SaveChanges();
			}
		}


	}
}
