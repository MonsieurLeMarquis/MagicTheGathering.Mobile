namespace Objects.Bestiaire.DataBase.Cards
{
	public class Edition
	{

		public int DataBaseID { get; set; }
		public string ID { get; set; }
		public string Name { get; set; }
		public bool Premiums { get; set; }
		public bool Tricolors { get; set; }
		public bool Mythics { get; set; }
		public bool Lands { get; set; }
		public bool Transforms { get; set; }
		public double NbMythics { get; set; }
		public double NbRares { get; set; }
		public double NbUncos { get; set; }
		public double NbCommunes { get; set; }
		public double NbRaresSpeciales { get; set; }
		public double NbUncosSpeciales { get; set; }
		public double NbCommunesSpeciales { get; set; }
		public bool DataGathererLoaded { get; set; }
		public bool DataBestiaireLoaded { get; set; }
		public bool DataImagesLoaded { get; set; }

		public Edition()
		{
			DataBaseID = 0;
			ID = "";
			Name = "";
			Premiums = false;
			Tricolors = false;
			Mythics = false;
			Lands = false;
			Transforms = false;
			NbMythics = 1d;
			NbRares = 1d;
			NbUncos = 3d;
			NbCommunes = 11d;
			NbRaresSpeciales = 0d;
			NbUncosSpeciales = 0d;
			NbCommunesSpeciales = 0d;
			DataGathererLoaded = false;
			DataBestiaireLoaded = false;
			DataImagesLoaded = false;
		}

		public Edition(Objects.Bestiaire.WebServices.Edition edition)
		{
			DataBaseID = 0;
			ID = edition.EditionID ?? "";
			Name = edition.Nom ?? "";
			Premiums = edition.Premiums == 1;
			Tricolors = edition.Tricolors == 1;
			Mythics = edition.Mythics == 1;
			Lands = edition.Lands == 1;
			Transforms = edition.Transforms == 1;
			NbMythics = edition.Nb_Mythics;
			NbRares = edition.Nb_Rares;
			NbUncos = edition.Nb_Uncos;
			NbCommunes = edition.Nb_Communes;
			NbRaresSpeciales = edition.Nb_Rares_Speciales;
			NbUncosSpeciales = edition.Nb_Uncos_Speciales;
			NbCommunesSpeciales = edition.Nb_Communes_Speciales;
			DataGathererLoaded = false;
			DataBestiaireLoaded = false;
			DataImagesLoaded = false;
		}

	}
}

