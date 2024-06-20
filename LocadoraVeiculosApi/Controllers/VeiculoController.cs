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
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> FindAll()
        {
            return await _veiculoService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> FindById(int id)
        {
            return await _veiculoService.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Save(Veiculo veiculo)
        {
            return await _veiculoService.Save(veiculo);
        }

        [HttpPut("{id}")]
        public async Task Edit(int id, Veiculo vehicle)
        {
            await _veiculoService.Edit(id, vehicle);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _veiculoService.Delete(id);
        }
    }
}
