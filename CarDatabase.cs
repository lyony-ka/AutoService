using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoService;

namespace AutoService
{
    public class CarDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public CarDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cars.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Car>().Wait();
        }

        public Task<List<Car>> GetCarsAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }

        public Task<int> SaveCarAsync(Car car)
        {
            if (car.Id != 0)
            {
                return _database.UpdateAsync(car);
            }
            else
            {
                return _database.InsertAsync(car);
            }
        }

        public Task<int> DeleteCarAsync(Car car)
        {
            return _database.DeleteAsync(car);
        }
    }
}
