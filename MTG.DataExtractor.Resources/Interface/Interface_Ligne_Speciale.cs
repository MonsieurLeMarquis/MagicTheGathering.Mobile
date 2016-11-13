namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Ligne_Speciale
    {

		public enum TYPE_LIGNE
		{
            CHARGEMENT_EN_COURS,
            VIDE,
            TOUTES_EDITIONS,
            TOUTES_CARTES,
            TOUTES_ICONES
		}

        public TYPE_LIGNE TypeLigne;

		public override string ToString()
		{
            switch (TypeLigne)
			{
                case TYPE_LIGNE.CHARGEMENT_EN_COURS:
                    return "Chargement en cours...";
                case TYPE_LIGNE.VIDE:
                    return "<Vide>";
                case TYPE_LIGNE.TOUTES_EDITIONS:
                    return "<Toutes les éditions>";
                case TYPE_LIGNE.TOUTES_CARTES:
                    return "<Toutes les cartes>";
                case TYPE_LIGNE.TOUTES_ICONES:
                    return "<Toutes les icônes>";
				default:
					return "???";
			}
		}

        public Interface_Ligne_Speciale(TYPE_LIGNE typeLigne)
		{
            TypeLigne = typeLigne;
		}

    }
}
