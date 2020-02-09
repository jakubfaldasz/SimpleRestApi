using JakubFaldaszLab7Zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubFaldaszLab7Zadanie.Services
{
    public interface IPlaneService
    {
        List<Plane> Get();
        void Post(Plane plane);
        bool Put(Plane plane, int Id);
        bool Delete(int Id);
    }
}
