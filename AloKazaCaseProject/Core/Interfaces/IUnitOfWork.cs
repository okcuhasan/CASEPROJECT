namespace AloKazaCaseProject.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicles { get; }
    }
}
