using Pemex.Products.DAL.Model.EmailNotification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pemex.Products.Service.Interfaces
{
    public interface IEmailNotificationService
    {
        Task<EmailNotification> SendEmailToAdmin(EmailNotification emailNotification);
    }
}
