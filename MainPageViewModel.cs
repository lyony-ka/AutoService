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
                new ServiceGroup("��", new[]
                {
                    new Service { Name = "������ �����", Price = 1500 },
                    new Service { Name = "������ ���������� �������", Price = 500 },
                    new Service { Name = "������ ������ ���������", Price = 800 },
                }),
                new ServiceGroup("�����������", new[]
                {
                    new Service { Name = "����������� ���������", Price = 2000 },
                    new Service { Name = "����������� ������� �����", Price = 1500 },
                    new Service { Name = "����������� �������������������", Price = 1800 },
                }),
                new ServiceGroup("������ ���������", new[]
                {
                    new Service { Name = "����������� ������ ���������", Price = 30000 },
                    new Service { Name = "������ ���", Price = 8000 },
                    new Service { Name = "������ ��������� �������", Price = 10000 },
                }),
                new ServiceGroup("������ ������� �����", new[]
                {
                    new Service { Name = "������ �������������", Price = 4000 },
                    new Service { Name = "������ ��������� �����������", Price = 3000 },
                    new Service { Name = "������ ������� ����", Price = 2500 },
                }),
                new ServiceGroup("�������������� ������", new[]
                {
                    new Service { Name = "����������", Price = 1200 },
                    new Service { Name = "������������ �����", Price = 1000 },
                    new Service { Name = "������ ��������� �������", Price = 1200 },
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
