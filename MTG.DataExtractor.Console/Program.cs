namespace MTG.DataExtractor.Console
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var arguments = ManageArguments.GetArguments(args);
            var command = ManageCommand.GetCommand(arguments);
            var text = command.ExecuteCommande();
            System.Console.WriteLine();
            System.Console.WriteLine(text);
        }

    }
}
