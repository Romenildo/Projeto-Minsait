using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {

        private readonly IPassagemRepositorio _passagemRepositorio;

        public PassagemController(IPassagemRepositorio passagemRepositorio)
        {
            _passagemRepositorio = passagemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Passagem>>> BuscarTodosPassagems()
        {
            List<Passagem> resultado = await _passagemRepositorio.BuscarTodasPassagens();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> BuscarPorID(int id)
        {
            Passagem resultado = await _passagemRepositorio.BuscarPorID(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Passagem>> Cadastrar([FromBody] Passagem passagem) 
        {
            Passagem resultado = await _passagemRepositorio.Adicionar(passagem);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passagem>> Atualizar(int id, [FromBody] Passagem passagem)
        {
            passagem.Id = id;
            Passagem resultado = await _passagemRepositorio.Atualizar(id, passagem);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            bool resultado = await _passagemRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
