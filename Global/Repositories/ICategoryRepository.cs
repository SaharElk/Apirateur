using Global.Data;
using System.Collections.Generic;

namespace Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
    }
}