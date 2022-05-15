using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DiaEHora { get; set; }
        public string Lebretes { get; set; }
        public int DetalhesImovelId { get; set; }

        public virtual DetalhesImovel DetalhesImovel { get; set; }
    }
}
