using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pemex.Products.API.Model.Request;
using Pemex.Products.API.Model.Response;
using Pemex.Products.DAL.Model.Advertisement;
using Pemex.Products.DAL.Model.EmailNotification;
using Pemex.Products.Repository.CQRS.Advertisement.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AdvertisementRequestModel, Advertisement>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Price));

            CreateMap<Advertisement, AdvertisementResponseModel>()
                .ForMember(dest => dest.PictureBase64 , opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Price));

            CreateMap<AdvertisementPageRequestModel, AdvertisementPageQueryModel>()
                .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.MaxPrice))
                .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.MinPrice))
                .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
                .ForMember(dest => dest.SizePage, opt => opt.MapFrom(src => src.SizePage))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));


            CreateMap<ContactToAdminNotificationRequestModel, EmailNotification>()
                .ForMember(dest => dest.NameFrom, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmailFrom, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        }
    }

    //Custom Mappers
    public class MapperFormFileToByteArray : ITypeConverter<IFormFile, byte[]>
    {
        public byte[] Convert(IFormFile source, byte[] destination, ResolutionContext context)
        {
            var ms = new MemoryStream();
            source.OpenReadStream().CopyTo(ms);
            byte[] fileBytes = ms.ToArray();
            return fileBytes;
        }
    }

    public class MapperByteArrayToBase64String : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            return System.Convert.ToBase64String(source);
        }
    }
}
