using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Models;
using LocadoraVeiculosApi.Views;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> FindAll()
        {
            return await _clienteService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> FindById(int id)
        {
            return await _clienteService.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Save(Cliente cliente)
        {
            return await _clienteService.Save(cliente);
        }

        [HttpPut("{id}")]
        public async Task Edit(int id, Cliente cliente)
        {
            await _clienteService.Edit(id, cliente);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _clienteService.Delete(id);
        }
    }
}
