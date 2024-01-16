using Microsoft.AspNetCore.Mvc;
using Crud.DataAccess.Data;
using Crud.Model;
using Crud.DataAccess.Repository;
using Crud.DataAccess.UnitOfWork;
using Crud.Model.InfoViewModel;

namespace Crud.Controllers
{
    public class InfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private object?[]? id;
        public InfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ;
        }
        public IActionResult Index()
        {
            List<InfoVM> infoViewModel = _unitOfWork.Info.GetAll()
                .Select(info => new InfoVM { Info = info })
                .ToList();

            return View(infoViewModel); // Pass the infoViewModel to the view
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Insert mode
                InfoVM newInfoViewModel = new InfoVM();
                return View(newInfoViewModel);
            }

            // Update mode
            Info info = _unitOfWork.Info.Get(u=>u.id== id);  

            if (info == null)
            {
                return NotFound();
            }

            InfoVM existingInfoVM = new InfoVM();
            return View(existingInfoVM);
        }

        [HttpPost]
        public IActionResult Upsert(InfoVM  infoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (infoViewModel.Info.id == 0)
                {
                    // Insert
                    _unitOfWork.Info.Add(infoViewModel.Info);
                    TempData["success"] = "Category inserted successfully!!!!!!!!!!!";
                }
                else
                {
                    // Update
                   _unitOfWork.Info.Update(infoViewModel.Info);
                    TempData["success"] = "Category updated successfully!!!!!!!!!!!!!!!";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(infoViewModel);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Info delete = _unitOfWork.Info.Get(u=>u.id== id);   
            if (delete == null)
            {
                return NotFound();
            }
            return View(delete);
        }
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Info infoToDelete = _unitOfWork.Info.Get(u=> u.id== id); 

            if (infoToDelete == null)
            {
                return NotFound();
            }

            try
            {
                 _unitOfWork.Info.Remove(infoToDelete);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle any potential exception that occurred during deletion.
                // Log the exception or return an error view, if needed.
                return RedirectToAction("Error", "Home"); // Redirect to an error page.
            }
        }



    }
}