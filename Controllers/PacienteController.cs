using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Interfaces;
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository repositorio;

        public PacienteController(IPacienteRepository repositorio)
        {
            this.repositorio = repositorio;
        }


        /// <summary>
        /// Cadastrar um Paciente no banco de dados.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                var retorno = repositorio.Insert(paciente);
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
        /// Listar todas os Pacientes.
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
        /// Buscar um Paciente por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPacienteporId(int id)
        {
            try
            {
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Paciente não encontrado" });
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
        /// Alterar um Paciente.É necessário implementar o Id na aplicação.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Paciente paciente)
        {
            try
            {
                //Verificar se os ids batem
                if (id != paciente.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Paciente não encontrado"
                    });
                }
                //Alterar
                repositorio.Update(paciente);
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
        /// Alterar algo específico no Paciente.Modelo: "op", "path", "value".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchPaciente"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchPaciente)
        {
            try
            {
                if (patchPaciente == null)
                { return BadRequest(); }

                var paciente = repositorio.GetbyId(id);
                if (paciente == null)
                {
                    return NotFound(new { Message = "Paciente não encontrada." });
                }

                repositorio.UpdateParcial(patchPaciente, paciente);

                return Ok(paciente);


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



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var buscar = repositorio.GetbyId(id);
                if (buscar == null)
                {
                    return NotFound(new { Message = "Paciente não encontrado." });
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













