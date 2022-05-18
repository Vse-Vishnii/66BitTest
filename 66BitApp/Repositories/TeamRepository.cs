using _66BitApp.DB;
using _66BitApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _66BitApp.Repositories
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(UserContext db) : base(db)
        {
        }
    }
}
