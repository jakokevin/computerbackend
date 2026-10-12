using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webshop.Models;
using webshop.Models.DTOs;

namespace webshop.Controllers
{
    [Route("osystems")]
    [ApiController]
    public class OsystemController : ControllerBase
    {

        public ComputerShopDbContext _context = new();

        [HttpPost("addOsystem")]

        public object AddNewOsystem([FromBody]AddNewOsystemDTO addNewOsystemDTO)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = addNewOsystemDTO.Name,
                Version = addNewOsystemDTO.Version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now,


            };


            if(osystem!=null)
            {
                _context.Osystems.Add(osystem);
                _context.SaveChanges();

                return StatusCode(201, new { message = "sikeres felvetel", result = osystem });
            }
            return StatusCode(400, new { message = "sikertelen" +
                " felvetel", result = osystem });
        }


        [HttpGet("allOsystem")]
        public object GetAllOsystem()
        {
            var osystems = _context.Osystems.ToList();
            Exception e = new();

            if(osystems.Count > 0)
            {
                return StatusCode(200, new { message = "sikeres lekerdezes", result = osystems });
            }
            else if(osystems.Count < 1)
            {
                return StatusCode(200, new { message = "ures a tabla", result = osystems });
            }
            else
            {
                return StatusCode(200, new { message = "hiba a lekerdezesben", result = osystems });
            }
        }

    }
}
