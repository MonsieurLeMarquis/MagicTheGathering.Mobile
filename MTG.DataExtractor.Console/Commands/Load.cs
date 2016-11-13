using MTG.DataExtractor.Business;
using MTG.DataExtractor.Business.Helpers;
using MTG.DataExtractor.Files;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace MTG.DataExtractor.Console
{
    public class Load : BaseCommand
    {

        public Load(Arguments arguments) : base(arguments)
        {
        }

        public override StringBuilder ExecuteCommande()
        {
            var text = new StringBuilder();
            switch (_arguments.ArgumentLoad)
            {
                case Enums.ARGUMENT_LOAD.EDITION:
                    LoadEdition(text);
					break;
				case Enums.ARGUMENT_LOAD.RULES:
					LoadRules(text);
					break;
				case Enums.ARGUMENT_LOAD.ALL:
					switch (_arguments.ArgumentServer) {
						case Enums.ARGUMENT_SERVER.BESTIAIRE:
							LoadAllFilesBestiaire(text);
							break;
						case Enums.ARGUMENT_SERVER.MTGJSON:
							LoadAllFilesMtgJson(text);
							break;
						default:
							text.AppendLine("Non implémenté");
							break;
					}
					break;
                default:
                    text.AppendLine("Non implémenté");
                    break;
            }
            return text;
        }

        private void LoadEdition(StringBuilder text)
        {
            if (string.IsNullOrEmpty(_arguments.AgumentEdition))
            {
                text.AppendLine("Edition non renseignée");
            }
            else
            {
                Hybrid.LoadAllEdition(_arguments.AgumentEdition);
            }
		}

		private void LoadAllFilesBestiaire(StringBuilder text)
		{
			Hybrid.LoadAllJsonFilesBestiaire();
		}

		private void LoadAllFilesMtgJson(StringBuilder text)
		{
			Hybrid.LoadAllJsonFilesMtgJson();
		}

        private void LoadRules(StringBuilder text)
        {
            Rules.LoadRules();
        }

    }
}
