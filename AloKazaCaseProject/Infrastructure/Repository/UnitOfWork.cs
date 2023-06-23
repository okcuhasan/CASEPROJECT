using AloKazaCaseProject.Core.Interfaces;

namespace AloKazaCaseProject.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IVehicleRepository vehicleRepository)
        {
            Vehicles = vehicleRepository;
        }
        public IVehicleRepository Vehicles { get; }

        
    }
}
