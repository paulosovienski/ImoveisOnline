using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public partial class DetalhesLocacao
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataInicialLocacao { get; set; }
        public DateTime DataFinalLocacao { get; set; }
        public int TermosDeUso { get; set; }
        public decimal ValorAluguel { get; set; }
        public int StatusAluguel { get; set; }
        public int UsuarioId { get; set; }
        public int AnuncioImovelId { get; set; }
        public int DetalhesImovelId { get; set; }

        public virtual AnuncioImovel AnuncioImovel { get; set; }
        public virtual DetalhesImovel DetalhesImovel { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
