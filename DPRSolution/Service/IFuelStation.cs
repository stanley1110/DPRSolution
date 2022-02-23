using DPRSolution.DTO;
using DPRSolution.Models;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
    public interface IFuelStation
    {
         Task create(StationOwner   station);
    }
}
