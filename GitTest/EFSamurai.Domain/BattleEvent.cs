using System;
using System.Collections.Generic;
using System.Text;

namespace EFSamurai.Domain
{
	public class BattleEvent
	{
		public int Id { get; set; }
		public int Order { get; set; }
		public string Summary { get; set; }
		public string Description { get; set; }

		// Foreign key til BattleLog
		public int BattleLogId { get; set; }
		public BattleLog BattleLog { get; set; }
	}
}
