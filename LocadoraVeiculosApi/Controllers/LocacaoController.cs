using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public LocacaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> FindAll()
        {
            return await _context.Locacoes
                .Include(r => r.Veiculo)
                .Include(r => r.Cliente)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> FindById(int id)
        {
            var locacao = await _context.Locacoes
                .Include(r => r.Veiculo)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(r => r.Id == id);

            return locacao == null ? NotFound() : locacao;
        }

        [HttpPost]
        public async Task<ActionResult<Locacao>> Save(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction("FindById", new { id = locacao.Id }, locacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(locacao).State = EntityState.Modified;

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
            var reserva = await _context.Locacoes.FindAsync(id);
            if (reserva is null)
            {
                return NotFound();
            }
            _context.Locacoes.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
