namespace CrawlerApp.Application.Common.Models.Crawler
{
    public class CrawlerLogDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTimeOffset SentOn { get; set; }

        public CrawlerLogDto(string message)
        {
            Id = Guid.NewGuid();
            Message = message;
            SentOn = DateTimeOffset.Now;
        }
    }
}
