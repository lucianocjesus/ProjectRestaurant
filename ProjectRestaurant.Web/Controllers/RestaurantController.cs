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
        private readonly IRestaurantRepository _repository;

        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        [Route("lista")]
        public ActionResult Index()
        {
            var list = new List<RestaurantModelView>();
            var restaurantModel = _repository.Get();
            foreach (var item in restaurantModel)
            {
                var modelView = new RestaurantModelView();
                modelView.Id = item.Id;
                modelView.Name = item.Name;
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
            _repository.Create(restaurant);
            return RedirectToAction("Index");
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var restaurantModel = _repository.Get(id);
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
            if (_repository.Update(restaurantModel))
                return RedirectToAction("Index");

            return View(modelView);
        }

        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            var restaurantModel = _repository.Get(id);
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
            var restaurantModel = _repository.Get(id);
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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}