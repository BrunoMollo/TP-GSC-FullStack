using AutoMapper;
using System.Configuration;
using TP_GSC_BackEnd.Dto.Maping;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Dto.Maping
{
    public class DtoMapperProfile : Profile
    {
        
        public DtoMapperProfile()
        {
            CreateMap<Category, ShowCategoryDto>();
        }

     
    }
}
