using GestiondeEventos.Entidades;
using GestiondeEventos.Migrations;
using GestiondeEventos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usuario = GestiondeEventos.Entidades.Usuario;

namespace GestiondeEventos.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController: ControllerBase
    {
        private readonly ApplicationDbContext contx;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public UsuarioController(ApplicationDbContext context)
        {
            contx = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            return await contx.Usuarios.ToListAsync();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            return await contx.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == id);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            var existeEvento = await contx.Eventos.AnyAsync(x => x.ID == usuario.UsuarioId);
            if (!existeEvento)
            {
                return BadRequest("No existe Evento");
            }

            contx.Add(usuario);
            await contx.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            var existeUsuario = await contx.Usuarios.AnyAsync(x => x.UsuarioId == usuario.UsuarioId);

            if (!existeUsuario)
            {
                return BadRequest("No existe el usuario");
            }

            if(usuario.UsuarioId != id)
            {
                return BadRequest("El id del usuario no coincide con el establecido en la url ");
            }

            contx.Add(usuario);
            await contx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await contx.Usuarios.AnyAsync(x => x.UsuarioId == id);
            if (!exist)
            {
                return NotFound("No se encontro el registro en la base de datos");
            }

            contx.Remove(new Usuario() { UsuarioId = id });
            await contx.SaveChangesAsync();
            return Ok();
        }
    }
}
