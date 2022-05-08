using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public partial class DetalhesImovel
    {
        public DetalhesImovel()
        {
            Agendamentos = new HashSet<Agendamento>();
            DetalhesLocacaos = new HashSet<DetalhesLocacao>();
            DetalhesVenda = new HashSet<DetalhesVendum>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Tamanho { get; set; }
        public int NumeroSalas { get; set; }
        public int NumeroBanheiros { get; set; }
        public int Suites { get; set; }
        public string Mobiliado { get; set; }
        public decimal ValorImovel { get; set; }
        public string DetalhesImovel1 { get; set; }
        public string Pets { get; set; }
        public string MoradorAtual { get; set; }
        public string Descricao { get; set; }
        public int EnderecoId { get; set; }
        public int DetalhesDoLocalId { get; set; }
        public int UsuarioId { get; set; }

        public virtual DetalhesDoLocal DetalhesDoLocal { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<DetalhesLocacao> DetalhesLocacaos { get; set; }
        public virtual ICollection<DetalhesVendum> DetalhesVenda { get; set; }
    }
}
