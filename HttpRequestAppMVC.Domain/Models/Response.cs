namespace HttpRequestAppMVC.Domain.Models;

public class Response : BaseEntity
{
    public int StatusCode { get; set; }
    public string ResponseBody { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime ExecutedAt { get; set; }
    public Guid RequestId { get; set; }
    public virtual Request Request { get; set; }
}