using System;
using System.Collections.Generic;
using System.Linq;
using MTG.DataExtractor.Utils;

namespace MTG.DataExtractor.Console
{
    public class ManageArguments
    {

        public static Arguments GetArguments(string[] args)
        {
            Arguments result = new Arguments { TypeCommand = Enums.TYPE_COMMAND.UNDEFINED };

            try
            {

                var arguments = args != null ? new List<string>(args) : new List<string>(); 
                var sortedArguments = ExtractDetails(arguments);

                if (sortedArguments.Any())
                {

                    foreach (var command in sortedArguments.Keys)
                    {

                        if (ManageEnums.TypeCommands().Contains(command))
                        {
                            var enumCommand = Enumerations.GetValueFromDescription<Enums.TYPE_COMMAND>(command);
                            result.TypeCommand = enumCommand;
                            switch(enumCommand)
                            {
                                case Enums.TYPE_COMMAND.LIST:
                                    result.ArgumentList = GetArgumentList(sortedArguments[command]);
                                    break;
                                case Enums.TYPE_COMMAND.LOAD:
                                    result.ArgumentLoad = GetArgumentLoad(sortedArguments[command]);
                                    break;
                            }
                        }
                        else
                        {
                            var enumCommand = Enumerations.GetValueFromDescription<Enums.TYPE_ARGUMENT>(command);
                            switch (enumCommand)
                            {
                                case Enums.TYPE_ARGUMENT.SERVER:
                                    result.ArgumentServer = GetArgumentServer(sortedArguments[command]);
                                    break;
                                case Enums.TYPE_ARGUMENT.EDITION:
                                    result.AgumentEdition = sortedArguments[command].FirstOrDefault();
                                    break;
                            }
                        }

                    }

                }
                else
                {
                    result.TypeCommand = Enums.TYPE_COMMAND.HELP;
                }
                
            }
            catch
            {
                result = new Arguments { TypeCommand = Enums.TYPE_COMMAND.UNDEFINED };
            }

            return result;
        }

        private static Enums.ARGUMENT_LIST GetArgumentList(List<string> arguments)
        {
            var result = Enums.ARGUMENT_LIST.UNDEFINED;
            var selection = ManageEnums.ArgumentLists().Intersect(arguments);
            if (selection.Any())
            {
                result = Enumerations.GetValueFromDescription<Enums.ARGUMENT_LIST>(selection.First());
            }
            return result;
        }

        private static Enums.ARGUMENT_LOAD GetArgumentLoad(List<string> arguments)
        {
            var result = Enums.ARGUMENT_LOAD.UNDEFINED;
            var selection = ManageEnums.ArgumentLoads().Intersect(arguments);
            if (selection.Any())
            {
                result = Enumerations.GetValueFromDescription<Enums.ARGUMENT_LOAD>(selection.First());
            }
            return result;
        }

        private static Enums.ARGUMENT_SERVER GetArgumentServer(List<string> arguments)
        {
            var result = Enums.ARGUMENT_SERVER.UNDEFINED;
            var selection = ManageEnums.ArgumentServers().Intersect(arguments);
            if (selection.Any())
            {
                result = Enumerations.GetValueFromDescription<Enums.ARGUMENT_SERVER>(selection.First());
            }
            return result;
        }

        private static Dictionary<string, List<string>> ExtractDetails(List<string> arguments)
        {
            var result = new Dictionary<string, List<string>>();
            var currentCommand = "";
            foreach (string argument in arguments)
            {
                if (!string.IsNullOrEmpty(argument))
                {
                    if (ManageEnums.TypeArguments().Contains(argument))   
                    {
                        currentCommand = argument;
                        if (!result.ContainsKey(argument))
                        {
                            result.Add(argument, new List<string>());
                        }
                    }
                    else
                    {
                        if (result.ContainsKey(currentCommand) && !result[currentCommand].Contains(argument))
                        {
                            result[currentCommand].Add(argument);
                        }
                    }
                }
            }
            return result;
        }

    }
}
