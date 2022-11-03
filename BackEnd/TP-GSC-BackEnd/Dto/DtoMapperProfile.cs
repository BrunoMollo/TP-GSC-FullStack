using AutoMapper;
using System.Configuration;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Dto
{
    public class DtoMapperProfile : Profile
    {

        public DtoMapperProfile()
        {
            CreateMap<Category, ShowCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }


    }
}
