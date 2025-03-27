using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module32._2.Context;
using Module32._2.Models;

namespace Module32._2.Repocitorys;

public class BlogDbRepository : IBlogDbRepository
{
    private readonly BlogDbContext _context;

    public BlogDbRepository(BlogDbContext context)
    {
        _context = context;
    }
    
    
    public async Task AddUser(User user)
    {
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User[]> GetUsers()
    {
       return await _context.Users.ToArrayAsync();
    }

   
    public async Task Register(User user)
    {
        user.JoinDate = DateTime.Now;
        user.Id = Guid.NewGuid();
        
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
      
    }
}