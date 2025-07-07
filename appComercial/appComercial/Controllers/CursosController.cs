using appComercial.Data;
using appComercial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appComercial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Curso.Include(c => c.Docente).ToListAsync();
        }

        // GET /api/cursos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Curso.Include(c => c.Docente)
                                             .FirstOrDefaultAsync(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            return curso;
        }

        // GET /api/cursos/ciclo/{ciclo}
        [HttpGet("ciclo/{ciclo}")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursosPorCiclo(string ciclo)
        {
            var cursos = await _context.Curso.Include(c => c.Docente)
                                               .Where(c => c.Ciclo == ciclo)
                                               .ToListAsync();
            return cursos;
        }

        // POST /api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        // PUT /api/cursos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/cursos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
