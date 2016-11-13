using System;
using System.IO;
using System.Reflection;

namespace MTG.DataExtractor.Business.Helpers
{
    public class HelperPath
    {

        public static string GetOutputDirectory(string directory)
        {
            var result = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            result = Path.Combine(result, "output");
            result = Path.Combine(result, directory);
            result = Path.Combine(result, DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
            return result;
        }

    }
}
