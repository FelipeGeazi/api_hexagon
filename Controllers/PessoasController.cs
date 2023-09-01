using Microsoft.AspNetCore.Mvc;
using ApiHexagon.Services;

namespace ApiHexagon.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoasController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _pessoaService.GetPessoasAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _pessoaService.GetPessoaAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            var id = await _pessoaService.CreatePessoaAsync(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new { id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            try
            {
                await _pessoaService.UpdatePessoaAsync(id, pessoa);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            if (!_pessoaService.PessoaExists(id))
            {
                return NotFound();
            }

            await _pessoaService.DeletePessoaAsync(id);
            return NoContent();
        }
    }
}
