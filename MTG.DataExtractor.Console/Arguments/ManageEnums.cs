using MTG.DataExtractor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG.DataExtractor.Console
{
    public class ManageEnums
    {

        public static List<string> TypeCommands()
        {
            var values = Enum.GetValues(typeof(Enums.TYPE_COMMAND)).Cast<Enums.TYPE_COMMAND>().Select(value => Enumerations.GetDescription(value)); ;
            values = values.Except(new List<string> { Enumerations.GetDescription(Enums.TYPE_COMMAND.UNDEFINED) });
            values = values.OrderBy(value => value);
            return values.ToList();
        }

        public static List<string> ArgumentLists()
        {
            var values = Enum.GetValues(typeof(Enums.ARGUMENT_LIST)).Cast<Enums.ARGUMENT_LIST>().Select(value => Enumerations.GetDescription(value)); ;
            values = values.Except(new List<string> { Enumerations.GetDescription(Enums.ARGUMENT_LIST.UNDEFINED) });
            values = values.OrderBy(value => value);
            return values.ToList();
        }

        public static List<string> ArgumentLoads()
        {
            var values = Enum.GetValues(typeof(Enums.ARGUMENT_LOAD)).Cast<Enums.ARGUMENT_LOAD>().Select(value => Enumerations.GetDescription(value)); ;
            values = values.Except(new List<string> { Enumerations.GetDescription(Enums.ARGUMENT_LOAD.UNDEFINED) });
            values = values.OrderBy(value => value);
            return values.ToList();
        }

        public static List<string> ArgumentServers()
        {
            var values = Enum.GetValues(typeof(Enums.ARGUMENT_SERVER)).Cast<Enums.ARGUMENT_SERVER>().Select(value => Enumerations.GetDescription(value));
            values = values.Except(new List<string> { Enumerations.GetDescription(Enums.ARGUMENT_SERVER.UNDEFINED) });
            values = values.OrderBy(value => value);
            return values.ToList();
        }

        public static List<string> TypeArguments()
        {
            var values = Enum.GetValues(typeof(Enums.TYPE_ARGUMENT)).Cast<Enums.TYPE_ARGUMENT>().Select(value => Enumerations.GetDescription(value));
            values = values.Except(new List<string> { Enumerations.GetDescription(Enums.TYPE_ARGUMENT.UNDEFINED) });
            values = values.OrderBy(value => value);
            return values.ToList();
        }

    }
}
