using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.Newsletter.Web.Services
{
    public class CategoryService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public int Add(CategoryCreateVM vm)
        {
            var category = new Category()
            {
                Id = 0,
                Description = vm.Description,
                Name = vm.Name,
            };

            _context.Add(category);
            return _context.SaveChanges();
        }

        public bool Exists(string name)
        {
            return _context.Categories.Any(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<bool> AddAsync(CategoryCreateVM vm)
        {
            var category = new Category()
            {
                Id = 0,
                Description = vm.Description,
                Name = vm.Name,
            };

            _context.Add(category);
            // Ne pas utiliser les nombres pour savoir si un résultat est en succès ou non, préférer l'utilisation des booléans.
            // Dans le cas où une classe Repository serait utilisée, nous retournerions le nombre pour connaître le nombre de résultats total créée.
            return await _context.SaveChangesAsync() > 0;
        }

        // TODO: Cette fonction est problématique, car elle retourne directement une catégorie (classe provenant du namespace "Models")
        // TODO: Cette fonction devrait se nommer autrement et retourner un CategoryEditVM => Pour réussir cela, il faudrait créer une autre classe (DAO/Repository) qui s'occuperait des appels à la BD. Cette classe-ci ne s'occuperait alors que de la transformation du modèle vers un VM.
        public CategoryDetailsVM? GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is not null)
            {
                return new CategoryDetailsVM()
                {
                    CreatedAt = category.CreatedAt,
                    Description = category.Description,
                    Name = category.Name,
                    Id = category.Id
                };
            }
            return null;
        }

        // Utilisation d'un "ValueTask" et non "Task" pour des raisons de performances
        // Voir le lien suivant: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1
        // Voir aussi: https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/
        public async ValueTask<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public bool Update(CategoryEditVM vm)
        {
            try
            {
                _context.Update(new Category()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Categories.Any(e => e.Id == vm.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            // Ne pas utiliser les nombres pour savoir si un résultat est en succès ou non, préférer l'utilisation des booléans.
            return _context.SaveChanges() > 0;
        }

        public ICollection<CategoryDetailsVM> GetAll()
        {
            return _context.Categories.Select(x => new CategoryDetailsVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
            }).ToList();
        }

        public async Task<ICollection<CategoryDetailsVM>> GetAllAsync()
        {
            return await _context.Categories.Select(x => new CategoryDetailsVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();
        }

        public bool Remove(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }
    }
}
