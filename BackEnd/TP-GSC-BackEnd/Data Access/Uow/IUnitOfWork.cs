using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.PersonData;

namespace TP_GSC_BackEnd.Data_Access.Uow
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepo { get; }
        public IPersonRepository PeopleRepo { get; }

        public int Complete();

    }
}
