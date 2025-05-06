namespace HttpRequestAppMVC.Domain.Models;

public class HttpRequestHeader : BaseEntity
{
    public Guid HttpHeaderId { get; set; }
    public Guid HttpHeaderValueId { get; set; }
    public Guid HttpRequestId { get; set; }
    public virtual HttpRequest HttpRequest { get; set; }
    public virtual HttpHeader HttpHeader { get; set; }
    public virtual HttpHeaderValue HttpHeaderValue { get; set; }
}

public class HttpHeader : BaseEntity
{
    public string Name { get; set; }
    public bool IsCommon { get; set; } = false;

    public virtual ICollection<HttpRequestHeader> HttpRequestHeaders { get; set; } = new List<HttpRequestHeader>();
}

public class HttpHeaderValue : BaseEntity
{
    public string Value { get; set; }
    public bool IsCommon { get; set; } = false ;
    public virtual ICollection<HttpRequestHeader> HttpRequestHeaders { get; set; } = new List<HttpRequestHeader>();
}
