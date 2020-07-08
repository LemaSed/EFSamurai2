using NUnit.Framework;
using EFSamurai.Domain;
using EFSamurai.Data;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.NUnitTest
{
	public class Tests
	{
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			using (var context = new SamuraiContext())
			{
				context.Database.EnsureDeleted();
				context.Database.Migrate();
			}
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test_AddOneSamuraiTwice()
		{
			EfMethods.AddOneSamurai("Zelda");
			EfMethods.AddOneSamurai("Link");
			string[] result = EfMethods.GetAllSamuraiNames();
			CollectionAssert.AreEqual(new[] { "Zelda", "Link" }, result);

		}

	}
}