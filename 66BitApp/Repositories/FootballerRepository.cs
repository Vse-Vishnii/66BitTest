using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _66BitApp.DB;
using _66BitApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _66BitApp.Repositories
{
    public class FootballerRepository : Repository<Footballer>
    {
        public FootballerRepository(UserContext db) : base(db)
        {
        }

        public override Task<Footballer> Add(Footballer entity)
        {
            if (db.Set<Team>().FirstOrDefault(t => t.Name.Equals(entity.TeamName)) == null)
                db.Set<Team>().Add(new Team() {Name = entity.TeamName});
            return base.Add(entity);
        }

        public int GetSize()
        {
            return db.Set<Footballer>().Count();
        }

        public async Task<List<Footballer>> GetRange(int start, int count)
        {
            return await db.Set<Footballer>().Skip(start).Take(count).ToListAsync();
        }
    }
}
