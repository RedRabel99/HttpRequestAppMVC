namespace HttpRequestAppMVC.Domain.Models;

public class HttpRequest : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }
    public Guid RequestListId { get; set; }
    public virtual HttpRequestList RequestList { get; set; }
    public virtual ICollection<HttpRequestHeader> HttpRequestHeaders { get; set; } = new List<HttpRequestHeader>();
    public virtual ICollection<HttpResponse> ResponseHistory { get; set; } = new List<HttpResponse>();
}
