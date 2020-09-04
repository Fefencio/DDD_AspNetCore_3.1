using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces.Generic
{
    public interface InterfaceGenericApp<T> where T : class
    {
        Task Add(T objecto);
        Task Update(T objecto);
        Task Delete(T objecto);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
    }
}
