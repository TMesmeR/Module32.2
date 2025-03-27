using Module32._2.Context;
using Module32._2.Models;

namespace Module32._2.Repocitorys;

public interface IBlogDbRepository
{
    Task AddUser(User user);
    Task<User []> GetUsers();
    Task Register(User user);
}