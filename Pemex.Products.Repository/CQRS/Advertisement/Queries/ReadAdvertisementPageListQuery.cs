using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Pemex.Products.DAL.Database;
using Pemex.Products.Repository.CQRS.Advertisement.Model;
using PetaPoco;

namespace Pemex.Products.Repository.CQRS.Advertisement.Queries
{
    public class ReadAdvertisementPageListQuery
    {
        public class Query : IRequest<Page<DAL.Model.Advertisement.Advertisement>>
        {
            public AdvertisementPageQueryModel query { get; set; }
        }

        public class Handler : IRequestHandler<Query, Page<DAL.Model.Advertisement.Advertisement>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<ReadAdvertisementPageListQuery> _logger;

            public Handler(IUnitOfWork unitOfWork, ILogger<ReadAdvertisementPageListQuery> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public async Task<Page<DAL.Model.Advertisement.Advertisement>> Handle(Query query, CancellationToken cancellationToken)
            {
                var validator = new Validator();
                validator.ValidateAndThrow(query);
                Sql sql = new Sql();
                if (!string.IsNullOrEmpty(query.query.Title)) sql = sql.Where("title LIKE @0 ", $"%{query.query.Title}%");
                if (!string.IsNullOrEmpty(query.query.Type)) sql = sql.Where("type_ad = @0 ", query.query.Type);
                if(query.query.MinPrice >= 0 && query.query.MaxPrice > 0)
                {
                    sql = sql.Where("price between @0 and @1 ", query.query.MinPrice, query.query.MaxPrice);
                }
                else if(query.query.MinPrice >= 0 && query.query.MaxPrice == 0)
                {
                    sql = sql.Where("price >= @0 ", query.query.MinPrice);
                }
                else if (query.query.MinPrice == 0 && query.query.MaxPrice > 0)
                {
                    sql = sql.Where("price <= @0 ", query.query.MaxPrice);
                }
                //Sql sql = new Sql().Where("id = @0", request.Id);
                return await _unitOfWork.DB.PageAsync<DAL.Model.Advertisement.Advertisement>(query.query.Page, query.query.SizePage, sql);
            }
        }

        //Podemos usar FluentValidation para validar el input en caso donde la consulta se ejecuta en el mismo backend, ejemplo ejecutar la consulta desde otro command o servicio. 
        //En esos casos no podemos usar Data Annotations pero podemo' usar FluetnValidation
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.query.MinPrice).GreaterThanOrEqualTo(0);
                RuleFor(x => x.query.MaxPrice).GreaterThanOrEqualTo(x => x.query.MinPrice);
            }
        }
    }
}
