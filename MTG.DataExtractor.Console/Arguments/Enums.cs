using System.ComponentModel;

namespace MTG.DataExtractor.Console
{
    public class Enums
    {

        public enum TYPE_COMMAND
        {
            UNDEFINED,
            [Description("-list")]
            LIST,
            [Description("-load")]
            LOAD,
            [Description("-help")]
            HELP
        }

        public enum TYPE_ARGUMENT
        {
            UNDEFINED,
            [Description("-list")]
            LIST,
            [Description("-load")]
            LOAD,
            [Description("-help")]
            HELP,
            [Description("-server")]
			SERVER,
			[Description("-edition")]
			EDITION
        }

        public enum ARGUMENT_LIST
        {
            UNDEFINED,
            [Description("editions")]
            EDITIONS,
            [Description("cards")]
			CARDS,
			[Description("drafts")]
			DRAFTS
        }

        public enum ARGUMENT_SERVER
        {
            UNDEFINED,
            [Description("gatherer")]
            GATHERER,
            [Description("mtgjson")]
            MTGJSON,
            [Description("bestiaire")]
            BESTIAIRE
        }

        public enum ARGUMENT_LOAD
        {
            UNDEFINED,
            [Description("edition")]
            EDITION,
            [Description("rules")]
			RULES,
			[Description("all")]
			ALL
        }

    }
}
