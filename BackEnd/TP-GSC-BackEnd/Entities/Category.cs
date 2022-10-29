using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_GSC_BackEnd.Entities
{

    public class Category 
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public Category(string desc) { 
            this.Description = desc;
        }

    }
}
