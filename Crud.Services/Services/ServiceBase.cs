using Crud.Domain.Interfaces.Repository;
using Crud.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            return await _repositoryBase.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _repositoryBase.Delete(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _repositoryBase.Update(entity);
        }
    }
}
