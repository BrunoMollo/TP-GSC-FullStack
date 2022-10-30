using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.Generic;

namespace TP_GSC_BackEnd.Entities
{

    public class Category : PersistableEntity
    {

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public Category(string description) { 
            this.Description = description;
        }

    }
}
