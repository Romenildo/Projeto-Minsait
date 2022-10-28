using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {

        private readonly IPassageiroRepositorio _passageiroRepositorio;

        public PassageiroController(IPassageiroRepositorio passageiroRepositorio)
        {
            _passageiroRepositorio = passageiroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Passageiro>>> BuscarTodosPassageiros()
        {
            List<Passageiro> resultado = await _passageiroRepositorio.BuscarTodosPassageiros();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passageiro>> BuscarPorID(int id)
        {
            Passageiro resultado = await _passageiroRepositorio.BuscarPorID(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Passageiro>> Cadastrar([FromBody] Passageiro passageiro) 
        {
            Passageiro resultado = await _passageiroRepositorio.Adicionar(passageiro);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passageiro>> Atualizar(int id, [FromBody] Passageiro passageiro)
        {
            passageiro.Id = id;
            Passageiro resultado = await _passageiroRepositorio.Atualizar(id, passageiro);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            bool resultado = await _passageiroRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
