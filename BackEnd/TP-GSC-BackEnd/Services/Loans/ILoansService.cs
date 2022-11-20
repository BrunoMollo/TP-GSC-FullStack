using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Services.Loans
{
    public interface ILoansService
    {
        public ServiceResult<Loan> create(CreateLoanDto dto); 
            
        
       


    }
}
