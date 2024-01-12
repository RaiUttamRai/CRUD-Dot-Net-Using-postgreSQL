using Microsoft.AspNetCore.Mvc;
using Crud.DataAccess.Data;
using Crud.Model;
using Crud.DataAccess.Repository;

namespace Crud.Controllers
{
    public class InfoController : Controller
    {
        private readonly ICrudRepository _crudRepository;
        private object?[]? id;
        public InfoController(ICrudRepository db)
        {
            _crudRepository = db;
        }
        public IActionResult Index()
        {
            List<Info> list =  _crudRepository.GetAll().ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Insert mode
                return View();
            }

            // Update mode
            Info info = _crudRepository.Get(u=>u.id== id);  

            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        [HttpPost]
        public IActionResult Upsert(Info info)
        {
            if (ModelState.IsValid)
            {
                if (info.id == 0)
                {
                    // Insert
                    _crudRepository.Add(info);
                    TempData["success"] = "Category inserted successfully!!!!!!!!!!!";
                }
                else
                {
                    // Update
                   _crudRepository.Update(info);
                    TempData["success"] = "Category updated successfully!!!!!!!!!!!!!!!";
                }

                _crudRepository.Save();
                return RedirectToAction("Index");
            }

            return View(info);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Info delete =  _crudRepository.Get(u=>u.id== id);   
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

            Info infoToDelete = _crudRepository.Get(u=> u.id== id); 

            if (infoToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _crudRepository.Remove(infoToDelete);
                _crudRepository.Save();
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