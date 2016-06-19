# Tweak

Tweak is a library that helps you to create strongly typed settings read from different sources e.g. appsettings, json etc.

### Key Features
Some key features of Tweak are,

1. Read settings from a settings source. Currently supported sources are AppSettings (AppSettingsReader) and Json (JsonSettingsReader).
2. Write settings to a settings source.
3. Create custom setting readers and writers.
4. Can easily register settings using any Ioc of your choice

### Installing Tweak - [nuget](https://www.nuget.org/packages/Tweak/)

```
PM> Install-Package Tweak
```

### Release Notes
Release notes can be found [here](https://github.com/oopanuga/tweak/blob/master/RELEASE-NOTES.txt)

### Using Tweak

##### Reading from an App Settings source

Create your settings class, inherit from SettingsBase and specify the AppSettingsReader
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

Define settings in appSettings section of config. Your setting key could be a PropertyName or ClassName.PropertyName or Namespace.ClassName.PropertyName
```xml
<appSettings>
	<add key="Tweak.Examples.ApiSettings.ApiKey" value="45017dc5-bd7c-47fd-9495-06953e329db0" />
	<add key="Tweak.Examples.ApiSettings.Endpoint" value="http://api.appsettingsexample.test" />
</appSettings>
```

Read settings from config. By default settings are automatically read upon instantiation of a settings class.
```c#
var apiSettings = new ApiSettings();
var apiKey = apiSettings.ApiKey;
```

Prevent settings from being automatically read upon instantiation of settings class. This applies to any SettingsReader implementation.
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

##### Reading from a Json source

Create your settings class, inherit from SettingsBase and specify the JsonSettingsReader
```c#
public interface IApiSettings
{
	string ApiKey { get; set; }
	string Endpoint { get; set; }
}
	
public class ApiSettings : SettingsBase<JsonSettingsReader>, IApiSettings
{
	public string ApiKey { get; set; }
	public string Endpoint { get; set; }
}
```

Define settings in json file. ApiSettings below represents the name of the class. You could also include the class Namespace 
```json
{
    "ApiSettings": {
        "ApiKey": "97e4406d-7bbc-44a9-9895-c68ef498a978",
        "Endpoint": "http://api.jsonexample.test"
    }
}
```

Add json file to filestore. Please note that ApiSettings.json is the file name in this case
```c#
JsonSettingsFileManager.AddFile("ApiSettings.json");
```

Read settings from json file
```c#
var apiSettings = new ApiSettings();
var apiKey = apiSettings.ApiKey;
```

##### Writing to any settings source

There are currently no built in SettingsWriter, however implementing one is quite easy.

```c#
public class CustomSettingsWriter : ISettingsWriter
{
	public void Write(IDictionary<string, string> settings)
	{
		//write to settings source here
	}
}
```

Define writable settings (this assumes that you've already implemented a CustomSettingsReader)
```c#
public interface IApiSettings
{
	string ApiKey { get; set; }
	string Endpoint { get; set; }
}
	
public class ApiSettings : SettingsBase<CustomSettingsReader, CustomSettingsWriter>, IApiSettings
{
	public string ApiKey { get; set; }
	public string Endpoint { get; set; }
}
```

Write to settings source
```c#
var apiSettings = new ApiSettings();
apiSettings.ApiKey = "5611f7e8-d0cd-44c6-ad66-9929b397009f";
apiSettings.Write();
```


See examples in solution [here](https://github.com/oopanuga/Tweak/tree/master/Tweak.Examples)

### License

Tweak is released under the MIT license.
