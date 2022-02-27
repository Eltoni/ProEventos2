using System;
using proEventos.Domain;

namespace ProEventos.Domain
{
    public class EventosPalestrantes
    {
        public int EventoId { get; set; }

        public Evento Evento { get; set; }

        public int PalestranteId { get; set; }

        public Palestrante Palestrante { get; set; }
    }
}