using MediatR;
using Microsoft.Extensions.Logging;
using Pemex.Products.DAL.Database;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pemex.Products.Repository.CQRS.Advertisement.Queries
{
    public class ReadAdvertisementQuery
    {
        public class Query:IRequest<DAL.Model.Advertisement.Advertisement>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, DAL.Model.Advertisement.Advertisement>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<ReadAdvertisementQuery> _logger;

            public Handler(IUnitOfWork unitOfWork, ILogger<ReadAdvertisementQuery> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public async Task<DAL.Model.Advertisement.Advertisement> Handle(Query request, CancellationToken cancellationToken)
            {
                Sql sql = new Sql().Where("id = @0", request.Id);
                return await _unitOfWork.DB.FirstOrDefaultAsync<DAL.Model.Advertisement.Advertisement>(sql);
            }
        }
    }
}
