using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
