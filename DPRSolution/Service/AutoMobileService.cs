using DPRSolution.Data;
using DPRSolution.Data;
using DPRSolution.DTO;
using DPRSolution.Models;
using DPRSolution.Models;
using System;
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
        public async Task<string> create(AutomobileOwner  automobile)
        {
          string result = null;
            try
            {
                await _appDb.AutomobileOwners.AddAsync(automobile);

                await _appDb.SaveChangesAsync();
                result = "sucess";
            }
            catch(Exception e)
                {
              
               result = e.Message;


            }
            return result;  
        }
    }
}
