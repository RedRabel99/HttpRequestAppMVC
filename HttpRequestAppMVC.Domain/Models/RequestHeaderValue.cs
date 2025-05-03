namespace HttpRequestAppMVC.Domain.Models
{
    public class RequestHeaderValue : BaseEntity
    {
        public string Header { get; set; }
        public string Value { get; set; }
        public Guid HttpRequestId { get; set; }
        public virtual HttpRequest HttpRequest { get; set; }
    }
}