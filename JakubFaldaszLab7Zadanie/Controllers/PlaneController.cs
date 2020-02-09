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
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        private IPlaneService planeService;

        /// <summary>
        /// Konstruktor inicjalizujacy planeService za pomoca dependency injection
        /// </summary>
        /// <param name="carService"></param>
        public PlaneController(IPlaneService carService)
        {
            this.planeService = carService;
        }

        /// <summary>
        /// Zwrócenie wszystkich samolotów z bazy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var planes = planeService.Get();

            return Ok(planes);
        }

        /// <summary>
        /// Dodanie samolotu do bazy
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Plane plane)
        {
            planeService.Post(plane);
            return Ok(plane.Id);
        }

        /// <summary>
        /// Aktualizacja samolotu o podanym nr id
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromBody] Plane plane, [FromRoute] int id)
        {
            if (id != plane.Id)
            {
                return Conflict("Nie można edytować id!");
            }
            else
            {
                var isUpdateSuccessful = planeService.Put(plane, id);
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
        /// Usunięcie z bazy samolotu o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var succedded = planeService.Delete(id);
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