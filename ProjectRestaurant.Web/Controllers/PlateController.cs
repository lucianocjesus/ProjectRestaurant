using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectRestaurant.Domain;
using ProjectRestaurant.Domain.Repositories.Contracts;
using ProjectRestaurant.Web.Models;

namespace ProjectRestaurant.Web.Controllers
{
    [RoutePrefix("pratos")]
    public class PlateController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IPlateRepository _plateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlateController(IRestaurantRepository restaurantRepository, IPlateRepository plateRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _plateRepository = plateRepository;
            _unitOfWork = unitOfWork;
        }

        [Route("lista")]
        public ActionResult Index()
        {
            var list = new List<PlateModelView>();
            var placeModel = _plateRepository.Get();
            foreach (var item in placeModel)
            {
                var modelView = new PlateModelView
                {
                    Id = item.Id,
                    RestaurantId = item.RestaurantId,
                    NamePlate = item.Name,
                    NameRestaurant = _restaurantRepository.Get(item.RestaurantId).Name,
                    Ingredients = item.Ingredients
                };
                list.Add(modelView);
            }
            return View(list);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var restaurant = _restaurantRepository.Get();
            var plateView = new EditPlateModelView
            {
                Id = 0,
                NamePlate = "",
                Ingredients = "",
                RestaurantId = 0,
                RestaurantOptions = new SelectList(restaurant, "Id", "Name")
            };
            return View(plateView);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditPlateModelView modelView)
        {
            if (!ModelState.IsValid)
            {
                var restaurant = _restaurantRepository.Get();
                modelView.RestaurantOptions = new SelectList(restaurant, "Id", "Name");
                return View(modelView);
            }

            var plate = new Plate
            {
                Id = modelView.Id,
                Name = modelView.NamePlate,
                Ingredients = modelView.Ingredients,
                RestaurantId = modelView.RestaurantId
            };
            try
            {
                _plateRepository.Create(plate);
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("message", ex.Message);
                var restaurant = _restaurantRepository.Get();
                modelView.RestaurantOptions = new SelectList(restaurant, "Id", "Name");
                return View(modelView);
            }
            return RedirectToAction("Index");

        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var restaurant = _restaurantRepository.Get();
            var plate = _plateRepository.Get(id);
            var plateView = new EditPlateModelView
            {
                Id = plate.Id,
                NamePlate = plate.Name,
                Ingredients = plate.Ingredients,
                RestaurantId = plate.RestaurantId,
                RestaurantOptions = new SelectList(restaurant, "Id", "Name")
            };
            return View(plateView);
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(EditPlateModelView modelView)
        {
            var plate = new Plate
            {
                Id = modelView.Id,
                Name = modelView.NamePlate,
                RestaurantId = modelView.RestaurantId,
                Ingredients = modelView.Ingredients
            };
            if (_plateRepository.Update(plate))
                return RedirectToAction("Index");

            return View(modelView);


        }

        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            var restaurant = _restaurantRepository.Get();
            var plate = _plateRepository.Get(id);
            var plateView = new EditPlateModelView
            {
                Id = plate.Id,
                NamePlate = plate.Name,
                Ingredients = plate.Ingredients,
                RestaurantId = plate.RestaurantId,
                NameRestaurant = _restaurantRepository.Get(plate.RestaurantId).Name,
                RestaurantOptions = new SelectList(restaurant, "Id", "Name")
            };
            return View(plateView);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var plateModel = _plateRepository.Get(id);
            var plateView = new EditPlateModelView
            {
                Id = plateModel.Id,
                NamePlate = plateModel.Name,
                Ingredients = plateModel.Ingredients,
                RestaurantId = plateModel.RestaurantId
            };
            return View(plateView);
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _plateRepository.Delete(id);
            _unitOfWork.DeletePlate(id);
            return RedirectToAction("Index");
        }
    }
}