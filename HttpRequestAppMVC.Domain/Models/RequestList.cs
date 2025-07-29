namespace HttpRequestAppMVC.Domain.Models;

public class RequestList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}