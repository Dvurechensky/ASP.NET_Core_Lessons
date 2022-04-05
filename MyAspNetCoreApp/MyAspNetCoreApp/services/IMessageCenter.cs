using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.services
{

    public class MessageMiddleware
    {
        public MessageMiddleware(RequestDelegate next)
        {

        }

        public async Task InvokeAsync(HttpContext context, MessageService sender)
        {
            await context.Response.WriteAsync(sender.SendMessage());
        }
    }

    public class MessageService
    {
        IMessageSender sender;
        public MessageService(IMessageSender sender)
        {
            this.sender = sender;
        }

        public string SendMessage() => sender.Send();
    }

    public interface IMessageSender
    {
        string Send();
    }

    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is send by Email";
        }
    }

    public class SmsMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is send by Sms";
        }
    }

}
