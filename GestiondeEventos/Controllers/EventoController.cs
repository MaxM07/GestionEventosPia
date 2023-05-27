using GestiondeEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestiondeEventos.Controllers
{
    [ApiController]
    [Route("Evento")]
    public class EventoController : ControllerBase
    {
        private readonly ApplicationDbContext contx;

        public EventoController(ApplicationDbContext context)
        {
            contx = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            contx.Add(evento);
            await contx.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Evento>>> GetAll()
        {
            return await contx.Eventos.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Evento evento, int id)
        {
            if (evento.ID != id)
            {
                return BadRequest("El ID del evento no coincide con el establecido en el URL");
            }
            contx.Update(evento);
            await contx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Evento evento, int id)
        {
            var exist = await contx.Eventos.AnyAsync(x => x.ID == id);
            if (!exist)
            {
                return NotFound("No se encontro el registro en la base de datos");
            }

            contx.Remove(new Evento() { ID = id });
            await contx.SaveChangesAsync();
            return Ok();
        }


    }
}
