using System.Collections.Generic;
using System.Web.Mvc;
using ProjectRestaurant.Domain;
using ProjectRestaurant.Domain.Repositories.Contracts;
using ProjectRestaurant.Web.Models;

namespace ProjectRestaurant.Web.Controllers
{
    [RoutePrefix("restaurantes")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IPlateRepository _plateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantController(IRestaurantRepository restaurantRepository, IPlateRepository plateRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _plateRepository = plateRepository;
            _unitOfWork = unitOfWork;
        }

        [Route("lista")]
        public ActionResult Index()
        {
            var list = new List<RestaurantModelView>();
            var restaurantModel = _restaurantRepository.Get();
            foreach (var item in restaurantModel)
            {
                var modelView = new RestaurantModelView
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(modelView);
            }
            return View(list);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var restaurantView = new EditRestaurantModelView
            {
                Id = 0,
                Name = "",
                Details = ""
            };
            return View(restaurantView);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditRestaurantModelView modelView)
        {
            if (!ModelState.IsValid)
            {
                var edit = new EditRestaurantModelView { Name = modelView.Name, Details = modelView.Details };
                return View(edit);
            }
            var restaurant = new Restaurant { Name = modelView.Name, Details = modelView.Details };
            _restaurantRepository.Create(restaurant);
            return RedirectToAction("Index");
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var restaurantModel = _restaurantRepository.Get(id);
            var restaurantView = new EditRestaurantModelView
            {
                Id = restaurantModel.Id,
                Name = restaurantModel.Name,
                Details = restaurantModel.Details
            };
            return View(restaurantView);
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(EditRestaurantModelView modelView)
        {
            var restaurantModel = new Restaurant { Id = modelView.Id, Name = modelView.Name, Details = modelView.Details };
            if (_restaurantRepository.Update(restaurantModel))
                return RedirectToAction("Index");

            return View(modelView);
        }

        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            var restaurantModel = _restaurantRepository.Get(id);
            var restaurantView = new EditRestaurantModelView
            {
                Id = restaurantModel.Id,
                Name = restaurantModel.Name,
                Details = restaurantModel.Details
            };
            return View(restaurantView);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var restaurantModel = _restaurantRepository.Get(id);
            var restaurantView = new EditRestaurantModelView
            {
                Id = restaurantModel.Id,
                Name = restaurantModel.Name,
                Details = restaurantModel.Details
            };
            return View(restaurantView);
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _unitOfWork.DeletePlatesAndRestaurant(id);
            return RedirectToAction("Index");
        }
    }
}