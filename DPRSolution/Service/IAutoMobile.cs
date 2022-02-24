using DPRSolution.DTO;
using DPRSolution.Models;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
    public interface IAutoMobile
    {
        Task<string> create(AutomobileOwner automobile);

    }
}
