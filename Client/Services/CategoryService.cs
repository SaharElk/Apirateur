using System;
using System.Collections.Generic;
using GR = Global.Repositories;
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
        private readonly GR.ICategoryRepository _categoryRepository;

        public CategoryService(GR.ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get().Select(category => category.ToClient());
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id)?.ToClient();
        }
    }
}
