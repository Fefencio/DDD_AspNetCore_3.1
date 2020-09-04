using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestruture.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Se não estiver configurado no projecto UI pega designição de chame do Json con
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConnectionConfig()
        {
            var strCon = "Data Source=localhost;Initial Catalog=dbDDDTeste;Integrated Security=True";
            return strCon;
        }
    }
}
