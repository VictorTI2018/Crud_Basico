using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Interfaces.Repository
{
    public interface IRepositoryCategorias: IRepositoryBase<Categorias>
    {

        Task<List<CategoriaListaDto>> ObterTodos();

        Task<CategoriaDto> Obter(int id);

        Task<bool> ExisteCategoria(string nome, int id);
    }
}
