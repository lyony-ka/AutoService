using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Threading.Tasks;
namespace AutoService;


public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    private async void OnOpenMapClicked(object sender, EventArgs e)
    {
        var location = new Location(55.741525, 37.799031); // Координаты автосервиса
        var options = new MapLaunchOptions
        {
            Name = "Автосервис в Балашихе",
            NavigationMode = NavigationMode.Driving
        };

        try
        {
            await Map.Default.OpenAsync(location, options);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", "Невозможно открыть приложение карты.", "ОК");
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
