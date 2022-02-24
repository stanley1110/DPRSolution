using DPRSolution.DTO;
using DPRSolution.Models;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
    public interface IFuelStation
    {
         Task<string> create(StationOwner   station);
    }
}
