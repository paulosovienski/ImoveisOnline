using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public class DetalhesVendum
    {
        public int Id { get; set; }
        public decimal ValorVenda { get; set; }
        public string StatusVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public string TermosDeUso { get; set; }
        public int AnuncioImovelId { get; set; }
        public int DetalhesDoLocalId { get; set; }
        public int DetalhesImovelId { get; set; }

        public virtual AnuncioImovel AnuncioImovel { get; set; }
        public virtual DetalhesDoLocal DetalhesDoLocal { get; set; }
        public virtual DetalhesImovel DetalhesImovel { get; set; }
    }
}
