using System.Text;
using MTG.DataExtractor.Business;
using MTG.DataExtractor.Objects.Managers;

namespace MTG.DataExtractor.Console
{
    public class List : BaseCommand
    {

        public List(Arguments arguments) : base(arguments)
        {
        }

        public override StringBuilder ExecuteCommande()
        {
            var text = new StringBuilder();
            switch(_arguments.ArgumentList)
            {
                case Enums.ARGUMENT_LIST.EDITIONS:
                    text = ListEditions();
                    break;
                case Enums.ARGUMENT_LIST.DRAFTS:
                    text = ListDrafts();
                    break;
                case Enums.ARGUMENT_LIST.CARDS:
                    text.AppendLine("Non implémenté");
                    break;
                default:
                    text.AppendLine("Non implémenté");
                    break;
            }
            return text;
        }

        private StringBuilder ListEditions()
        {
            var text = new StringBuilder();
            switch (_arguments.ArgumentServer)
            {
                case Enums.ARGUMENT_SERVER.BESTIAIRE:
                    ListEditionsBestiaire(text);
                    break;
                case Enums.ARGUMENT_SERVER.MTGJSON:
                    ListEditionsMtgJson(text);
                    break;
                case Enums.ARGUMENT_SERVER.GATHERER:
                    text.AppendLine("Non implémenté");
                    break;
                default:
                    var servers =
                    text.AppendLine("Serveur inconnu");
                    break;
            }
            return text;
        }

        private StringBuilder ListDrafts()
        {
            var text = new StringBuilder();
            switch (_arguments.ArgumentServer)
            {
                case Enums.ARGUMENT_SERVER.BESTIAIRE:
                    ListDraftsBestiaire(text);
                    break;
                case Enums.ARGUMENT_SERVER.MTGJSON:
                case Enums.ARGUMENT_SERVER.GATHERER:
                    text.AppendLine("Seul le Bestiaire propose une liste de drafts");
                    break;
                default:
                    var servers =
                    text.AppendLine("Serveur inconnu");
                    break;
            }
            return text;
        }

        private void ListEditionsMtgJson(StringBuilder text)
        {
            var editions = MtgJson.DownloadEditions();
            var index = 1;
            editions.ForEach(edition => {
                text.AppendLine(index.ToString("[000]") + " " + ManageEdition.GetResume(edition));
                index++;
            });
        }

        private void ListEditionsBestiaire(StringBuilder text)
        {

            var editions = Bestiaire.GetEditions();
            var index = 1;
            editions.ForEach(edition => {
                text.AppendLine(index.ToString("[000]") + " " + ManageBestiaireEdition.GetResume(edition));
                index++;
            });
        }

        private void ListDraftsBestiaire(StringBuilder text)
        {

            var drafts = Bestiaire.GetDrafts();
            var index = 1;
            drafts.ForEach(draft => {
                text.AppendLine(index.ToString("[000]") + " " + ManageBestiaireDraft.GetResume(draft));
                index++;
            });
        }

    }
}
