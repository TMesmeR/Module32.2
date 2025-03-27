using Module32._2.Models;

namespace Module32._2.Repocitorys;

public interface ILoggingDbRepository
{
    Task LogRequest(Request request);
    Task<List<Request>> GetAllRequests();
}