using DPRSolution.Data;
using DPRSolution.DTO;
using DPRSolution.Models;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
   
    public class StationService : IFuelStation
    {
        private readonly AppDbContext _appDb;
        public StationService(AppDbContext appDb)
        {
            _appDb = appDb;
        }
     
    

        public async Task create(StationOwner station)
        {
           
                       
            await _appDb.StationOwners.AddAsync(station);
            await _appDb.SaveChangesAsync();
        }
    }
}
