using AutoMapper;
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
    public class ServiceCategorias: ServiceBase<Categorias>, IServiceCategorias
    {
        private readonly IRepositoryCategorias _repositoryCategorias;
        private readonly IMapper _mapper;

        public ServiceCategorias(IRepositoryCategorias repositoryCategorias,
            IMapper mapper) : base(repositoryCategorias)
        {
            _repositoryCategorias = repositoryCategorias;
            _mapper = mapper;
        }

        public async Task<List<CategoriaListaDto>> ObterTodos()
        {
            return await _repositoryCategorias.ObterTodos();
        }

        public async Task<ResponseRequest> Cadastrar(Categorias categorias)
        {
            ResponseRequest response = new ResponseRequest();
            if (await _repositoryCategorias.ExisteCategoria(categorias.Nome, categorias.Id))
            {
                response.Messages.Add("Essa categoria já existe!");
                response.Status = false;
                return response;
            }
            Categorias dados = await _repositoryCategorias.Add(categorias);
            response.Resource = dados;
            response.Status = true;
            response.Messages.Add("Categoria cadastrada com sucesso");
            return response;
        }

        public async Task<ResponseRequest> Atualizar(Categorias categorias)
        {
            ResponseRequest response = new ResponseRequest();
            if (await _repositoryCategorias.ExisteCategoria(categorias.Nome, categorias.Id))
            {
                response.Messages.Add("Essa categoria já existe!");
                response.Status = false;
                return response;
            }
            Categorias dados = await _repositoryCategorias.Update(categorias);
            response.Resource = dados;
            response.Status = true;
            response.Messages.Add("Categoria atualizada com sucesso");
            return response;
        }

        public async Task<ResponseRequest> Obter(int id)
        {
           
            return new ResponseRequest()
            {
                 Resource = await _repositoryCategorias.Obter(id),
                 Messages = new List<string>(),
                 Status = true
            };
        }

        public async Task<ResponseRequest> Deletar(int id)
        {
            await _repositoryCategorias.Delete(id);
            return new ResponseRequest() {  Resource = null, Messages = new List<string>(), Status = true };
        }
    }
}
