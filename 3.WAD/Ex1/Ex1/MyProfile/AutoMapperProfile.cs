using AutoMapper;
using Ex1.Data;
using Ex1.Models;

namespace Ex1.MyProfile
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<News, NewsDto>();
            CreateMap<NewsDto, News>();
        }
    }
}
