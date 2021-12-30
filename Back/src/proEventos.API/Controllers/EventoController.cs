using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proEventos.API.Models;

namespace proEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]
        {
           
               new Evento()
               {
                    EventoId = 1,
                    Local = "Belo Horizonte",
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    Tema = "Angular 11 e Dotnet",
                    QtdPessoas =234,
                    Lote = "1º Lote",
                    ImagemURL = "fotopng"
               },
               new Evento()
               {
                    EventoId = 2,
                    Local = "São Paulo",
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Tema = "Angular 11 e Suas Novidades",
                    QtdPessoas =500,
                    Lote = "2º Lote",
                    ImagemURL = "fotoGIF"
               }
        };

        


        public EventoController(){

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _evento.Where(Evento => Evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
           return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
           return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           return $"Exemplo de Delete com id = {id}";
        }
    }
}
