using System;
using System.Collections.Generic;
using GS = Global.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
using Client.Mappers;
using Client.Repositories;

namespace Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GS.CategoryService _categoryService;

        public CategoryService(GS.CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<Category> Get()
        {
            return _categoryService.Get().Select(category => category.ToClient());
        }

        public Category Get(int id)
        {
            return _categoryService.Get(id)?.ToClient();
        }
    }
}
