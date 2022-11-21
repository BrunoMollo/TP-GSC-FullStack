using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access.LoanData
{
    public class LoansRepository : Repository<Loan>, ILoansRepository
    {
        public LoansRepository(LoanDBContext context) : base(context)
        {
        }

        public override Loan? GetOne(int id)
        {
            return context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .FirstOrDefault(l => l.Id == id);
        }


        public List<Loan> GetPendingLoans()
        {
            return this.context.Loans
                .Where(l => l.RealReturnDate == null)
                .Include(l=>l.Thing)
                .Include(l=>l.Person)
                .ToList();
        }
    }
}
