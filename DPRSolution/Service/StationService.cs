using DPRSolution.Data;
using DPRSolution.DTO;
using DPRSolution.Models;
using System;
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
     
    

        public async Task<string> create(StationOwner station)
        {
            string result = null;
            try
            {
                await _appDb.StationOwners.AddAsync(station);

                await _appDb.SaveChangesAsync();
                result = "sucess";
            }
            catch (Exception e)
            {

                result = e.Message;


            }
            return result;

        }
    }
}
