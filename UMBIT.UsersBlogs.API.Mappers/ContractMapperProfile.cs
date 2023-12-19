using AutoMapper;
using System.Linq;
using UMBIT.UsersBlogs.API.Contracts;

namespace UMBIT.UsersBlogs.API.Mappers
{
    public class ContractMapperProfile : Profile
    {
        public ContractMapperProfile()
        {


            CreateMap<UMBIT.UsersBlogs.Dominio.Entidades.Blog, Blog>()
                .ForMember(t => t.Updated_at, expr => expr.MapFrom(t => t.UpdatedAt))
                .ForMember(t => t.Created_at, expr => expr.MapFrom(t => t.CreatedAt))
                .ForMember(t => t.User_id, expr => expr.MapFrom(t => t.UserId))
                .ForMember(t => t.Content_text, expr => expr.MapFrom(t => t.ContentText))
                .ForMember(t => t.Content_html, expr => expr.MapFrom(t => t.ContentHtml))
                .ForMember(t => t.Photo_url, expr => expr.MapFrom(t => t.PhotoUrl))
                .ReverseMap();

            CreateMap<UMBIT.UsersBlogs.Dominio.Entidades.User, User>()
                .ForMember(t => t.First_name, expr => expr.MapFrom(t => t.FirstName))
                .ForMember(t => t.Date_of_birth, expr => expr.MapFrom(t => t.DateOfBirth))
                .ForMember(t => t.Last_name, expr => expr.MapFrom(t => t.LastName))
                .ForMember(t => t.Profile_picture, expr => expr.MapFrom(t => t.ProfilePicture))
                .ForMember(t => t.Blogs, expr => expr.MapFrom(t => t.Blogs.ToList()))
                .ReverseMap();
        }
    }
}
