using Microsoft.AspNetCore.Mvc;
using Crud.DataAccess.Data;
using Crud.Model;



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
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Insert mode
                return View();
            }

            // Update mode
            Info info = _db.infos.Find(id);

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
                    _db.infos.Add(info);
                    TempData["success"] = "Category inserted successfully!!!!!!!!!!!";
                }
                else
                {
                    // Update
                    _db.infos.Update(info);
                    TempData["success"] = "Category updated successfully!!!!!!!!!!!!!!!";
                }

                _db.SaveChanges();
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