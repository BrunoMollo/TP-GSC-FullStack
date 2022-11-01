using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.PersonData;
using TP_GSC_BackEnd.Data_Access.ThingData;

namespace TP_GSC_BackEnd.Data_Access.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private readonly LoanDBContext _loanDBContext;
        public ICategoryRepository CategoryRepo { get ;private  set ; }
        public IPersonRepository PeopleRepo { get; private set; }
        public IThingsRepository ThingsRepo { get; private set; }

        public UnitOfWork(LoanDBContext loanDBContext)
        {
            this._loanDBContext = loanDBContext;

            CategoryRepo = new CategoryRepository(loanDBContext);
            PeopleRepo = new PersonRepository(loanDBContext);
            ThingsRepo = new ThingsRepository(loanDBContext);
        }

        public int Complete() => this._loanDBContext.SaveChanges();
        
    }
}
