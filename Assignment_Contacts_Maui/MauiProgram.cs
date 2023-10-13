using Assignment_Contacts_Maui.Mvvm.ViewModels;
using Assignment_Contacts_Maui.Mvvm.Views;
using Microsoft.Extensions.Logging;

namespace Assignment_Contacts_Maui
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<AddPage>();

            builder.Services.AddSingleton<DetailViewModel>();
            builder.Services.AddSingleton<DetailPage>();


            return builder.Build();
        }
    }
}