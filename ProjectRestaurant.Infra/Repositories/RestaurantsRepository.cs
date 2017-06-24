using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectRestaurant.Domain;
using ProjectRestaurant.Domain.Repositories.Contracts;
using ProjectRestaurant.Infra.Contexts;

namespace ProjectRestaurant.Infra.Repositories
{
    public class RestaurantsRepository : IRestaurantRepository
    {
        private readonly RestaurantDataContext _db;

        public RestaurantsRepository(RestaurantDataContext dataContext)
        {
            _db = dataContext;
        }

        public List<Restaurant> Get()
        {
            return _db.Restaurants.ToList();
        }

        public Restaurant Get(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public List<Restaurant> GetByName(string name)
        {
            return _db.Restaurants.Where(x => x.Name.Contains(name)).ToList();
        }

        public bool Create(Restaurant restaurant)
        {
            try
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Restaurant restaurant)
        {
            try
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var restaurants = _db.Restaurants.Find(id);
            if (restaurants != null) _db.Restaurants.Remove(restaurants);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
