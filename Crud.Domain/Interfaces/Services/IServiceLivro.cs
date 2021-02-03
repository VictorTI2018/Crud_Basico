using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Interfaces.Services
{
    public interface IServiceLivro: IServiceBase<Livro>
    {

        Task<List<LivroListaDto>> BuscarTodos(int IdCategoria);

        Task<LivroListaDto> BuscarPorId(int id);
    }
}
