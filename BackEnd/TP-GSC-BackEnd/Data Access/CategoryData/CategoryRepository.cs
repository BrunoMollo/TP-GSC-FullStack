using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access.CategoryData
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LoanDBContext context) : base(context)
        {
        }
    }
}
