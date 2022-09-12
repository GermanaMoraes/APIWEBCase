using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioCase.Interfaces;
using DesafioCase.Models;

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

    }
}



