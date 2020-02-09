using JakubFaldaszLab7Zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubFaldaszLab7Zadanie.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly ApiContext _apiContext;

        /// <summary>
        /// Konstruktor inicjalizujacy zmienna klasowa przechowujaca kontekst bazy danych
        /// </summary>
        /// <param name="apiContext"></param>
        public PlaneService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        /// <summary>
        /// Usunięcie z bazy podanego samolotu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            var plane = _apiContext.Set<Plane>().Find(Id);
            if (plane == null)
                return false;
            else
            {
                _apiContext.Set<Plane>().Remove(plane);
                return true;
            }

        }

        /// <summary>
        /// Zwrócenie z bazy listy wszystkich samolotów
        /// </summary>
        /// <returns></returns>
        public List<Plane> Get()
        {
            var plane = _apiContext.Set<Plane>().ToList();
            return plane;
        }

        /// <summary>
        /// Wstawienie do bazy nowego samolotu
        /// </summary>
        /// <param name="plane"></param>
        public void Post(Plane plane)
        {
            _apiContext.Set<Plane>().Add(plane);
            _apiContext.SaveChanges();
        }


        /// <summary>
        /// Aktualizacja samolotu o podanym id
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Put(Plane plane, int Id)
        {
            var planeToUpdate = _apiContext.Set<Plane>().Find(Id);
            if (planeToUpdate == null)
                return false;
            else
            {
                _apiContext.Entry(planeToUpdate).CurrentValues.SetValues(plane);
                _apiContext.SaveChanges();
                return true;
            }
        }
    }
}
