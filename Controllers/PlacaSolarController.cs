using Microsoft.AspNetCore.Mvc;
using Solar_Tracker.Models;
using Solar_Tracker.Repository;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlacaSolarController : ControllerBase
    {

        private readonly IPlacaSolarRepository placaRepository;

        public PlacaSolarController(IPlacaSolarRepository placa)
        {
            placaRepository = placa;

        }


        /// <summary>
        /// Obter todas as Placas Solares
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de Placas Solares</response>
        /// <response code="500"> Erro ao obter placas</response>
        /// <response code="404"> placa nao encontrada</response>
        /// 
        [HttpGet]
        public async Task<ActionResult<PlacaSolar>> GetPlacas()
        {
            try
            {

                return Ok(await placaRepository.GetPlacas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar Placa");
            }

        }


        /// <summary>
        /// Endpoint para cadastrar novas Placas
        /// </summary>
        /// <returns>Retorna a placa solar cadastrada</returns>
        ///
        /// <response code="201"> Salva a placa solar</response>
        /// <response code="500"> Erro ao salvar a Placa</response>
        /// <response code="400"> Verifique as informações</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<PlacaSolar>> AddPlaca([FromBody] PlacaSolar placa)
        {
            try
            {
                if (placa == null) return BadRequest();

                var createplaca = await placaRepository.AddPlaca(placa);


                return CreatedAtAction(nameof(GetPlacas),
                    new { id = createplaca.idPlacaSolar}, createplaca);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Placa");
            }
        }


    }
}
