using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Crud.Controllers
{
    public class InfoController : Controller
    {


        private readonly ApplicationDbContext _db;
        private object?[]? id;
        public InfoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Info> list = _db.infos.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Info info)
        {
            _db.infos.Add(info);
            _db.SaveChanges();
            TempData["success"] = "Category inserted successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if(id==0 || id==null)
            {
                return NotFound();
            }
            Info edit = _db.infos.Find(id);
            if(edit ==null)
            {
               return NotFound();
            }
            return View(edit);  
        }
        [HttpPost]
        public IActionResult Edit(Info info)
        {
            if(ModelState.IsValid)
            {
                _db.infos.Update(info);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");   
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Info delete = _db.infos.Find(id);
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

            Info infoToDelete = _db.infos.Find(id);

            if (infoToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _db.infos.Remove(infoToDelete);
                _db.SaveChanges();
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