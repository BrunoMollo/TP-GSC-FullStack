namespace TP_GSC_BackEnd.Entities
{
    public record class LoanStatus
    {
        public static readonly LoanStatus PENDING = new LoanStatus(nameof(PENDING));
        public static readonly LoanStatus COMPLETED_ON_TERM = new LoanStatus(nameof(COMPLETED_ON_TERM));
        public static readonly LoanStatus COMPLETED_LATE= new LoanStatus(nameof(COMPLETED_LATE));
        public static readonly LoanStatus UNCOMPLETED_LATE = new LoanStatus(nameof(UNCOMPLETED_LATE));

        public string Description { get; set; }
        private LoanStatus(string description) { 
            this.Description = description;
        }


    }
}
