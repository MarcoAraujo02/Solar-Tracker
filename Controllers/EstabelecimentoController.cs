using Microsoft.AspNetCore.Mvc;
using Solar_Tracker.Models;
using Solar_Tracker.Repository;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepository estabelecimentoRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimento) 
        {
            estabelecimentoRepository = estabelecimento;
        }


        /// <summary>
        /// Obter todos os estabelecimentos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de estabelecimentos</response>
        /// <response code="500"> Erro ao obter estabelecimento</response>
        /// <response code="404"> estabelecimento nao encontrado</response>
        /// 

        [HttpGet]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimentos()
        {
            try
            {

                return Ok(await estabelecimentoRepository.GetEstabelecimento());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar funcionarios");
            }

        }

        /// <summary>
        /// Obter Estabelecimento pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna Estabelecimento</response>
        /// <response code="500"> Erro ao obter Estabelecimento</response>
        /// <response code="404"> Estabelecimento nao encontrado</response>
        /// 

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimento(int id)
        {
            try
            {
                var result = await estabelecimentoRepository.GetEstabelecimento(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estabelecimento");
            }



        }

        /// <summary>
        /// Endpoint para cadastrar novos Estabelecimentos
        /// </summary>
        /// <returns>Retorna o  Estabelecimento</returns>
        ///
        /// <response code="201"> Salva o Estabelecimento</response>
        /// <response code="500"> Erro ao salva o Estabelecimento</response>
        /// <response code="400"> Verifique as informações</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<Estabelecimento>> AddEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                if (estabelecimento == null) return BadRequest();

                var createEstab = await estabelecimentoRepository.AddEstabelecimento(estabelecimento);


                return CreatedAtAction(nameof(GetEstabelecimentos),
                    new { id = createEstab.IdEstabelecimento }, createEstab );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estabelecimento");
            }
        }



        /// <summary>
        /// Obter todos os Estabelecimentos pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de estabelecimentos</response>
        /// <response code="500"> Erro ao obter estabelecimento</response>
        /// <response code="404"> Estabelecimento nao encontrado</response>
        /// 


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEstabelecimento(int id)
        {
            try
            {
                var funToDelete = await estabelecimentoRepository.GetEstabelecimento(id);

                if (funToDelete == null)
                    return NotFound($"Funcionario com id {id} não encontrado");

                await estabelecimentoRepository.DeleteEstabelecimento(id);

                return Ok($"Funcionario com id {id} deletado");
            }
            catch (Exception ex)
            {
                // Log the exception message
                // Logger.LogError(ex, "Erro ao deletar Funcionario");

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar Funcionario");
            }
        }

    }
}
