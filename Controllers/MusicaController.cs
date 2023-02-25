using Microsoft.EntityFrameworkCore;
using Musica.Data;
using Musica.Models;
using Microsoft.AspNetCore.Mvc;



namespace Musica.MusicaController
{
    [Controller]
    [Route("api/[controller]")]
    public class MusicaController : ControllerBase
    {
        private MusicaDBContext mdc;

        public MusicaController(MusicaDBContext context)
        {
            this.mdc = context;
        }

        [HttpPost]
        public async Task<ActionResult> adicionar([FromBody] MusicaModel m)
        {
            mdc.musicas?.Add(m);
            await mdc.SaveChangesAsync();
            return Created("Objeto Criado com sucesso", m);

        }

        [HttpGet]
        public async Task<ActionResult> listar()
        {
            var dados = await mdc.musicas!.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("{id}")]
        public MusicaModel filtrar([FromRoute] int id)
        {
            MusicaModel ?m = mdc.musicas?.Find(id);
            return m!;
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> editar([FromRoute] int id, [FromBody] MusicaModel m)
        {
            var musica = mdc.musicas?.SingleOrDefault(x => x.Id.Equals(id));
            
                
            musica!.NomeArtista = m.NomeArtista;
            musica.NomeMusica = m.NomeMusica;
            musica.Data = m.Data;
              

            mdc.musicas?.Update(musica);
            await mdc.SaveChangesAsync();
            return Ok(musica);
            
             
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> remover([FromRoute] int id)
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