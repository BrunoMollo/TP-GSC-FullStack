using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access.LoanData
{
    public interface ILoansRepository: IRepository<Loan>
    {
        public List<Loan> GetPendingLoans();


    }
}
