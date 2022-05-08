using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            DetalhesImovels = new HashSet<DetalhesImovel>();
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Iptu { get; set; }

        public virtual ICollection<DetalhesImovel> DetalhesImovels { get; set; }
    }
}
