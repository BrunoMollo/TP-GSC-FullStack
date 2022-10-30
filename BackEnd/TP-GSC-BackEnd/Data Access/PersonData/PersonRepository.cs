using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access.PersonData
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(LoanDBContext context) : base(context)
        {
        }
    }
}
