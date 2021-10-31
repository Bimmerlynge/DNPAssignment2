using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public interface IFileContext
    {
        public IList<Adult> Adults { get; }
        public Task SaveChanges(IList<Adult> adults);
    }
}