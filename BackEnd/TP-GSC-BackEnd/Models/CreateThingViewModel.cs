using TP_GSC_BackEnd.Dto.CategotyDto;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32.SafeHandles;

namespace TP_GSC_BackEnd.Models
{
    public class CreateThingViewModel
    {

        public List<ShowCategoryDto> Categories=new List<ShowCategoryDto>();


        [Required(ErrorMessage = "Description is requiered")]
        [MinLength(3,ErrorMessage ="Should have more then 3 letters")]
        [MaxLength(99, ErrorMessage = "Can't have more then 100 letterns")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is requiered")]
        public int CategoryId { get; set; }

    }
}
