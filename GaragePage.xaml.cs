using AutoService;
using System.Collections.ObjectModel;

namespace AutoService
{
    public partial class GaragePage : ContentPage
    {
        private readonly CarDatabase _carDatabase;

        public ObservableCollection<Car> Cars { get; set; }
        // Конструктор без параметров (для XAML)
        public GaragePage() : this(new CarDatabase())
        {
        }
        public GaragePage(CarDatabase carDatabase)
        {
            InitializeComponent();
            _carDatabase = carDatabase;
            Cars = new ObservableCollection<Car>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var cars = await _carDatabase.GetCarsAsync();
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }

        private async void OnAddCarPageClicked(object sender, EventArgs e)
        {
            // Переход на страницу добавления автомобиля
            await Navigation.PushAsync(new AddCarPage(_carDatabase));
        }

        private async void OnDeleteCarClicked(object sender, EventArgs e)
        {
            // Получаем объект автомобиля, переданный как CommandParameter
            if (sender is Button button && button.CommandParameter is Car car)
            {
                await _carDatabase.DeleteCarAsync(car);
                Cars.Remove(car);
            }
        }
    }
}
