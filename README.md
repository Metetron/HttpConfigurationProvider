# HttpConfigurationProvider

Configuration of .Net Project became very easy to use with the addition of Microsoft.Extensions.Configuration.
Unfortunately Microsoft does not provide a default way of loading configuration from a database or similar services.
So I thought to provide a way to do it.

The HttpConfigurationProvider can load settings from an HTTP Endpoint.
The Endpoint just needs to return the settings as a simple JSON- object.
Different level of settings can be expressed using colons in the name of the setting.

The ConfigurationServer is a web application that implements the necessary endpoint for retreiving settings and it also provides
a UI to configure settings.

This project is currently a work in progress so do not use it in production.
