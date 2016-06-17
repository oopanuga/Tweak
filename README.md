# Tweak

Tweak is a library that helps you to create strongly typed settings read from different sources e.g. appsettings, json etc.

### Key Features
Some key features of Tweak are,

1. Read settings from a settings source. Currently supported sources are AppSettings (AppSettingsReader) and Json (JsonSettingsReader).
2. Write settings to a settings source.
3. Create custom setting readers and writers.
4. Can easily register settings using any IOC of your choice

### Installing Tweak - [nuget](https://www.nuget.org/packages/Tweak/)

```
PM> Install-Package CommonProvider
```

### Release Notes
Release notes can be found [here](https://github.com/oopanuga/tweak/blob/master/RELEASE-NOTES.txt)

### Using Tweak 

Create your settings class and inherit from SettingsBase<AppSettingsReader>
```c#
public interface IApiSettings
{
	string ApiKey { get; set; }
	string Endpoint { get; set; }
}
	
public class ApiSettings : SettingsBase<AppSettingsReader>, IApiSettings
{
	public string ApiKey { get; set; }
	public string Endpoint { get; set; }
}
```

Define settings in config. Your setting key could be a PropertyName or ClassName.PropertyName or Namespace.ClassName.PropertyName
```xml
<appSettings>
	<add key="Tweak.Examples.ApiSettings.ApiKey" value="45017dc5-bd7c-47fd-9495-06953e329db0" />
	<add key="Tweak.Examples.ApiSettings.Endpoint" value="http://api.appsettingsexample.test" />
</appSettings>
```

Read settings from config file. Setting are automatically read by default upon instantiation of the settings class.
```c#
var apiSettings = new ApiSettings();
var apiKey = apiSettings.ApiKey;
```

Prevent settings from being automatically read upon instantiation of settings class.
```c#
public class ApiSettings : SettingsBase<AppSettingsReader>, IApiSettings
{
	const bool autoReadSettings = false;
	public ApiSettings():base(autoReadSettings)
	{
	}
	public string ApiKey { get; set; }
	public string Endpoint { get; set; }
}

var apiSettings = new ApiSettings();
apiSettings.Read();
var apiKey = apiSettings.ApiKey;
```

See more examples [here](https://github.com/oopanuga/Tweak/tree/master/Tweak.Examples)

### License

Tweak is released under the MIT license.
