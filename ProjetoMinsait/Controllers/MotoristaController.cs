using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {

        private readonly IMotoristaRepositorio _motoristaRepositorio;

        public MotoristaController(IMotoristaRepositorio motoristaRepositorio)
        {
            _motoristaRepositorio = motoristaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MotoristaDto>>> BuscarTodosMotoristas()
        {
            List<MotoristaDto> resultado = await _motoristaRepositorio.BuscarTodosMotoristas();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoristaDto>> BuscarPorID(Guid id)
        {
            MotoristaDto resultado = await _motoristaRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<MotoristaDto>> Cadastrar([FromBody] Motorista motorista) 
        {
            if (!ModelState.IsValid) { 
                return BadRequest();
            }
            MotoristaDto resultado = await _motoristaRepositorio.Adicionar(motorista);
            return Created($"v1/api/motorista/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MotoristaDto>> Atualizar(Guid id, [FromBody] Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            motorista.Id = id;
            MotoristaDto resultado = await _motoristaRepositorio.Atualizar(id, motorista);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Deletar(Guid id)
        {
            Boolean resultado = await _motoristaRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
