using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
               
        private readonly DataContext _context;

        public AnimeController(DataContext Context)
        {
            _context = Context;
        }
  

        [HttpGet]
        public async Task<ActionResult<List<Anime>>> Get()
        {
            return Ok(await _context.Animes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> Get(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
                return BadRequest("Anime não encontrado.");
            return Ok(anime);
        }

        [HttpPost]
        public async Task<ActionResult<List<Anime>>> AdicionarAnime(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();  
            
            return Ok(await _context.Animes.ToListAsync());  
        }

        [HttpPut]
        public async Task<ActionResult<List<Anime>>> AtualizarAnime(Anime requisicao)
        {
            var dbAnime = await _context.Animes.FindAsync(requisicao.Id);
            if (dbAnime == null)
                return NotFound();

            dbAnime.Titulo = requisicao.Titulo;
            dbAnime.Genero = requisicao.Genero;

            await _context.SaveChangesAsync();

            return Ok(await _context.Animes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Anime>>> DeletarAnime(int id)
        {
            var dbAnime = await _context.Animes.FindAsync(id);
            if (dbAnime == null)
                return NotFound();

            _context.Animes.Remove(dbAnime);

            await _context.SaveChangesAsync();

            return Ok(await _context.Animes.ToListAsync());
        }

    }
}
