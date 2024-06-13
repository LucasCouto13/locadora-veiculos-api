using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApi.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly DataContext _context;

        public VeiculoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> FindAll()
        {
            return await _context.Veiculos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> FindById(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            return veiculo == null ? NotFound() : veiculo;
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Save(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("FindById", new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Veiculo vehicle)
        {
            if (id.Equals(vehicle.Id))
            {
                return BadRequest();
            }
            _context.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo is null)
            {
                return NotFound();
            }
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
