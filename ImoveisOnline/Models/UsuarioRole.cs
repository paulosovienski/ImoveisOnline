using System;
using System.Collections.Generic;

#nullable disable

namespace ImoveisOnline.Models
{
    public class UsuarioRole
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
