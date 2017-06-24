using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectRestaurant.Domain;
using ProjectRestaurant.Domain.Repositories.Contracts;
using ProjectRestaurant.Infra.Contexts;

namespace ProjectRestaurant.Infra.Repositories
{
    public class PlatesRepository : IPlateRepository
    {
        private readonly RestaurantDataContext _db;

        public PlatesRepository(RestaurantDataContext dataContext)
        {
            _db = dataContext;
        }

        public List<Plate> Get()
        {
            return _db.Plates.ToList();
        }

        public Plate Get(int id)
        {
            return _db.Plates.Find(id);
        }

        public List<Plate> GetByName(string name)
        {
            return _db.Plates.Where(x => x.Name.Contains(name)).ToList();
        }

        public bool Create(Plate plate)
        {
            try
            {
                _db.Plates.Add(plate);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Plate plate)
        {
            try
            {
                _db.Entry(plate).State = EntityState.Modified;
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
            var plate = _db.Plates.Find(id);
            if (plate != null) _db.Plates.Remove(plate);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
