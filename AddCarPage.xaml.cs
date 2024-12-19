using AutoService;

namespace AutoService
{
    public partial class AddCarPage : ContentPage
    {
        private readonly CarDatabase _carDatabase;

        public AddCarPage(CarDatabase carDatabase)
        {
            InitializeComponent();
            _carDatabase = carDatabase;
        }

        private async void OnAddCarClicked(object sender, EventArgs e)
        {
            var newCar = new Car
            {
                Make = MakeEntry.Text,
                Model = ModelEntry.Text,
                Year = int.TryParse(YearEntry.Text, out var year) ? year : 0,
                Color = ColorEntry.Text,
                LicensePlate = LicensePlateEntry.Text
            };

            if (string.IsNullOrEmpty(newCar.Make) || string.IsNullOrEmpty(newCar.Model) || newCar.Year == 0 || string.IsNullOrEmpty(newCar.Color) || string.IsNullOrEmpty(newCar.LicensePlate))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                return;
            }

            await _carDatabase.SaveCarAsync(newCar);
            await Navigation.PopAsync();  // Возвращаемся на предыдущую страницу (GaragePage)
        }
    }
}
