using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Services;
using GeniusChuck.Newsletter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeniusChuck.Newsletter.Web.Controllers
{
    public class CategoriesController(ApplicationDbContext context, CategoryService categoryService) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly CategoryService _categoryService = categoryService;

        // GET: Categories
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        // GET: Categories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View(new CategoryCreateVM());
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.Exists(vm.Name))
                {
                    ModelState.AddModelError(nameof(CategoryCreateVM.Name), "Une catégorie de ce nom existe déjà!");
                    return View(vm);
                }

                _categoryService.Add(vm);
                TempData["Message"] = "Création en succès";

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(new CategoryEditVM()
            {
                Description = category.Description,
                Name = category.Name,
                Id = category.Id
            });
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryEditVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var isUpdated = _categoryService.Update(vm);
                if (!isUpdated)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = _categoryService.GetById(id.Value);
            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var isDeleted = _categoryService.Remove(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
