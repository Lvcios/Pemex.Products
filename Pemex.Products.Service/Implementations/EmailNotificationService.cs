using MediatR;
using Pemex.Products.DAL.Model.EmailNotification;
using Pemex.Products.Repository.CQRS.EmailNotification.Commands;
using Pemex.Products.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pemex.Products.Service.Implementations
{
    public class EmailNotificationService : IEmailNotificationService
    {

        private readonly IMediator _mediator;
        public EmailNotificationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<EmailNotification> SendEmailToAdmin(EmailNotification emailNotification)
        {
            emailNotification.EmailTo = "angello_dm@hotmail.com"; //hardcodeado por falta de tiempo, la idea es que se obtenga de la configuración del app
            emailNotification.NameTo = "Angello DM"; //mismo comentario. Dependiendo de la notificación se podría obtener de otro comando o configuración
            emailNotification.Subject = "SE RECIBIO UN COMENTARIO DESDE EL SISTEMA DE ANUNCIOS EMPRESARIALES CON LA SIGUIENTE INFORMACÓN DE CONTACTO";
            var emailNotificationCommand = new CreateNotificationCommand.Command { emailNotification  = emailNotification };
            var newEmailNotification = await _mediator.Send(emailNotificationCommand);
            return newEmailNotification;
        }
    }
}
