using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Exceptions;
using LocadoraVeiculosApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LocadoraVeiculosApi.Views
{
    public class VeiculoService
    {
        private readonly DataContext _context;

        public VeiculoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Veiculo>>> FindAll()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<ActionResult<Veiculo>> FindById(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo is null)
            {
                throw NotFound(id);
            }
            return veiculo;
        }

        public async Task<Veiculo> Save(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;
        }

        public async Task Edit(int id, Veiculo vehicle)
        {
            if (id.Equals(vehicle.Id))
            {
                throw NotFound(id);
            }
            _context.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new BadRequestException($"Falha ao editar veículo.");
            }
        }

        public async Task Delete(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo is null)
            {
                throw NotFound(id);
            }
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        private BadRequestException NotFound(int id)
        {
            return new BadRequestException($"Nenhum Veículo com esse ID({id}) foi encontrado.");
        }
    }
}
