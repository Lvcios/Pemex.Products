using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pemex.Products.Repository.CQRS.Advertisement.Model;
using PetaPoco;

namespace Pemex.Products.Service.Interfaces
{
    public interface IAdvertisementService
    {
        Task<DAL.Model.Advertisement.Advertisement> GetAdvertisementAsycn(Guid id);
        Task<Page<DAL.Model.Advertisement.Advertisement>> GetAdvertisementPageAsync(AdvertisementPageQueryModel pageQuery);
        Task<DAL.Model.Advertisement.Advertisement> CreateAdvertisementAsync(DAL.Model.Advertisement.Advertisement newAdvertisement);
    }
}
