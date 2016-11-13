using System.Text;

namespace MTG.DataExtractor.Console
{
    public class Error : BaseCommand
    {

        public override StringBuilder ExecuteCommande()
        {
            var text = new StringBuilder();
            text.AppendLine("ERREUR : commande inconnue");
            return text;
        }
        
        public Error(Arguments arguments) : base(arguments)
        {
        }

    }
}
