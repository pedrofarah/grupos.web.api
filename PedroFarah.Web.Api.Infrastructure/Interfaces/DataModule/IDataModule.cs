using Microsoft.EntityFrameworkCore.Storage;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories;

namespace PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule
{
    public interface IDataModule
    {
        IRepository<Cliente> ClienteRepository { get; }
        IRepository<Gerente> GerenteRepository { get; }
        IRepository<Grupo> GrupoRepository { get; }
        IRepository<GrupoCliente> GrupoClienteRepository { get; }
        IDbContextTransaction CurrentTransaction { get; set; }
        Task StartTransactionAsync();
        Task CommitDataAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
