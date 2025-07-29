using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Domain.Interfaces
{
    public interface IRequestRepository
    {
        public Guid AddRequest(Request request);
        public Request GetRequestById(Guid id);
        public Guid UpdateRequest(Request request);
        public void DeleteRequest(Guid id);
        public IQueryable<Request> GetAllRequests();
        public IQueryable<Request> GetRequestsByRequestListId(Guid requestListId);

        Header? GetHeaderByName(string name);
        HeaderValue? GetHeaderValueByValue(string value);

        public Header AddHeader(Header header);
        public HeaderValue AddHeaderValue(HeaderValue headerValue);
        void DeleteRequestHeader(Guid headerToDeleteId);
    }
}
