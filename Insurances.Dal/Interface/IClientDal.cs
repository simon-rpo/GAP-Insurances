using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Dal
{
    public interface IClientDal
    {
        Task<List<ClientDto>> GetAllClients();
        Task<ClientDto> GetAllClientsById(int ClientId);
    }
}