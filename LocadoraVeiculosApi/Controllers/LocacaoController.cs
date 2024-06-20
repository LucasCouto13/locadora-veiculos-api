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
    public class LocacaoController : ControllerBase
    {
        private readonly LocacaoService _locacaoService;

        public LocacaoController(LocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> FindAll()
        {
            return await _locacaoService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> FindById(int id)
        {
            return await _locacaoService.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Locacao>> Save(Locacao locacao)
        {
            return await _locacaoService.Save(locacao);
        }

        [HttpPut("{id}")]
        public async Task Edit(int id, Locacao locacao)
        {
            await _locacaoService.Edit(id, locacao);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _locacaoService.Delete(id);
        }
    }
}
