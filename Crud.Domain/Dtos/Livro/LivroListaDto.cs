using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Crud.Domain.Dtos
{
    public class LivroListaDto
    {
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string ISBN { get; set; }

        public static Expression<Func<Livro, LivroListaDto>> Lista
        {
            get
            {
                return x => new LivroListaDto()
                {
                    Id = x.Id,
                    IdCategoria = x.IdCategoria,
                    Nome = x.Nome,
                    Autor = x.Autor,
                    Editora = x.Editora,
                    DataPublicacao = x.DataPublicacao,
                    ISBN = x.ISBN
                };
            }
        }
    }
}
