using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CobradorController : ControllerBase
    {

        private readonly ICobradorRepositorio _cobradorRepositorio;

        public CobradorController(ICobradorRepositorio cobradorRepositorio)
        {
            _cobradorRepositorio = cobradorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cobrador>>> BuscarTodosCobradors()
        {
            List<Cobrador> resultado = await _cobradorRepositorio.BuscarTodosCobradores();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cobrador>> BuscarPorID(Guid id)
        {
            Cobrador resultado = await _cobradorRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Cobrador>> Cadastrar([FromBody] Cobrador cobrador) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Cobrador resultado = await _cobradorRepositorio.Adicionar(cobrador);
            return Created($"v1/api/cobrador/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cobrador>> Atualizar(Guid id, [FromBody] Cobrador cobrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            cobrador.Id = id;
            Cobrador resultado = await _cobradorRepositorio.Atualizar(id, cobrador);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(Guid id)
        {
            bool resultado = await _cobradorRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
