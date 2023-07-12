using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FChallengeWirtrack.Models;
using Microsoft.EntityFrameworkCore;

namespace FChallengeWirtrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public VehiculoController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {

                var listVehiculos = await _context.Vehiculo.ToListAsync();
                return Ok(listVehiculos);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try {
                var vehiculo = await _context.Vehiculo.FindAsync(Id);
                if (vehiculo == null)
                {
                    return NotFound();
                }
                _context.Vehiculo.Remove(vehiculo);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
              
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vehiculo vehiculo)
        {
            try {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id= vehiculo.Id}, vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Vehiculo vehiculo)
        {
            try
            {

                if (id != vehiculo.Id)
                {
                    return BadRequest();
                }

                var vehiculoItem = await _context.Vehiculo.FindAsync(id);

                if (vehiculoItem == null)
                {
                    return NotFound();
                }

                vehiculoItem.Patente = vehiculo.Patente;
                vehiculoItem.Tipo = vehiculo.Tipo;
                vehiculoItem.Marca = vehiculo.Marca;

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
