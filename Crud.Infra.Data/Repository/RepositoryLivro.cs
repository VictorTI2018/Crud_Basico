using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using Crud.Domain.Interfaces.Repository;
using Crud.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infra.Data.Repository
{
    public class RepositoryLivro: RepositoryBase<Livro>, IRepositoryLivro
    {
        private readonly SqlContext _sqlContext;

        public RepositoryLivro(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<List<LivroListaDto>> BuscarTodos (int IdCategoria)
        {
            return await _sqlContext.
                Livro.Where(x => x.IdCategoria == IdCategoria)
                .Select(LivroListaDto.Lista)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LivroListaDto> BuscarPorId(int id)
        {
            return await _sqlContext
                .Livro
                .Where(x => x.Id == id)
                .Select(LivroListaDto.Lista)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
