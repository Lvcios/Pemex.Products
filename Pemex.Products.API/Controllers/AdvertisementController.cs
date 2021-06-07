using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pemex.Products.API.Model.Request;
using Pemex.Products.API.Model.Response;
using Pemex.Products.DAL.Model.Advertisement;
using Pemex.Products.Repository.CQRS.Advertisement.Model;
using Pemex.Products.Repository.CQRS.Advertisement.Queries;
using Pemex.Products.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IMapper _mapper;
        public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNewAdvertisement([FromForm] AdvertisementRequestModel advertisementRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return BadRequest(errors);
            }

            Advertisement newAd = _mapper.Map<Advertisement>(advertisementRequest);
            var ad = await _advertisementService.CreateAdvertisementAsync(newAd);
            AdvertisementResponseModel response = _mapper.Map<AdvertisementResponseModel>(ad);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAdvertisement(Guid id)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return BadRequest(errors);
            }

            var ad = await _advertisementService.GetAdvertisementAsycn(id);
            AdvertisementResponseModel response = _mapper.Map<AdvertisementResponseModel>(ad);
            return Ok(response);
        }

        [HttpGet]
        [Route("page")]
        public async Task<IActionResult> GetAdvertisementPage([FromQuery] AdvertisementPageRequestModel pageRequest)
        {
            var pageQueryModel = _mapper.Map<AdvertisementPageQueryModel>(pageRequest);
            var page = await _advertisementService.GetAdvertisementPageAsync(pageQueryModel);

            return Ok(page);
        }
    }
}
