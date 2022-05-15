using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public class Usuario
    {
        public Usuario()
        {
            DetalhesImovels = new HashSet<DetalhesImovel>();
            DetalhesLocacaos = new HashSet<DetalhesLocacao>();
            UsuarioRoles = new HashSet<UsuarioRole>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? Senha { get; set; }
        public string Celuar { get; set; }

        public virtual ICollection<DetalhesImovel> DetalhesImovels { get; set; }
        public virtual ICollection<DetalhesLocacao> DetalhesLocacaos { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
