using MediatR;
using Pemex.Products.DAL.Database;
using Pemex.Products.Repository.CQRS.EmailNotification.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pemex.Products.Repository.CQRS.EmailNotification.Commands
{
    public class CreateNotificationCommand
    {
        public class Command: IRequest<DAL.Model.EmailNotification.EmailNotification>
        {
            public DAL.Model.EmailNotification.EmailNotification emailNotification { get; set; }
        }

        public class Handler : IRequestHandler<Command, DAL.Model.EmailNotification.EmailNotification>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;
            private static readonly string _sqlInsert = @"INSERT INTO public.email_notification(
	                            id, name_from, email_from, email_to, name_to, subject, message)
	                            VALUES (@0, @1, @2, @3, @4, @5, @6) returning id;";
            public Handler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }
            public async Task<DAL.Model.EmailNotification.EmailNotification> Handle(Command request, CancellationToken cancellationToken)
            {
                //lo intenté poner default en la base pero no me dejo crear permisos para utiilzar la extensión que crear los UUID
                /*
                 * CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
                 * SELECT uuid_generate_v4();
                 */
                request.emailNotification.Id = Guid.NewGuid();
                var newId = await _unitOfWork.DB.ExecuteScalarAsync<Guid>(_sqlInsert, request.emailNotification.Id
                    ,request.emailNotification.NameFrom
                    , request.emailNotification.EmailFrom
                    , request.emailNotification.EmailTo
                    , request.emailNotification.NameTo
                    , request.emailNotification.Subject
                    , request.emailNotification.Message);

                _unitOfWork.Commit();
                var emailNotificationQuery = new ReadEmailNotificationQuery.Query { Id = newId };
                var emailNotification= await _mediator.Send(emailNotificationQuery);
                return emailNotification;
            }
        }
    }
}
