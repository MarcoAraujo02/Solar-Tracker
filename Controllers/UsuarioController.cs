
using Microsoft.AspNetCore.Mvc;
using Solar_Tracker.Data;
using Solar_Tracker.Models;
using Solar_Tracker.Repository;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuario)
        {
            usuarioRepository = usuario;

        }

        /// <summary>
        /// Obter todos os Usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de estabelecimentos</response>
        /// <response code="500"> Erro ao obter estabelecimento</response>
        /// <response code="404"> estabelecimento nao encontrado</response>
        /// 

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuarios()
        {
            try
            {

                return Ok(await usuarioRepository.GetUsuarios());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar Usuarios");
            }

        }

        /// <summary>
        /// Endpoint para cadastrar novos Usuarios
        /// </summary>
        /// <returns>Retorna o Usuario</returns>
        ///
        /// <response code="201"> Salva o Usuario</response>
        /// <response code="500"> Erro ao salva o Usuario</response>
        /// <response code="400"> Verifique as informações</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                var createUser = await usuarioRepository.AddUsuario(usuario);


                return CreatedAtAction(nameof(GetUsuarios),
                    new { id = createUser.IdUsuario }, createUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Usuario");
            }
        }
    }

}

