using System;
using System.Collections.Generic;

namespace ProjectRestaurant.Domain.Repositories.Contracts
{
    public interface IRestaurantRepository : IDisposable
    {
        List<Restaurant> Get();
        Restaurant GetPlateByRestaurant(int id);
        Restaurant Get(int id);
        List<Restaurant> GetByName(string name);
        bool Create(Restaurant restaurant);
        bool Update(Restaurant restaurant);
        void Delete(int id);
    }
}
