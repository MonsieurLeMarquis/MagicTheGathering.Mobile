using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;
using Objects.Bestiaire.Enumerations;

namespace Objects.Bestiaire.DataBase.Drafts
{
	public class DraftSequence
	{

		protected Enums.TYPE_DRAFT_STATUS TypeDraftStatus { get; set; }
		protected Enums.TYPE_PICK_STATUS TypePickStatus { get; set; }
		protected int NbBoosters { get; set; }
		protected int NbCardsByBooster { get; set; }
		public int CurrentBooster { get; set; }
		public int CurrentPick { get; set; }

	}
}

