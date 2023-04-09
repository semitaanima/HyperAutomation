using Newtonsoft.Json.Linq;

namespace TestEngine.Core
{
    public static class ConfigurationService
    {
        public static string BaseUrl
        {
            get
            {
                return JObject.Parse(File.ReadAllText(GlobalVariables.ConfigFilePath)).GetValue("baseUrl").ToString();
            }
        }

        /// <summary>
        /// Extracting properties from Json object.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetValueFromConfigFile(string propertyName)
        {
            string json = File.ReadAllText(GlobalVariables.ConfigFilePath);
            JObject jsonObj = JObject.Parse(json);

            return (string)jsonObj.GetValue(propertyName);
        }
    }
}