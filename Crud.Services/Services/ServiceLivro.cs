using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using Crud.Domain.Interfaces.Repository;
using Crud.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services.Services
{
    public class ServiceLivro: ServiceBase<Livro>, IServiceLivro
    {
        private readonly IRepositoryLivro _repoLivro;

        public ServiceLivro(IRepositoryLivro repositoryLivro) : base(repositoryLivro)
        {
            _repoLivro = repositoryLivro;
        }

        public async Task<List<LivroListaDto>> BuscarTodos(int IdCategoria)
        {
            return await _repoLivro.BuscarTodos(IdCategoria);
        }

        public async Task<LivroListaDto> BuscarPorId(int id)
        {
            return await _repoLivro.BuscarPorId(id);
        }
    }
}
