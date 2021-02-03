using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Domain.Dtos
{
    public class LivroDadosDto
    {
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string ISBN { get; set; }
    }
}
