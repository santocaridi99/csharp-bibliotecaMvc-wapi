using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_bibliotecaMvc.Data;
using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Autores1Controller : ControllerBase
    {
        private readonly BibliotecaContex _context;

        public Autores1Controller(BibliotecaContex context)
        {
            _context = context;
        }

        // GET: api/Autores1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autore>>> GetAutori()
        {
          if (_context.Autori == null)
          {
              return NotFound();
          }
            return await _context.Autori.ToListAsync();
        }

        // GET: api/Autores1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autore>> GetAutore(int id)
        {
          if (_context.Autori == null)
          {
              return NotFound();
          }
            var autore = await _context.Autori.FindAsync(id);

            if (autore == null)
            {
                return NotFound();
            }

            return autore;
        }

        // PUT: api/Autores1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutore(int id, Autore autore)
        {
            if (id != autore.AutoreID)
            {
                return BadRequest();
            }

            _context.Entry(autore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autores1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autore>> PostAutore(Autore autore)
        {
          if (_context.Autori == null)
          {
              return Problem("Entity set 'BibliotecaContex.Autori'  is null.");
          }
            _context.Autori.Add(autore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutore", new { id = autore.AutoreID }, autore);
        }

        // DELETE: api/Autores1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutore(int id)
        {
            if (_context.Autori == null)
            {
                return NotFound();
            }
            var autore = await _context.Autori.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }

            _context.Autori.Remove(autore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoreExists(int id)
        {
            return (_context.Autori?.Any(e => e.AutoreID == id)).GetValueOrDefault();
        }
    }
}
