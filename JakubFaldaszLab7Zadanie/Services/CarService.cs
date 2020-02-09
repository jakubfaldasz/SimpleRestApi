using JakubFaldaszLab7Zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubFaldaszLab7Zadanie.Services
{
    public class CarService : ICarService
    {
        private readonly ApiContext _apiContext;

        /// <summary>
        /// Konstruktor inicjalizujacy zmienna klasowa przechowujaca kontekst bazy danych
        /// </summary>
        /// <param name="apiContext"></param>
        public CarService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        /// <summary>
        /// Usunięcie z bazy podanego samochodu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            var car = _apiContext.Set<Car>().Find(Id);
            if (car == null)
                return false;
            else
            {
                _apiContext.Set<Car>().Remove(car);
                return true;
            }

        }

        /// <summary>
        /// Zwrócenie z bazy listy wszystkich samochodów
        /// </summary>
        /// <returns></returns>
        public List<Car> Get()
        {
            var cars = _apiContext.Set<Car>().ToList();
            return cars;
        }

        /// <summary>
        /// Wstawienie do bazy nowego samochodu
        /// </summary>
        /// <param name="car"></param>
        public void Post(Car car)
        {
            _apiContext.Set<Car>().Add(car);
            _apiContext.SaveChanges();
        }

        /// <summary>
        /// Aktualizacja samochodu o podanym id
        /// </summary>
        /// <param name="car"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Put(Car car, int Id)
        {
            var carToUpdate = _apiContext.Set<Car>().Find(Id);
            if (carToUpdate == null)
                return false;
            else
            {
                _apiContext.Entry(car).CurrentValues.SetValues(car);
                _apiContext.SaveChanges();
                return true;
            }
        }
    }
}
