using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.PersonData;
using TP_GSC_BackEnd.Data_Access.ThingData;

namespace TP_GSC_BackEnd.Data_Access.Uow
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepo { get; }
        public IPersonRepository PeopleRepo { get; }
        public IThingsRepository ThingsRepo { get; }

        public int SaveChanges();

    }
}
