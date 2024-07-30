using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestWeb.Services.Email
{
    public class EmailConfirm : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var Fmail = "bibosamer12@gmail.com"; // Replace with your email
            var Fpass = "nurc xwah mock pkbe"; // Replace with your app password

            var formattedHtmlMessage = $@"
        <html>
        <head>
            <style>
                /* Add CSS styles for better email presentation */
                body {{
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                    margin: 20px;
                    padding: 20px;
                    background-color: #f0f0f0;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    background-color: #ffffff;
                    padding: 20px;
                    border-radius: 5px;
                    box-shadow: 0 2px 5px rgba(0,0,0,0.1);
                }}
                h1 {{
                    color: #333333;
                    text-align: center;
                }}
                p {{
                    color: #666666;
                }}
                .footer {{
                    margin-top: 20px;
                    text-align: center;
                    color: #999999;
                }}
                .smiley {{
                    font-size: 24px;
                    text-align: center;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h1>Confirmation of Registration</h1>
                <p>Dear [Recipient Name],</p>
                <p>Thank you for registering with our application. <span class='smiley'>&#128512;</span></p> <!-- Smiley face -->
                <p>Please click the following link to confirm your registration:</p>
                <p><a href='{htmlMessage}'>{htmlMessage}</a></p>
                <p>If you did not request this registration, please disregard this email.</p>
                <div class='footer'>
                    <p>Best regards,<br>Your Application Team <span class='smiley'>&#128077;</span></p> <!-- Thumbs up -->
                </div>
            </div>
        </body>
        </html>";

            var theMsg = new MailMessage
            {
                From = new MailAddress(Fmail),
                Subject = subject,
                Body = formattedHtmlMessage,
                IsBodyHtml = true // Allow HTML content
            };
            theMsg.To.Add(email);

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential(Fmail, Fpass);
                smtpClient.EnableSsl = true; // Ensure SSL is enabled

                try
                {
                    await smtpClient.SendMailAsync(theMsg);
                }
                catch (SmtpException smtpEx)
                {
                    throw new InvalidOperationException("Could not send email due to SMTP issue.", smtpEx);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Could not send email due to an unexpected error.", ex);
                }
            }
        }

    }
}