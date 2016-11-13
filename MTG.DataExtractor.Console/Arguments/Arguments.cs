namespace MTG.DataExtractor.Console
{
    public class Arguments
    {

        public Enums.TYPE_COMMAND TypeCommand { get; set; }
        public Enums.ARGUMENT_LIST ArgumentList { get; set; }
        public Enums.ARGUMENT_SERVER ArgumentServer { get; set; }
        public Enums.ARGUMENT_LOAD ArgumentLoad { get; set; }
        public string AgumentEdition { get; set; }

    }
}
