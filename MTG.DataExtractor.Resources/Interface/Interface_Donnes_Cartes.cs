namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Donnes_Cartes
	{

		public enum TYPE_DONNEES_CARTES
		{
			BASE,
			EXTRAS
		}

		public TYPE_DONNEES_CARTES TypeDonnesCartes;

		public override string ToString()
		{
			switch(TypeDonnesCartes)
			{
				case TYPE_DONNEES_CARTES.BASE:
					return "Données de base";
				case TYPE_DONNEES_CARTES.EXTRAS:
					return "Données avec extras";
				default:
					return "???";
			}
		}

		public Interface_Donnes_Cartes (TYPE_DONNEES_CARTES typeDonnesCartes)
		{
			TypeDonnesCartes = typeDonnesCartes;
		}

	}
}
