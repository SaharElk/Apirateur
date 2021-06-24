using Client.Data;
using System.Collections.Generic;

namespace Client.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
    }
}