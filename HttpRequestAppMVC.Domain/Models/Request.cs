namespace HttpRequestAppMVC.Domain.Models;

public class Request : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }
    public Guid RequestListId { get; set; }
    public virtual RequestList RequestList { get; set; }
    public virtual ICollection<RequestHeader> RequestHeaders { get; set; } = new List<RequestHeader>();
    public virtual ICollection<Response> ResponseHistory { get; set; } = new List<Response>();
}
