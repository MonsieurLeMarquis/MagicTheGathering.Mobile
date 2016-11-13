using MTG.DataExtractor.Utils;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MTG.DataExtractor.Console
{
    public class Help : BaseCommand
    {

        public Help(Arguments arguments) : base(arguments)
        {
        }

        protected string Tabulation
        {
            get
            {
                return "    ";
            }
        }

        protected string Espace
        {
            get
            {
                return " ";
            }
        }

        protected string DeuxPoints
        {
            get
            {
                return " : ";
            }
        }

        protected string Egal
        {
            get
            {
                return " = ";
            }
        }

        protected string CommandList
        {
            get
            {
                return Enumerations.GetDescription(Enums.TYPE_COMMAND.LIST);
            }
        }

        protected string CommandLoad
        {
            get
            {
                return Enumerations.GetDescription(Enums.TYPE_COMMAND.LOAD);
            }
        }

        protected string CommandServer
        {
            get
            {
                return Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER);
            }
		}

		protected string CommandEdition
		{
			get
			{
				return Enumerations.GetDescription(Enums.TYPE_ARGUMENT.EDITION);
			}
		}

        protected string ArgumentList
        {
            get
            {
                return "[list]";
            }
        }

        protected string ArgumentServer
        {
            get
            {
                return "[server]";
            }
        }

        protected string ArgumentLoad
        {
            get
            {
                return "[load]";
            }
		}

		protected string ArgumentEdition
		{
			get
			{
				return "[edition]";
			}
		}

        protected string Servers
        {
            get
            {
                return string.Join(", ", ManageEnums.ArgumentServers());
            }
        }

        protected string Lists
        {
            get
            {
                return string.Join(", ", ManageEnums.ArgumentLists());
            }
        }

        protected string Loads
        {
            get
            {
                return string.Join(", ", ManageEnums.ArgumentLoads());
            }
        }

        protected string VersionNumber
        {
            get
            {
                return "V" + Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        protected string ExecutableName
        {
            get
            {
                return Process.GetCurrentProcess().ProcessName + ".exe";
            }
        }

        private void GenerateTitle(StringBuilder text)
        {
            text.AppendLine("---====================================================================================---");
            text.AppendLine("---                                  MTG Data Extractor " + VersionNumber + "                       ---");
            text.AppendLine("---====================================================================================---");
        }

        private void GenerateTitleExplanation(StringBuilder text)
        {
            text.AppendLine("   Aide à l'utilisation de l'outils d'extraction des données Magic The Gathering");
        }

        private void GenerateCommands(StringBuilder text)
        {
            text.AppendLine(Tabulation + "Commandes : ");
			text.AppendLine(Tabulation + Tabulation + CommandList + Espace + ArgumentList + Espace + CommandServer + Espace + ArgumentServer);
			text.AppendLine(Tabulation + Tabulation + CommandLoad + Espace + ArgumentLoad + Espace + CommandEdition + Espace + ArgumentEdition);
			text.AppendLine(Tabulation + Tabulation + CommandLoad + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LOAD.ALL) + Espace + CommandServer + Espace + ArgumentServer);
        }

        private void GenerateLegends(StringBuilder text)
        {
            text.AppendLine(Tabulation + "Légende : ");
            text.AppendLine(Tabulation + Tabulation + ArgumentServer + Egal + Servers);
            text.AppendLine(Tabulation + Tabulation + ArgumentList + Egal + Lists);
            text.AppendLine(Tabulation + Tabulation + ArgumentLoad + Egal + Loads);
            text.AppendLine(Tabulation + Tabulation + ArgumentEdition + Egal + "ID Wizards");
        }

        private void GenerateExamples(StringBuilder text)
        {
            text.AppendLine(Tabulation + "Exemples : ");
            text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LIST) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LIST.EDITIONS) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_SERVER.MTGJSON));
            text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LIST) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LIST.EDITIONS) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_SERVER.BESTIAIRE));
            text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LIST) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LIST.DRAFTS) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_SERVER.BESTIAIRE));
			text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LOAD) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LOAD.EDITION) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.EDITION) + Espace + "BFZ");
			text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LOAD) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LOAD.ALL) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_SERVER.BESTIAIRE));
			text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LOAD) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LOAD.ALL) + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.SERVER) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_SERVER.MTGJSON));
            text.AppendLine(Tabulation + Tabulation + ExecutableName + Espace + Enumerations.GetDescription(Enums.TYPE_ARGUMENT.LOAD) + Espace + Enumerations.GetDescription(Enums.ARGUMENT_LOAD.RULES));
        }

        private void GenerateSeparator(StringBuilder text)
        {
            text.AppendLine("------------------------------------------------------------------------------------------");
        }
        
        public override StringBuilder ExecuteCommande()
        {
            var text = new StringBuilder();
            GenerateTitle(text);
            text.AppendLine();
            GenerateTitleExplanation(text);
            text.AppendLine();
            GenerateSeparator(text);
            text.AppendLine();
            GenerateCommands(text);
            text.AppendLine();
            GenerateLegends(text);
            text.AppendLine();
            GenerateExamples(text);
            text.AppendLine();
            GenerateSeparator(text);
            return text;
        }

    }
}
