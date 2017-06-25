using ProjectRestaurant.Domain.Repositories.Contracts;
using ProjectRestaurant.Infra.Contexts;

namespace ProjectRestaurant.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IPlateRepository _plateRepository;
        private readonly RestaurantDataContext _db;

        public UnitOfWork(IRestaurantRepository restaurantRepository, IPlateRepository plateRepository, RestaurantDataContext dataContext)
        {
            _restaurantRepository = restaurantRepository;
            _plateRepository = plateRepository;
            _db = dataContext;
        }

        public void DeletePlatesAndRestaurant(int id)
        {
            var restaurantModel = _restaurantRepository.GetPlateByRestaurant(id);
            foreach (var plate in restaurantModel.Plates)
            {
                _plateRepository.Delete(plate.Id);
            }
            _restaurantRepository.Delete(id);
        }

        public void DeletePlate(int id)
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
