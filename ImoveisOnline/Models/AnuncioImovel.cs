using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public partial class AnuncioImovel
    {
        public AnuncioImovel()
        {
            DetalhesLocacaos = new HashSet<DetalhesLocacao>();
            DetalhesVenda = new HashSet<DetalhesVendum>();
        }

        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public decimal Preco { get; set; }

        public virtual ICollection<DetalhesLocacao> DetalhesLocacaos { get; set; }
        public virtual ICollection<DetalhesVendum> DetalhesVenda { get; set; }
    }
}
