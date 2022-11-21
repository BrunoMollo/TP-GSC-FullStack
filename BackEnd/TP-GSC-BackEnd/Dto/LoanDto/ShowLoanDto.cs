using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Dto.LoanDto
{
    public class ShowLoanDto
    {
        public ShowThingDto Thing { get; set; }
        public Person Person { get; set; }
        public DateTime AgreedReturnDate { get; set; }
        public DateTime? RealReturnDate { get; set; }
        
        public LoanStatus Status;






    }   
}
