namespace TestEngine.Core
{
    public class GlobalVariables
    {
        public static string ConfigFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}\\testFrameworkConfig.json";
    }
}