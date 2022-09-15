using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Interfaces;
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository repositorio;

        public TipoUsuarioController(ITipoUsuarioRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        
       

        /// <summary>
        /// Cadastrar um Tipo de Usuário no banco de dados
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                var retorno = repositorio.Insert(tipoUsuario);
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
        /// Listar todas os Tipo de Usuário.
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
        /// Buscar um Tipo de Usuário por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoporId(int id)
        {
            try
            {
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = " TipoUsuario não encontrado" });
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
        public IActionResult Alterar(int id, TipoUsuario tipo)
        {
            try
            {
                //Verificar se os ids batem
                if (id != tipo.Id)
                {
                    return BadRequest();
                }

                //Verificar se o id existe no banco
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new
                    {
                        Message = " Tipo não encontrado"
                    });
                }
                //Alterar
                repositorio.Update(tipo);
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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchTipo)
        {
            try
            {
                if (patchTipo == null)
                { return BadRequest(); }

                var tipo = repositorio.GetbyId(id);
                if (tipo == null)
                {
                    return NotFound(new { Message = "Tipo não encontrado." });
                }

                repositorio.UpdateParcial(patchTipo, tipo);

                return Ok(tipo);


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
                    return NotFound(new { Message = "Tipo não encontrado." });
                }

                repositorio.Delete(repositorio.GetbyId(id));
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














