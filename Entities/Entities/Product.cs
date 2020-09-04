using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Product : Base
    {
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [Display(Name = "Activo")]
        public bool Ativo { get; set; }
    }
}
