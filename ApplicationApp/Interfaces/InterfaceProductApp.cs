using ApplicationApp.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericApp<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
