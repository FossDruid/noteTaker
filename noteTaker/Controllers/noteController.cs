//  noteController API.  Supports GET, POST, PUT, DELETE

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace noteTaker.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class noteController : ControllerBase
    {
        private readonly DataContext dataContext;

        public noteController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet("getNote")]
        public async Task<ActionResult<List<note>>> Get()
        {
            return Ok(await this.dataContext.notes.ToListAsync());
        }
        
        [HttpGet("getNote{id}")]
        public async Task<ActionResult<note>> Get(int id)
        {                            
            var note = await this.dataContext.notes.FindAsync(id);
            if (note == null)
                return BadRequest("Note with id {id} not found, bad id.  Try another id.");
            return Ok(note);
        }   
                           
        [HttpPost("postNote")]
        public async Task<ActionResult<List<note>>> AddNote(note userNote)
        {
            this.dataContext.notes.Add(userNote);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.notes.ToListAsync());
        }

        [HttpPut("putNote")]
        public async Task<ActionResult<List<note>>> UpdateNote(note request)
        {
            var notes = await this.dataContext.notes.FindAsync(request.id);
            if (notes == null)
                return BadRequest($"Note id {request.id} not found, bad id.  Try another id.");
    
            notes.title = request.title;
            notes.noteText = request.noteText;

            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.notes.ToListAsync());
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<List<note>>> Delete(int id)
        {
            var notes = await this.dataContext.notes.FindAsync(id);
            if (notes == null)
                return BadRequest($"Note with {id} not found, bad id.  Try another id.");

            this.dataContext.notes.Remove(notes);
            await this.dataContext.SaveChangesAsync();

            return Ok(notes);
        }
    }
}
