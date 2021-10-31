using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Service
{
    public class AdultService : IAdultService
    {
        private IFileContext data;
        private IList<Adult> adults;

        public AdultService()
        {
            data = new FileContext();
            adults = data.Adults;
        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return adults;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(a => a.Id);
            adult.Id = ++max;
            adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult toRemove = adults.FirstOrDefault(a => a.Id == id);
            adults.Remove(toRemove);
            SaveChanges();
        }

        private async Task SaveChanges()
        {
            await data.SaveChanges(adults);
        }
    }
}