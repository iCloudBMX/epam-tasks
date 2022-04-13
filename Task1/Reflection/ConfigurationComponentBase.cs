using Provider;

public class ConfigurationComponentBase
{
    [ConfigurationItemAttribute(SettingName = "1_Setting", 
        ProviderType = "FileConfigurationProvider")]
    public FileConfigurationProvider FileConfigurationProvider { get; set; }

    [ConfigurationItemAttribute(SettingName = "2_Setting", 
        ProviderType = "ConfigurationManagerConfigurationProvider")]
    public ConfigurationManagerConfigurationProvider ConfigurationManagerConfigurationProvider { get; set; }

    public ConfigurationComponentBase(
        FileConfigurationProvider fileConfigurationProvider,
        ConfigurationManagerConfigurationProvider configurationManagerConfigurationProvider)
    {
        if(fileConfigurationProvider == null || 
            configurationManagerConfigurationProvider == null)
        {
            throw new ArgumentNullException("Property cannot be null");
        }
        else
        {
            this.FileConfigurationProvider =
                fileConfigurationProvider;
                
            this.ConfigurationManagerConfigurationProvider =
                configurationManagerConfigurationProvider;
        }        
    }

    public void SaveAppSettings()
    {
        var properties = this.GetType().GetProperties();

        foreach (var property in properties)
        {
            var configurationItemAttributes =
                property.GetCustomAttributes(
                    attributeType: typeof(ConfigurationItemAttribute), 
                    inherit: false);

            foreach (var configurationItemAttribute in configurationItemAttributes)
            {
                var configurationItemAttributeInstance =
                    (ConfigurationItemAttribute)configurationItemAttribute;

                var providerType = configurationItemAttributeInstance.ProviderType;

                if (providerType == "FileConfigurationProvider")
                {
                    if(this.FileConfigurationProvider is not null)
                        this.FileConfigurationProvider.SaveSettings(
                            propertyInfo: property,
                            value: FileConfigurationProvider.Value);                    
                }
                else if (providerType == "ConfigurationManagerConfigurationProvider")
                {
                    if(this.ConfigurationManagerConfigurationProvider is not null)
                        this.ConfigurationManagerConfigurationProvider.SaveSettings(
                            propertyInfo: property,
                            value: ConfigurationManagerConfigurationProvider.Value);   
                }
            }
        }
    }

    public void ReadAppSettings()
    {
        var properties = this.GetType().GetProperties();

        foreach (var property in properties)
        {
            var configurationItemAttributes =
                property.GetCustomAttributes(
                    attributeType: typeof(ConfigurationItemAttribute), 
                    inherit: false);

            foreach (var configurationItemAttribute in configurationItemAttributes)
            {
                var configurationItemAttributeInstance =
                    (ConfigurationItemAttribute)configurationItemAttribute;

                var providerType = configurationItemAttributeInstance.ProviderType;

                if (providerType == "FileConfigurationProvider")
                {
                    if(this.FileConfigurationProvider is not null)
                        this.FileConfigurationProvider.LoadSettings(
                            propertyInfo: property);                    
                }
                else if (providerType == "ConfigurationManagerConfigurationProvider")
                {
                    if(this.ConfigurationManagerConfigurationProvider is not null)
                        this.ConfigurationManagerConfigurationProvider.LoadSettings(
                            propertyInfo: property);   
                }
            }
        }
    }
}