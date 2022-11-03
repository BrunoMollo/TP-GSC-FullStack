using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TP_GSC_BackEnd.Data_Access.Generic;
using TP_GSC_BackEnd.Extension_Methods;

namespace TP_GSC_BackEnd.Entities
{

    public class Category : PersistableEntity
    {

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public Category(string description) { 
            this.Description = description;
        }


        public bool hasValidDescription() 
        {
            if (Description.Length.isBetweenExcluding(2, 100))
                return true;
            else
                return false;
        }

        public bool hasInvalidDescription() => !hasValidDescription();

    }
}
