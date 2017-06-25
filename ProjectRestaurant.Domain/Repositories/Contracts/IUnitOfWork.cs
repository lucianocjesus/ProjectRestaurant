using System;

namespace ProjectRestaurant.Domain.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void DeletePlatesAndRestaurant(int id);
        void DeletePlate(int id);
    }
}
