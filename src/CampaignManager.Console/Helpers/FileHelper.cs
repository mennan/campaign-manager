using System.IO;

namespace CampaignManager.Console.Helpers
{
    public static class FileHelper
    {
        public static string[] ReadFileAsLine(string path)
        {
            if (!File.Exists(path)) return new string[0];
            
            var lines = File.ReadAllLines(path);
            return lines;
        }
    }
}