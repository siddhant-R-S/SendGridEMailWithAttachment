using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Web;

internal class Program
{
    private static void Main(string[] args)
    {
         Execute().Wait();
        Console.WriteLine("Hello, World!");
    }

    static async Task Execute()
    {
        // API key should be stored in either keyvault or environment variables
        //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
        var apiKey = "test Key"; // provide your key from Send grid
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("siddhant602206@gmail.com", "Siddhant Ranjan");
        var subject = "Sending with SendGrid is Fun";
        var to = new EmailAddress("siddhant602@gmail.com", "Siddhant another email");
        var plainTextContent = "and easy to do anywhere, even with C#";
        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
       
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var bytes = File.ReadAllBytes("C:\\PRismHR\\Capture.PNG");
        var file = Convert.ToBase64String(bytes);
        msg.AddAttachment("Capture.PNG", file);
        var response = await client.SendEmailAsync(msg);
        Console.WriteLine(response.IsSuccessStatusCode);
    }
}