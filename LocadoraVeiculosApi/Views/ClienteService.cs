using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Exceptions;
using LocadoraVeiculosApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LocadoraVeiculosApi.Views
{
    public class ClienteService
    {
        private readonly DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Cliente>>> FindAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> FindById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null) 
            {
                throw NotFound(id);
            }
            return cliente;
        }

        public async Task<Cliente> Save(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Edit(int id, Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
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
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw NotFound(id);
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        private BadRequestException NotFound(int id)
        {
            return new BadRequestException($"Nenhum Cliente com esse ID({id}) foi encontrado.");
        }
    }
}
