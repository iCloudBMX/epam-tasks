using System.Reflection;
using Provider;

public class Program
{
    public static void Main()
    {
        Assembly assembly = typeof(ConfigurationProvider).Assembly;

        Type fileConfigurationProviderType =
            assembly.GetType("Provider.FileConfigurationProvider");

        dynamic fileManager = Activator.CreateInstance(
            type: fileConfigurationProviderType,            
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { "Value for custom configuration" },
            culture: null);
        
        Type configurationManagerProviderType =
            assembly.GetType("Provider.ConfigurationManagerConfigurationProvider");

        dynamic configurationManager = Activator.CreateInstance(
            type: configurationManagerProviderType,            
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { new TimeSpan(hours: 1, minutes: 0, seconds: 0) },
            culture: null);
        
        var configurationBaseType = new ConfigurationComponentBase(
            fileConfigurationProvider: fileManager,
            configurationManagerConfigurationProvider: configurationManager);
        
        try
        {
            configurationBaseType.SaveAppSettings();
            configurationBaseType.ReadAppSettings();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}