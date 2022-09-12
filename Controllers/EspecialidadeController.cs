using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Interfaces;
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository repositorio;

        public EspecialidadeController(IEspecialidadeRepository _repositorio)
        {
            repositorio = _repositorio;
        }


        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidades)
        {
            try
            {
                var retorno = repositorio.Insert(especialidades);
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

        [HttpGet("{id}")]
        public IActionResult BuscarEspecialporId(int id)
        {
            try
            {
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " Especialidade não encontrada" });
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

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Especialidade especialidade)
        {
            try
            {
                //Verificar se os ids batem
                if (id != especialidade.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetById(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Especialidade não encontrada"
                    });
                }
                //Alterar
                repositorio.Update(especialidade);
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

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            try
            {
                if (patchEspecialidade == null)
                { return BadRequest(); }

                var especialidade = repositorio.GetById(id);
                if (especialidade == null)
                {
                    return NotFound(new { Message = "Especialidae não encontrada." });
                }

                repositorio.UpdateParcial(patchEspecialidade, especialidade);

                return Ok(especialidade);


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

        [HttpDelete("{id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var buscar = repositorio.GetById(id);
                if (buscar == null)
                {
                    return NotFound(new { Message = "Especialidade não encontrada." });
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












