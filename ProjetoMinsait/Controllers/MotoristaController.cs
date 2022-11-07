using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
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
        public async Task<ActionResult<List<Motorista>>> BuscarTodosMotoristas()
        {
            List<Motorista> resultado = await _motoristaRepositorio.BuscarTodosMotoristas();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> BuscarPorID(Guid id)
        {
            Motorista resultado = await _motoristaRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Motorista>> Cadastrar([FromBody] Motorista motorista) 
        {
            if (!ModelState.IsValid) { 
                return BadRequest();
            }
            Motorista resultado = await _motoristaRepositorio.Adicionar(motorista);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Motorista>> Atualizar(Guid id, [FromBody] Motorista motorista)
        {
            motorista.Id = id;
            Motorista resultado = await _motoristaRepositorio.Atualizar(id, motorista);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(Guid id)
        {
            bool resultado = await _motoristaRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
