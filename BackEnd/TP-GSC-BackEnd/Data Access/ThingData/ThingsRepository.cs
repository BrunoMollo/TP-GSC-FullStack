using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access.ThingData
{
    public class ThingsRepository : Repository<Thing>, IThingsRepository
    {
        public ThingsRepository(LoanDBContext context) : base(context)
        {
        }

        public override List<Thing> GetAll()
        {
            return dbSet.Include(t=>t.Category).ToList();
        }
    }
}
