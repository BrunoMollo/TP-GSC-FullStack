using TP_GSC_BackEnd.Data_Access.Generic;
using TP_GSC_BackEnd.Extension_Methods;

namespace TP_GSC_BackEnd.Entities
{
    public class Thing :PersistableEntity
    {
        public string? Description { get; set; }
        public Category? Category { get; set; }


        public DateTime CreationDate { get; set; }


        public Boolean hasValidDescription() {
            if (Description is not null && Description.Length.isBetweenExcluding(3, 100))
                return true;
            else
                return false;
        }
    }
}
