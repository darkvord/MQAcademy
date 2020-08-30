using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MQAcademyWS.Model;
using System.Net;
using MQAcademyWS.Services;

namespace MQAcademyWS.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string Title { get; } = "Home";

        [BindProperty]
        public EmailMessage EmailMessageInfo { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task OnPost()
        {
            if (EmailMessageInfo.From.Trim().Length > 0)
            {
                var emailsvc = new EmailService();
                await emailsvc.SendEmail(EmailMessageInfo);

            }
        }

    }
}
