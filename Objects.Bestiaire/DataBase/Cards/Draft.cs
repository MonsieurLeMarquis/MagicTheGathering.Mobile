using System.Collections.Generic;

namespace Objects.Bestiaire.DataBase.Cards
{
	public class Draft
	{
		
		public int DataBaseID { get; set; }
		public int ID { get; set; }
		public string Name { get; set; }
		public Dictionary<int, string> EditionsOrderID { get; set; }
		public bool Highlander { get; set; }

        public Draft()
        {
            DataBaseID = 0;
            ID = 0;
            Name = "";
            EditionsOrderID = new Dictionary<int, string>
            {
                { 1, "" },
                { 2, "" },
                { 3, "" }
            };
            Highlander = false;
		}

		public Draft(Objects.Bestiaire.WebServices.Draft draft)
		{
			DataBaseID = 0;
			ID = draft.ID;
			Name = draft.Nom ?? "";
			if (draft.Editions != null) {
				EditionsOrderID = new Dictionary<int, string> {
					{ 1, draft.Editions.Set1 ?? "" },
					{ 2, draft.Editions.Set2 ?? "" },
					{ 3, draft.Editions.Set3 ?? "" }
				};
			} else {
				EditionsOrderID = new Dictionary<int, string> { { 1, "" }, { 2, "" }, { 3, "" } };
			}
			Highlander = draft.Highlander == 1;
		}

	}
}

