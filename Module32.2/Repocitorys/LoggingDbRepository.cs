using Module32._2.Context;
using Module32._2.Models;

namespace Module32._2.Repocitorys;

public class LoggingDbRepository : ILoggingDbRepository
{
    
    private readonly BlogDbContext _context;

    public LoggingDbRepository(BlogDbContext context)
    {
        _context = context;
    }
    public async Task LogRequest(Request request)
    {
        request.Id = Guid.NewGuid();
        request.Date = DateTime.Now;
        _context.Requests.Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Request>> GetAllRequests()
    {
        return await Task.FromResult(_context.Requests.OrderByDescending(x => x.Date).ToList());
    }
}