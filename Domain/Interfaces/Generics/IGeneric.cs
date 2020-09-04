using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T objecto);
        Task Update(T objecto);
        Task Delete(T objecto);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
    }
}
