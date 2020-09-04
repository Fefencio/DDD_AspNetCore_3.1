using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Infraestruture.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestruture.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGeneric<Product>, IProduct
    {
    }
}
