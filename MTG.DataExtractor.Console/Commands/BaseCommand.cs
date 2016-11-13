using System.Text;

namespace MTG.DataExtractor.Console
{
    public abstract class BaseCommand
    {

        protected Arguments _arguments { get; set; }

        public abstract StringBuilder ExecuteCommande();

        public BaseCommand(Arguments arguments)
        {
            _arguments = arguments;
        }

    }
}
