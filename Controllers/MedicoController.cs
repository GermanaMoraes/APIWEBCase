using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Interfaces;
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository repositorio;

        public MedicoController(IMedicoRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        /// <summary>
        /// Cadastrar um Médico no banco de dados.
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                var retorno = repositorio.Insert(medico);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Listar todas os Médicos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var retorno = repositorio.GetAll();
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Buscar um Médico por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarMedicoporId(int id)
        {
            try
            {
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Médico não encontrado" });
                }

                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Buscar um Médico por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Medico medico)
        {
            try
            {
                //Verificar se os ids batem
                if (id != medico.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Médico não encontrado"
                    });
                }
                
                //Alterar
                repositorio.Update(medico);
                return NoContent();
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }

        }


        /// <summary>
        /// Alterar um Médico. É necessário implementar o Id na aplicação.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchMedico"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchMedico)
        {
            try
            {
                if (patchMedico == null)
                { return BadRequest(); }

                var medico = repositorio.GetbyId(id);
                if (medico == null)
                {
                    return NotFound(new { Message = "Médico não encontrado." });
                }

                repositorio.UpdateParcial(patchMedico, medico);

                return Ok(medico);


            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Deletar um Médico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var buscar = repositorio.GetbyId(id);
                if (buscar == null)
                {
                    return NotFound(new { Message = "Médico não encontrada." });
                }

                repositorio.Delete(buscar);
                return NoContent();

            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    Erro = "Falha na Transação",
                    Message = ex.Message
                });
            }
        }



    }
}










