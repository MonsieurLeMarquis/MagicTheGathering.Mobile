namespace MTG.DataExtractor.Objects.Managers
{
    public class ManageEdition
    {

        public static string GetResume(Edition edition)
        {
            return /*edition.releaseDate.ToString("dd-MM-yyyy") + " - " +*/ edition.code + " - " + edition.name;
        }

    }
}
