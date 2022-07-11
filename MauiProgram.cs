using Microsoft.AspNetCore.Components.WebView.Maui;
using FlatpurseBlazorApp.Data;
using FlatpurseDataAccessLibrary.Interfaces;
using FlatpurseDataAccessLibrary;
using FlatpurseDataAccessLibrary.Data;

namespace FlatpurseBlazorApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddTransient<IUserData, UserData>();

        return builder.Build();
	}
}
