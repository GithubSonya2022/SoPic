namespace SoPic.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SoPic.Data;
    using SoPic.Data.Models;
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GenresController : Controller
    {
        
        private readonly ApplicationDbContext db;

        public GenresController(ApplicationDbContext context)
        {
            this.db = context;
        }
        // GET: Genres
        public IActionResult Index()
        {

            return View(db.Genres.ToList());
        }

        // GET: Genres/Details/5
        public IActionResult Details(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var genre = db.Genres
                .Include(g => g.Photo)
                .FirstOrDefault(m => m.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        // GET: Genres/Create
        [Authorize]
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind("Title,Id")] Genre genre)
        {
            
            if (ModelState.IsValid)
            {
                genre.Id = Guid.NewGuid();
                db.Add(genre);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        // GET: Genres/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title,Id")] Genre genre)
        {

            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(genre);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var genre = db.Genres
                .FirstOrDefault(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(Guid id)
        {
            return db.Genres.Any(e => e.Id == id);
        }

        // GET: Photos/Buy
        [Authorize]
        public IActionResult Buy(Guid? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var Photo = db.Photos.Find(id);
            if (Photo == null)
            {
                return NotFound();
            }
            Photo.PurchseDate = DateTime.Now;
            ViewData["GenreId"] = new SelectList(db.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

        // POST: Photos/Buy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(Guid id, [Bind("Title,ImageUrl,GenreId,Id, Price, Description, BuyerName, BuyerAddress, BuyerPhone, PurchseDate")] Photo Photo)
        {
            
            if (id != Photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Photo);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(Photo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(db.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }
        private bool PhotoExists(Guid id)
        {
            return db.Photos.Any(e => e.Id == id);
        }
    }
}
