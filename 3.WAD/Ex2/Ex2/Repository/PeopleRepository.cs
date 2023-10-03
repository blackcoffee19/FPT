using Ex2.Data;
using Ex2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2.Repository
{
    public class PeopleRepository
    {
        BankContext ctx;
        public PeopleRepository(BankContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<PeopleDto> Login(string username, string password)
        {
            People? pel = await ctx.People!.FirstOrDefaultAsync(e=>e.Username==username && e.Password==password);
            if (pel!=null)
            {
                return new PeopleDto { Id = pel.Id, Username = username, Password = password, Role = pel.Role, Balence = pel.Balence };
            }
            return null;
        }
        public async Task<List<PeopleDto>> ShowAll()
        {
            List<People>? pel = await ctx.People!.ToListAsync();
            List<PeopleDto> ast = new List<PeopleDto>();
            foreach (var pe in pel)
            {
                ast.Add(new PeopleDto { Id=pe.Id, Username = pe.Username,Password=pe.Password, Role = pe.Role, Balence = pe.Balence });
            }
            return ast;
        }
    }
}
