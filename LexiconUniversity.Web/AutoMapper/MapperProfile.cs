using AutoMapper;
using LexiconUniversity.Core;
using LexiconUniversity.Web.Models;

namespace LexiconUniversity.Web.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap <Student, StudentIndexViewModel>();
        }
    }
}
