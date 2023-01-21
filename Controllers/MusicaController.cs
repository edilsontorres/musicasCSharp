using Microsoft.EntityFrameworkCore;
using Musica.Data;
using Musica.Models;
using Microsoft.AspNetCore.Mvc;



namespace Musica.MusicaController
{
    [Controller]
    [Route("[controller]")]
    public class MusicaController : ControllerBase
    {
        private MusicaDBContext mdc;

        public MusicaController(MusicaDBContext context)
        {
            this.mdc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> adicionar([FromBody] MusicaModel m)
        {
            mdc.musicas?.Add(m);
            await mdc.SaveChangesAsync();
            return Created("Objeto Criado com sucesso", m);

        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await mdc.musicas!.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{id}")]
        public MusicaModel filtrar(int id)
        {
            MusicaModel ?m = mdc.musicas?.Find(id);
            return m!;
           
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] MusicaModel m)
        {
            
            mdc.musicas?.Update(m);
            await mdc.SaveChangesAsync();
            return Ok(m);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> remover(int id)
        {
            MusicaModel m = filtrar(id);

            if(m != null)
            {
                mdc.musicas?.Remove(m);
                await mdc.SaveChangesAsync();
                return Ok($"Música deletada com sucesso");
            }
                
            return NotFound("Não foi possível encontrar essa música"); 

        }
    }
}