using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Exceptions;
using LocadoraVeiculosApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LocadoraVeiculosApi.Views
{
    public class LocacaoService
    {
        private readonly DataContext _context;

        public LocacaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Locacao>>> FindAll()
        {
            return await _context.Locacoes
                .Include(r => r.Veiculo)
                .Include(r => r.Cliente)    
                .ToListAsync();
        }

        public async Task<ActionResult<Locacao>> FindById(int id)
        {
            var locacao = await _context.Locacoes
                .Include(r => r.Veiculo)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (locacao is null)
            {
                throw NotFound(id);
            }
            return locacao;
        }

        public async Task<ActionResult<Locacao>> Save(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();
            return locacao;
        }

        public async Task Edit(int id, Locacao locacao)
        {
            if (id != locacao.Id)
            {
                throw NotFound(id);
            }

            _context.Entry(locacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new BadRequestException($"Falha ao editar cliente.");
            }
        }

        public async Task Delete(int id)
        {
            var reserva = await _context.Locacoes.FindAsync(id);
            if (reserva is null)
            {
                throw NotFound(id);
            }
            _context.Locacoes.Remove(reserva);
            await _context.SaveChangesAsync();
        }

        private BadRequestException NotFound(int id)
        {
            throw new BadRequestException($"Nenhuma locacao com esse ID({id}) foi encontrado.");
        }
    }
}
