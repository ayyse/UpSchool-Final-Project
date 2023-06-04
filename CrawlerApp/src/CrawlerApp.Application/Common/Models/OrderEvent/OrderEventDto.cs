using CrawlerApp.Domain.Enums;

namespace CrawlerApp.Application.Common.Models.OrderEvent
{
    public class OrderEventDto
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        //public OrderStatus Status { get; set; }
        public DateTimeOffset SentOn { get; set; }

        public OrderEventDto(DateTimeOffset sentOn, string message)
        {
            SentOn = sentOn;
            Message = message;
        }

        //public OrderEventDto(DateTimeOffset sentOn, string message)
        //{
        //    SentOn = sentOn;
        //    Message = message;
        //}
    }
}
