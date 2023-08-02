using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface ICategoryRepository
    {
        List<Category> GetCategories();
        string AddCategory(Category category);
        string UpdateCategory(Category category);
        string DeleteCategory(int id);
    }
}
