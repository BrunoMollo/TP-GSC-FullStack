using TP_GSC_BackEnd.Dto.CategotyDto;

namespace TP_GSC_BackEnd.Dto.ThingDto
{
    public class ShowThingDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public ShowCategoryDto Category { get; set; }

        public ShowThingDto()
        {
            Category = new ShowCategoryDto();
        }
    }
}
