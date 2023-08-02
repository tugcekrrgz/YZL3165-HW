using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        ECommerceDbContext db=new ECommerceDbContext();
        public string AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return "Kategori Eklendi.";
        }

        public string DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return "Kategori Silindi.";
        }

        public List<Category> GetCategories()
        {
            var categories = db.Categories.ToList();
            return categories;
        }

        public string UpdateCategory(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
            return "Kategori Güncellendi.";
        }
    }
}
