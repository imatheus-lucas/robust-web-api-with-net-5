
using Manager.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Manager.Infra.Interfaces
{
  public interface IBaseRepository<T> where T : Base
  {
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> Delete(T obj);
    Task<T> Get(int id);
    Task<List<T>> Get();

  }
}