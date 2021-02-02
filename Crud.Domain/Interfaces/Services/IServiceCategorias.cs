using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Interfaces.Services
{
    public interface IServiceCategorias : IServiceBase<Categorias>
    {

        Task<List<CategoriaListaDto>> ObterTodos();

        Task<ResponseRequest> Obter(int id);

        Task<ResponseRequest> Cadastrar(Categorias categorias);

        Task<ResponseRequest> Atualizar(Categorias categorias);

        Task<ResponseRequest> Deletar(int id);
    }
}
