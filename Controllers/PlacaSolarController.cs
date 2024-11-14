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
        private readonly IEstabelecimentoRepository estabelecimentoRepository;

        public PlacaSolarController(IPlacaSolarRepository placaRepo, IEstabelecimentoRepository estabelecimentoRepo)
        {
            placaRepository = placaRepo;
            estabelecimentoRepository = estabelecimentoRepo;
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
        /// Criar uma nova Placa
        /// </summary>
        /// <returns>Placa criada</returns>
        /// <remarks> 
        ///     Sample request:
        ///         POST /api/Registro
        ///         {
        ///             "Descrição": "Descrição da placa",
        ///             "Status": "Status sendo Desativado = 0, Ativado = 1,",
        ///             "EstabelecimentoId": "Id do estabelecimento que a placa esta relacionada",  
        ///         }
        /// </remarks>
        /// <response code="201"> Salva a triagem</response>
        /// <response code="500"> Erro ao salvar a triagem</response>
        /// <response code="400"> Dados inválidos</response>
        [HttpPost]
        public async Task<ActionResult<PlacaSolar>> AddPlaca([FromBody] PlacaSolar placa)
        {
            try
            {
                if (placa == null)
                    return BadRequest("Dados da placa são inválidos.");

                // Verifica se o estabelecimento existe
                var estabelecimentoExistente = await estabelecimentoRepository.GetEstabelecimento(placa.IdEstabelecimento);
                if (estabelecimentoExistente == null)
                    return NotFound("Estabelecimento não encontrado.");

                // Adiciona a placa após a validação
                var createPlaca = await placaRepository.AddPlaca(placa);

                return CreatedAtAction(nameof(GetPlacas),
                    new { id = createPlaca.idPlacaSolar }, createPlaca);
            }
            catch (Exception ex)
            {
                // Logar a exceção (ex) se necessário
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Placa");
            }
        }


    }
}
