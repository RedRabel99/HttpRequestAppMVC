using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Infrastructure.Repositories
{
    public class HttpRequestListRepository(AppDbContext dbContext) : IHttpRequestListRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public Guid CreateHttpRequestList(HttpRequestList requestList)
        {
            dbContext.HttpRequestLists.Add(requestList);
            dbContext.SaveChanges();
            return requestList.Id;
        }

        public void DeleteHttpRequestList(Guid id)
        {
            var httpRequestList = dbContext.HttpRequestLists.Find(id);
            if (httpRequestList != null)
            {
                dbContext.HttpRequestLists.Remove(httpRequestList);
                dbContext.SaveChanges();
            }
        }

        public IQueryable<HttpRequestList> GetAllHttpRequestLists()
        {
            return dbContext.HttpRequestLists;
        }

        public HttpRequestList GetHttpRequestListById(Guid id)
        {
            return dbContext.HttpRequestLists.FirstOrDefault(r => r.Id == id);           
        }

        public Guid UpdateHttpRequestList(HttpRequestList requestList)
        {
            dbContext.Attach(requestList);
            dbContext.Entry(requestList).Property("Name").IsModified = true;
            dbContext.Entry(requestList).Property("Description").IsModified = true;
            dbContext.SaveChanges();
            return requestList.Id;
        }
    }
}
