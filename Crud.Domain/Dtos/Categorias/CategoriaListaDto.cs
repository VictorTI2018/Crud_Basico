using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Crud.Domain.Dtos
{
    public class CategoriaListaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public static Expression<Func<Categorias, CategoriaListaDto>> Lista
        {
            get
            {
                return x => new CategoriaListaDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Descricao = x.Descricao
                };
            }
        }
    }
}
