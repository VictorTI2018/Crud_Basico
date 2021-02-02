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
    public class RepositoryCategorias: RepositoryBase<Categorias>, IRepositoryCategorias
    {
        private readonly SqlContext _sqlContext;

        public RepositoryCategorias(SqlContext sqlContext) : base (sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<List<CategoriaListaDto>> ObterTodos()
        {
            return await _sqlContext.Categorias
                .Select(CategoriaListaDto.Lista)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExisteCategoria (string nome, int id)
        {
            Categorias categoriaExiste = new Categorias();
            if (id > 0)
            {
                categoriaExiste = await _sqlContext.
                Categorias.Where(x => x.Nome == nome && x.Id != id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            } else
            {
                categoriaExiste = await _sqlContext.
                Categorias.Where(x => x.Nome == nome)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            }
            if (categoriaExiste != null)
            {
                return true;
            }

            return false;
        }

        public async Task<CategoriaDto> Obter(int id)
        {
            return await _sqlContext
                .Categorias.Where(x => x.Id == id)
                .Select(CategoriaDto.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
