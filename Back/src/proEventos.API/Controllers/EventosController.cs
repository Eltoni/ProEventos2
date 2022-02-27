using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proEventos.Persistence;
using proEventos.Domain;
using ProEventos.Application.Contratos;

using Microsoft.AspNetCore.Http;

namespace proEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService eventoService;
        public EventosController(IEventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await eventoService.GetAllEventosAsync(true);

                if(eventos == null) return NotFound("Nenhum Evento Encontrado");

                return Ok(eventos);

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try
            {
                var evento = await eventoService.GetAllEventosByIdAsync(id, true);

                if(evento == null) return NotFound("Nenhum Evento Encontrado");

                return Ok(evento);

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
        


        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
             try
            {
                var evento = await eventoService.GetAllEventosByTemaAsync(tema, true);

                if(evento == null) return NotFound("Nenhum Eventos Por tema Encontrados");

                return Ok(evento);

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
             try
            {
                var evento = await eventoService.AddEventos(model);

                if(evento == null) return BadRequest("Erro ao tentar cadastrar evento");

                return Ok(evento);

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}/id")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
             try
            {
                var evento = await eventoService.UpdateEventos(id, model);

                if(evento == null) return BadRequest("Erro ao tentar ao atualizar evento");

                return Ok(evento);

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               // var evento = await eventoService.DeleteEventos(id);

               // if(evento == null) return BadRequest("Erro ao tentar ao atualizar evento");

                // return Ok(evento);
                if( await eventoService.DeleteEventos(id)){

                    return Ok("Deletado");

                }
                else{

                    return BadRequest("Evento Não deletado");


                }

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}
