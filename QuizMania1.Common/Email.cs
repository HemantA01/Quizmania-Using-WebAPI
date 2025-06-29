using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace QuizMania1.Common
{
    public class Email
    {
        public static async Task RegistrationEmail(string ToUser, string ToUserEmailId, string ToUserName, string ToUserPassword)
        {
			try
			{
                var apikey = "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";
                //var apikey = "";
                var client = new SendGridClient(apikey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("colloquim456@gmail.com", "Sendgrid Registration Email"),
                    Subject = "Welcome to register into the Logic World.",
                    PlainTextContent = "",
                    HtmlContent = "<p><strong>Hello " + ToUser + ",</strong></p>" +
                    "<p>Welcome to join into the family of Logic World Education. We heartly welcome you to become the member of the Logic World and add to our world of cheerings.</p>" +
                    "<p>-----------------------------------------------</p>" +
                    "<p>Username: <strong>" + ToUserName + "</strong></p>" +
                    "<p>Password: <strong>" + ToUserPassword + "</strong></p>" +
                    "<p>------------------------------------------------</p>" +
                    "<p>Get ready and drive in a right way to access and sharpen your knowledge by exploring our world of education." +
                    "<p>In case of any query or support, kindly drop a mail to us at <b>customer.support@logicworld.com</b>. Our customer executives will reach to you within some moments to assist.</p>" +
                    "<p>&nbsp;</p>" +
                    "<p>Thanks & Regards,</p>" +
                    "<p>Logic World Team</p>"
                };
                msg.AddTo(new EmailAddress(ToUserEmailId, ToUser));
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
			catch (Exception ex)
			{
				throw;
			}
        }
    }
}
