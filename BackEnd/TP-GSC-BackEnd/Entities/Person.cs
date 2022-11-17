using TP_GSC_BackEnd.Data_Access.Generic;

namespace TP_GSC_BackEnd.Entities
{
    public class Person : PersistableEntity
    {
        public String? Name { get; set; }

        public String? PhoneNumber { get; set; }

        public String? Email { get; set; }

    }
}
