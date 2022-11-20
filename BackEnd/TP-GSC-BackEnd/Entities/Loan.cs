using TP_GSC_BackEnd.Data_Access.Generic;

namespace TP_GSC_BackEnd.Entities
{

    public class Loan : PersistableEntity
    {
        public Thing Thing { get; set; }
        public Person Person { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime AgreedReturnDate { get; set; }
        public DateTime? RealReturnDate { get; set; }

        public LoanStatus Status { 
            get{
                if (RealReturnDate is null)
                {
                    if (DateTime.Now <= AgreedReturnDate)
                        return LoanStatus.PENDING;
                    else
                        return LoanStatus.UNCOMPLETED_LATE;
                }
                else {
                    if (RealReturnDate <= AgreedReturnDate)
                        return LoanStatus.COMPLETED_ON_TERM;
                    else
                        return LoanStatus.COMPLETED_LATE;
                }   
            } 
        }





    }
}
