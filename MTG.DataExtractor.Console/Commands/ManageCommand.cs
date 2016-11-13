namespace MTG.DataExtractor.Console
{
    public class ManageCommand
    {

        public static BaseCommand GetCommand(Arguments arguments)
        {
            BaseCommand command = new Error(arguments);
            switch (arguments.TypeCommand)
            {
                case Enums.TYPE_COMMAND.HELP:
                    command = new Help(arguments);
                    break;
                case Enums.TYPE_COMMAND.LIST:
                    command = new List(arguments);
                    break;
                case Enums.TYPE_COMMAND.LOAD:
                    command = new Load(arguments);
                    break;
            }
            return command;
        }

    }
}
