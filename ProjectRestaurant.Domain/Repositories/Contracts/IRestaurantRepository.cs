using System;
using System.Collections.Generic;

namespace ProjectRestaurant.Domain.Repositories.Contracts
{
    public interface IRestaurantRepository : IDisposable
    {
        List<Restaurant> Get();
        Plate Get(int id);
        List<Restaurant> GetByName(string name);
        bool Create(Restaurant autor);
        bool Update(Restaurant autor);
        void Delete(int id);
    }
}
