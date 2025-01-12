using LAB5_MAUI.ViewModels;
using LAB5_MAUIDATA.Interfaces;
using LAB5_MAUIDATA.Services;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace LAB5_MAUI
{
    public static class MauiProgram

    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddScoped<IBankApiClient, BankApiClient>();
            builder.Services.AddScoped<IDataRepository, ApiDataRepository>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
