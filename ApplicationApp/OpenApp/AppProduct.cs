using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        private readonly IProduct _iProduct;
        private readonly IServiceProduct _IServiceProduct;
        public AppProduct(IProduct iProduct, IServiceProduct iServiceProduct)
        {
            _iProduct = iProduct;
            _IServiceProduct = iServiceProduct;
        }
        public async Task Add(Product objecto)
        {
            await _iProduct.Add(objecto);
        }

        public async Task Delete(Product objecto)
        {
            await _iProduct.Delete(objecto);
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await _iProduct.GetEntityById(id);
        }

        public async Task<List<Product>> List()
        {
            return await _iProduct.List();
        }
        public async Task Update(Product objecto)
        {
            await _iProduct.Update(objecto);
        }

        #region Metodos Customizados
        public async Task AddProduct(Product product)
        {
            await _IServiceProduct.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _IServiceProduct.UpdateProduct(product);
        }
        #endregion
    }
}
