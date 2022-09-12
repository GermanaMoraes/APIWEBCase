using Microsoft.AspNetCore.Http;
using DesafioCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Models;

namespace DesafioCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository repositorio;

        public UsuarioController(IUsuarioRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                var retorno = repositorio.Insert(usuario);
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
        public IActionResult BuscarConsultaporId(int id)
        {
            try
            {
                var retorno = repositorio.GetbyId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Usuario não encontrado" });
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
    }

}




    

