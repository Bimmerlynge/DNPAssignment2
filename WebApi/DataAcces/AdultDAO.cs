using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.DataAcces
{
    public class AdultDAO : IAdultDAO
    {
        private MyDBContext data;
        private IList<Adult> adults;

        public AdultDAO()
        {
            data = new MyDBContext();
        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using (MyDBContext context = new MyDBContext())
            {
                adults = context.Adults.Include(a => a.JobTitle).ToList();
            }
            return adults;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            using MyDBContext context = new MyDBContext();
            
            await context.Adults.AddAsync(adult);
            await context.SaveChangesAsync();
            
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
            
            using MyDBContext context = new MyDBContext();

            context.Adults.Remove(adult);
            await context.SaveChangesAsync();
            
            
        }
    }
}