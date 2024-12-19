using Microsoft.Maui.Controls;
using AutoService;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace AutoService
{
    public partial class MainPage : ContentPage
    {
        private readonly CarDatabase _carDatabase;
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar { get; set; }
        public string SelectedService { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            _carDatabase = new CarDatabase();
            Cars = new ObservableCollection<Car>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadCarsAsync();
        }

        private async Task LoadCarsAsync()
        {
            var carsFromDb = await _carDatabase.GetCarsAsync();
            Cars.Clear();
            foreach (var car in carsFromDb)
            {
                Cars.Add(car);
            }
        }

        // Обработчик выбора услуги
        private void OnServiceClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                SelectedService = button.Text; // Сохраняем выбранную услугу
            }
        }

        // Обработчик отправки email
        private async void OnSendEmailClicked(object sender, EventArgs e)
        {
            if (SelectedCar != null && !string.IsNullOrEmpty(SelectedService))
            {
                // Передаем информацию об автомобиле и услуге в email
                await SendEmailAsync("fakubich23RUSgmail.com@yandex.ru", "Запрос на услугу",
                    $"Выбрана услуга: {SelectedService}\nАвтомобиль: {SelectedCar.Make} {SelectedCar.Model} {SelectedCar.Year} {SelectedCar.Color} {SelectedCar.LicensePlate}");
            }
            else
            {
                await DisplayAlert("Ошибка", "Выберите автомобиль и услугу", "OK");
            }
        }

        // Метод для отправки email
        private async Task SendEmailAsync(string to, string subject, string body)
        {
            // Логика для отправки email
            await DisplayAlert("Отправка Email", $"Email отправлен на {to}\nТема: {subject}\nТело сообщения: {body}", "OK");
        }
    }

}
