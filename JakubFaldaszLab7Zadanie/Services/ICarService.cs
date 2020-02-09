using JakubFaldaszLab7Zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubFaldaszLab7Zadanie.Services
{
    public interface ICarService
    {
        List<Car> Get();
        void Post(Car car);
        bool Put(Car car, int Id);
        bool Delete(int Id);
    }
}
