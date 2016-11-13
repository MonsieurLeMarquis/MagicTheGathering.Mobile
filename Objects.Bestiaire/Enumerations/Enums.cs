using System;

namespace Objects.Bestiaire.Enumerations
{
	public class Enums
	{

		public enum TYPE_PLAYER {
			HUMAN, 
			COMPUTER,
			UNDEFINED
		}
			
		public enum TYPE_DRAFT { 
			FIRST_DRAFT, 
			REPLAY_DRAFT, 
			UNDEFINED 
		} 

		public enum TYPE_DRAFT_STATUS {
			DRAFT_START,
			DRAFT_ONGOING,
			DRAFT_BETWEEN_TWO_BOOSTERS,
			DRAFT_FINISH
		}

		public enum TYPE_PICK_STATUS {
			PICK_START,
			PICK_ONGOING,
			PICK_FINISH
		}

	}
}

