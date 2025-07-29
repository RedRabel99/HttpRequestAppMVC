namespace HttpRequestAppMVC.Domain.Models;

public class RequestHeader : BaseEntity
{
    public Guid HeaderId { get; set; }
    public Guid HeaderValueId { get; set; }
    public Guid RequestId { get; set; }
    public virtual Request Request { get; set; }
    public virtual Header Header { get; set; }
    public virtual HeaderValue HeaderValue { get; set; }
}

public class Header : BaseEntity
{
    public string Name { get; set; }
    public bool IsCommon { get; set; } = false;

    public virtual ICollection<RequestHeader> RequestHeaders { get; set; } = new List<RequestHeader>();
}

public class HeaderValue : BaseEntity
{
    public string Value { get; set; }
    public bool IsCommon { get; set; } = false ;
    public virtual ICollection<RequestHeader> RequestHeaders { get; set; } = new List<RequestHeader>();
}
