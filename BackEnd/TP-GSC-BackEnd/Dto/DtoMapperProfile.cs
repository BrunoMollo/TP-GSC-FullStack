using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;
using TP_GSC_BackEnd.Protos;

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


            CreateMap<NewLoanRequest, CreateLoanDto>()
                .ForMember(dto => dto.AgreedReturnDate, m => m.MapFrom(src => src.AgreedReturnDate.ToDateTime()));
               


        }


    }
}
