using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
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
        public async Task<ActionResult<List<CobradorDto>>> BuscarTodosCobradors()
        {
            List<CobradorDto> resultado = await _cobradorRepositorio.BuscarTodosCobradores();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CobradorDto>> BuscarPorID(Guid id)
        {
            CobradorDto resultado = await _cobradorRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<CobradorDto>> Cadastrar([FromBody] Cobrador cobrador) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CobradorDto resultado = await _cobradorRepositorio.Adicionar(cobrador);
            return Created($"v1/api/cobrador/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CobradorDto>> Atualizar(Guid id, [FromBody] Cobrador cobrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            cobrador.Id = id;
            CobradorDto resultado = await _cobradorRepositorio.Atualizar(id, cobrador);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Deletar(Guid id)
        {
            Boolean resultado = await _cobradorRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
