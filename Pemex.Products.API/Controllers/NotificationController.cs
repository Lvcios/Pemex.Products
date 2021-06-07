using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pemex.Products.API.Model.Request;
using Pemex.Products.DAL.Model.EmailNotification;
using Pemex.Products.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotificationController : ControllerBase
    {
        private IEmailNotificationService _emailNotificationService;
        private readonly IMapper _mapper;

        public NotificationController(IEmailNotificationService emailNotificationService, IMapper mapper)
        {
            _emailNotificationService = emailNotificationService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("sendToAdmin")]
        public async Task<IActionResult> SendEmailNotification([FromForm]ContactToAdminNotificationRequestModel request)
        {
            var notification = _mapper.Map<EmailNotification>(request);
            var newNotification = await _emailNotificationService.SendEmailToAdmin(notification);
            return Ok(newNotification);
        }
    }
}
