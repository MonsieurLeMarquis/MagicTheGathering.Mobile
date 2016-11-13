using MTG.DataExtractor.Objects.Managers;

namespace MTG.DataExtractor.Objects
{
	public class DonneeEdition
	{

		public enum TYPE_DONNEE
		{
			EDITION_NAME,
			EDITION_CODE_BESTIAIRE,
			EDITION_CODE_GATHERER,
			EDITION_CODE_MTGJSON,
            EDITION_RELEASE_DATE,
            EDITION_BORDER,
            EDITION_TYPE,
            EDITION_BOOSTER,
            EDITION_CARDS
		}

		public TYPE_DONNEE TypeDonnee;

		public override string ToString()
		{
			return ManageDonneeEdition.Libelle(this);
		}

        public DonneeEdition(TYPE_DONNEE typeDonnee)
        {
            TypeDonnee = typeDonnee;
        }

    }
}
