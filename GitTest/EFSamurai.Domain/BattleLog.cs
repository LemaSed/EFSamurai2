using System;
using System.Collections.Generic;
using System.Text;

namespace EFSamurai.Domain
{
	public class BattleLog
	{
		public int Id { get; set; }
		public string Name { get; set; }


		//Foreign key to battle. 
		public int BattleId { get; set; }
		public Battle Battle { get; set; }

		//Det finnes FK i BattleEvent. Dermed må "instansiere" den propertien også her. 
		//1-M forhold mellom BattleLog og BattleEvent.
		public BattleEvent BattleEvent { get; set; }

	}
}
