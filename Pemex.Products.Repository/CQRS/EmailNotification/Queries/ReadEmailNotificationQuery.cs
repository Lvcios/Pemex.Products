using MediatR;
using Pemex.Products.DAL.Database;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pemex.Products.Repository.CQRS.EmailNotification.Queries
{
    public class ReadEmailNotificationQuery
    {
        public class Query : IRequest<DAL.Model.EmailNotification.EmailNotification>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, DAL.Model.EmailNotification.EmailNotification>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DAL.Model.EmailNotification.EmailNotification> Handle(Query request, CancellationToken cancellationToken)
            {
                Sql sql = new Sql().Where("id = @0", request.Id);
                return await _unitOfWork.DB.FirstOrDefaultAsync<DAL.Model.EmailNotification.EmailNotification>(sql);
            }
        }
    }
}
