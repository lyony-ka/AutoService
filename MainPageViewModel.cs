using System.Collections.ObjectModel;

namespace AutoService
{
    public class MainPageViewModel
    {
        public ObservableCollection<ServiceGroup> GroupedServices { get; set; }

        public MainPageViewModel()
        {
            GroupedServices = new ObservableCollection<ServiceGroup>
            {
                new ServiceGroup("ТО", new[]
                {
                    new Service { Name = "Замена масла", Price = 1500 },
                    new Service { Name = "Замена воздушного фильтра", Price = 500 },
                    new Service { Name = "Замена свечей зажигания", Price = 800 },
                }),
                new ServiceGroup("Диагностика", new[]
                {
                    new Service { Name = "Диагностика двигателя", Price = 2000 },
                    new Service { Name = "Диагностика ходовой части", Price = 1500 },
                    new Service { Name = "Диагностика электрооборудования", Price = 1800 },
                }),
                new ServiceGroup("Ремонт двигателя", new[]
                {
                    new Service { Name = "Капитальный ремонт двигателя", Price = 30000 },
                    new Service { Name = "Ремонт ГРМ", Price = 8000 },
                    new Service { Name = "Ремонт топливной системы", Price = 10000 },
                }),
                new ServiceGroup("Ремонт ходовой части", new[]
                {
                    new Service { Name = "Замена амортизаторов", Price = 4000 },
                    new Service { Name = "Замена ступичных подшипников", Price = 3000 },
                    new Service { Name = "Замена шаровых опор", Price = 2500 },
                }),
                new ServiceGroup("Дополнительные услуги", new[]
                {
                    new Service { Name = "Шиномонтаж", Price = 1200 },
                    new Service { Name = "Балансировка колес", Price = 1000 },
                    new Service { Name = "Замена тормозных колодок", Price = 1200 },
                }),
            };
        }
    }

    public class ServiceGroup : ObservableCollection<Service>
    {
        public string Name { get; private set; }

        public ServiceGroup(string name, IEnumerable<Service> services) : base(services)
        {
            Name = name;
        }
    }

    public class Service
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
