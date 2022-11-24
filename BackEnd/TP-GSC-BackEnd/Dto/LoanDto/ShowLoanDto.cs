using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Dto.LoanDto
{
    public class ShowLoanDto
    {
        public int Id { get; set; }
        public ShowThingDto Thing { get; set; }
        public Person Person { get; set; }
     
        public string Status;
        public DateTime AgreedReturnDate { get; set; }
        public DateTime? RealReturnDate { get; set; }
        






    }   
}
