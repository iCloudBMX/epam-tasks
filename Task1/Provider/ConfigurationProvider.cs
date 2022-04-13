using System.Configuration;
using System.Reflection;

namespace Provider
{
    public abstract class ConfigurationProvider
    {
        private const int NOITEM = 0;
        public object Value { get; set; }

        public ConfigurationProvider() { }

        public ConfigurationProvider(object value)
        {
            Value = value;
        }

        public virtual void SaveSettings(PropertyInfo propertyInfo, object value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(
                    userLevel: ConfigurationUserLevel.None);
            
            string propertyName = propertyInfo.Name;

            if(configuration.AppSettings.Settings[propertyName] == null)
                configuration.AppSettings.Settings.Add(
                    key: propertyName, 
                    value: value.ToString());
            else
                configuration.AppSettings
                    .Settings[propertyName].Value = value.ToString();

            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(
                sectionName: configuration.AppSettings.SectionInformation.Name);
        }

        public virtual void LoadSettings(PropertyInfo propertyInfo)
        {
            var appSettings = ConfigurationManager.AppSettings;

            if(appSettings.Count == NOITEM)
                Console.WriteLine("No settings found");
            
            else
                Console.WriteLine(
                    $"Key: {propertyInfo.Name}\n"+
                    $"Value: {appSettings[propertyInfo.Name]}");
        }
    }
}