using MediatR;
using Pemex.Products.DAL.Model.Advertisement;
using Pemex.Products.Repository.CQRS.Advertisement.Commands;
using Pemex.Products.Repository.CQRS.Advertisement.Model;
using Pemex.Products.Repository.CQRS.Advertisement.Queries;
using Pemex.Products.Service.Interfaces;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pemex.Products.Service.Implementations
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IMediator _mediator;
        public AdvertisementService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Advertisement> CreateAdvertisementAsync(Advertisement newAdvertisement)
        {

            var newAdCommand = new CreateAdvertisementCommand.Command { advertisement = newAdvertisement };
            var newAd = await _mediator.Send(newAdCommand);
            return newAd;
        }

        public async Task<Advertisement> GetAdvertisementAsycn(Guid id)
        {
            var adQuery = new ReadAdvertisementQuery.Query { Id = id };
            var ad = await _mediator.Send(adQuery);
            return ad;
        }

        public async Task<Page<Advertisement>> GetAdvertisementPageAsync(AdvertisementPageQueryModel pageQuery)
        {
            var adPageQuery = new ReadAdvertisementPageListQuery.Query { query = pageQuery };
            var adPage = await _mediator.Send(adPageQuery);
            return adPage;
        }
    }
}
