using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public class DetalhesDoLocal
    {
        public DetalhesDoLocal()
        {
            DetalhesImovels = new HashSet<DetalhesImovel>();
            DetalhesVenda = new HashSet<DetalhesVendum>();
        }

        public int Id { get; set; }
        public string Garagem { get; set; }
        public string Academia { get; set; }

        public virtual ICollection<DetalhesImovel> DetalhesImovels { get; set; }
        public virtual ICollection<DetalhesVendum> DetalhesVenda { get; set; }
    }
}
