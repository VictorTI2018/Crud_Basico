using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crud.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }

        [ForeignKey("Categorias")]
        public int IdCategoria { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string ISBN { get; set; }
    
        public virtual Categorias Categorias { get; set; }
    }
}
