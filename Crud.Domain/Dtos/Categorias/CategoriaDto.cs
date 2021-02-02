using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Crud.Domain.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public static Expression<Func<Categorias, CategoriaDto>> Categoria
        {
            get
            {
                return x => new CategoriaDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Descricao = x.Descricao
                };
            }
        }
    }
}
