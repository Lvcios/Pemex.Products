using MediatR;
using Pemex.Products.DAL.Database;
using Pemex.Products.Repository.CQRS.Advertisement.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pemex.Products.Repository.CQRS.Advertisement.Commands
{
    public class CreateAdvertisementCommand
    {
        public class Command : IRequest<DAL.Model.Advertisement.Advertisement>
        {
            public DAL.Model.Advertisement.Advertisement advertisement { get; set; }
        }

        public class Handler : IRequestHandler<Command, DAL.Model.Advertisement.Advertisement>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;
            private static readonly string _sqlInsert = @"INSERT INTO public.advertisement(id, title, type_ad, price, image)
	                                        VALUES (@0, @1, @2, @3, @4) returning id";


            //todo: add fluent validation
            public Handler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }

            public async Task<DAL.Model.Advertisement.Advertisement> Handle(Command request, CancellationToken cancellationToken)
            {
                request.advertisement.Id = Guid.NewGuid();
                var newId = await _unitOfWork.DB.ExecuteScalarAsync<Guid>(_sqlInsert, request.advertisement.Id,
                        request.advertisement.Title,
                        request.advertisement.Type,
                        request.advertisement.Price,
                        request.advertisement.Image);
                _unitOfWork.Commit();
                _unitOfWork.DB.CloseSharedConnection();
                var advertisementQuery = new ReadAdvertisementQuery.Query { Id = newId };
                var advertisement = await _mediator.Send(advertisementQuery);
                return advertisement;
            }
        }
    }
}
