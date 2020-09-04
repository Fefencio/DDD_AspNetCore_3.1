using Domain.Interfaces.Generics;
using Infraestruture.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.Repository.Generic
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private bool _disposed = false;
        SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var objecto = await data.Set<T>().FindAsync(id);
                return objecto;
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var objecto = await data.Set<T>().AsNoTracking().ToListAsync();
                return objecto;
            }
        }

        public async Task Update(T objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(objecto);
                await data.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Dispose managed state (managed object)
                safeHandle?.Dispose();
            }
            _disposed = true;
        }
    }
}
