namespace HttpRequestAppMVC.Domain.Models;

public class HttpRequestList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public virtual ICollection<HttpRequest> HttpRequests { get; set; } = new List<HttpRequest>();
}