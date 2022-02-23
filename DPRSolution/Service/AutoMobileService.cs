using DPRSolution.Data;
using DPRSolution.Data;
using DPRSolution.DTO;
using DPRSolution.Models;
using DPRSolution.Models;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
    public class AutoMobileService : IAutoMobile
    {
        private readonly AppDbContext _appDb;
        public AutoMobileService(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public async Task create(AutomobileOwner  automobile)
        {
          
            await _appDb.AutomobileOwners.AddAsync(automobile);
            await _appDb.SaveChangesAsync();
        }
    }
}
