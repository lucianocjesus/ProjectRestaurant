using System;
using System.Collections.Generic;

namespace ProjectRestaurant.Domain.Repositories.Contracts
{
    public interface IPlateRepository : IDisposable
    {
        List<Plate> Get();
        Plate Get(int id);
        List<Plate> GetByName(string name);
        bool Create(Plate plate);
        bool Update(Plate plate);
        void Delete(int id);
    }
}
