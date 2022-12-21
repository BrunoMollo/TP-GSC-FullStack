using AutoMapper;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Dto
{
    public class DtoMapperProfile : Profile
    {

        public DtoMapperProfile()
        {
            CreateMap<Category, ShowCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Thing, ShowThingDto>();
            CreateMap<CreateThingDto, Thing>();

            CreateMap<Loan, ShowLoanDto>()
                .ForMember(dto => dto.Status, m => m.MapFrom(src => src.Status.Description));

               


        }


    }
}
