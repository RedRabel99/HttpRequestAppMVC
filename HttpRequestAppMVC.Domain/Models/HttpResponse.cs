namespace HttpRequestAppMVC.Domain.Models;

public class HttpResponse : BaseEntity
{
    public int StatusCode { get; set; }
    public string ResponseBody { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime ExecutedAt { get; set; }
    public Guid HttpRequestId { get; set; }
    public virtual HttpRequest HttpRequest { get; set; }
}