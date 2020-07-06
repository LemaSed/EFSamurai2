using System;
using System.Collections.Generic;
using System.Text;

namespace EFSamurai.Domain
{
	public class SamuraiBattle
	{ 

		//Connect foreign key from Samurai
		public int SamuraiId { get; set; }
		public Samurai Samurai { get; set; }

		//Connect foreign key from Battle.
		public int BattleId { get; set; }
		public Battle Battle { get; set; }

		


	}
}
