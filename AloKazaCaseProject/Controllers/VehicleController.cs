using AloKazaCaseProject.Core.Entities;
using AloKazaCaseProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AloKazaCaseProject.Controllers
{
    public class VehicleController : Controller
    {
        // GET: VehicleController

        private readonly IUnitOfWork _unitOfWork;

        // DEPENDENCY INJECTION
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetVehicle()
        {
            var vehicles = await _unitOfWork.Vehicles.GetAll();
            return Json(vehicles);
        }
        // GET: VehicleController/Details/5
        public async Task<JsonResult> DetailsAsync(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(id);
            return Json(vehicle);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(Vehicle vehicle)
        {
            bool add = await _unitOfWork.Vehicles.Add(vehicle);
            return Json(add);
        }
        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(int id, Vehicle vehicle)
        {
            var p = await _unitOfWork.Vehicles.GetById(id);

            if(p == null)
                return Json(NotFound());

            bool update = await _unitOfWork.Vehicles.Update(vehicle);

            return Json(update);
        }
        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var p = await _unitOfWork.Vehicles.GetById(id);

            if(p == null)
                return Json(NotFound());

            bool delete = await _unitOfWork.Vehicles.Remove(id);

            return Json(delete);
        }
    }
}
