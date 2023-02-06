using Microsoft.EntityFrameworkCore.Storage;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Context;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;
using PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories;
using PedroFarah.Web.Api.Infrastructure.Repositories;

namespace PedroFarah.Web.Api.Infrastructure.DataModule
{
    public class DataModule : IDataModule, IDisposable
    {
        public DataModule(ApplicationDbContext dbContext)
        {
            CurrentContext = dbContext;
        }

        public readonly ApplicationDbContext CurrentContext;

        public IDbContextTransaction CurrentTransaction { get; set; }

        private bool ActiveTransaction { get; set; } = false;

        private bool _disposed = false;
        
        private IRepository<Cliente> clienteRepository = null;
        public IRepository<Cliente> ClienteRepository
        {
            get => clienteRepository ??= new Repository<Cliente>(CurrentContext);
        }

        private IRepository<Gerente> gerenteRepository = null;
        public IRepository<Gerente> GerenteRepository
        {
            get => gerenteRepository ??= new Repository<Gerente>(CurrentContext);
        }

        private IRepository<Grupo> grupoRepository = null;
        public IRepository<Grupo> GrupoRepository
        {
            get => grupoRepository ??= new Repository<Grupo>(CurrentContext);
        }

        private IRepository<GrupoCliente> grupoClienteRepository = null;
        public IRepository<GrupoCliente> GrupoClienteRepository
        {
            get => grupoClienteRepository ??= new Repository<GrupoCliente>(CurrentContext);
        }

        public async Task StartTransactionAsync()
        {
            CurrentTransaction = await CurrentContext.Database.BeginTransactionAsync();
            ActiveTransaction = true;
        }

        public async Task CommitDataAsync()
        {
            await CurrentContext.SaveChangesAsync();
            if (ActiveTransaction)
                CommitTransaction();
        }

        public void CommitTransaction()
        {
            if (ActiveTransaction)
                CurrentContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            if (ActiveTransaction)
                CurrentContext.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                CurrentContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}