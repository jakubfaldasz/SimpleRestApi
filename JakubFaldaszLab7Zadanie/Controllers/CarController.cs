using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JakubFaldaszLab7Zadanie.Models;
using JakubFaldaszLab7Zadanie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JakubFaldaszLab7Zadanie.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarService carService;

        /// <summary>
        /// Konstruktor inicjalizujacy planeService za pomoca dependency injection
        /// </summary>
        /// <param name="carService"></param>
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        /// <summary>
        /// Zwrócenie wszystkich samochodów z bazy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var cars = carService.Get();

            return Ok(cars);
        }

        /// <summary>
        /// Dodanie samochodu do bazy
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            carService.Post(car);
            return Ok(car.Id);
        }

        /// <summary>
        /// Aktualizacja samochodu o podanym nr id
        /// </summary>
        /// <param name="car"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromBody] Car car, [FromRoute] int id)
        {
            if (id != car.Id)
            {
                return Conflict("Nie można edytować id!");
            }
            else
            {
                var isUpdateSuccessful = carService.Put(car, id);
                if (isUpdateSuccessful)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Usunięcie z bazy samochodu o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var succedded = carService.Delete(id);
            if (succedded)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}