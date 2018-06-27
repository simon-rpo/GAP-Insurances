using Insurances.Dto;
using Insurances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace Insurances.Dal
{
    public class ClientDal : IClientDal
    {
        #region Vars & Props
        private readonly InsurancesContext context;
        #endregion

        #region Constructor
        public ClientDal(InsurancesContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        public async Task<List<ClientDto>> GetAllClients()
        {
            try
            {
                List<Client> DataSrc = await (from x in context.Client
                                              select x).ToListAsync();

                return Mapper.Map(DataSrc, new List<ClientDto>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientDto> GetAllClientsById(int ClientId)
        {
            try
            {
                Client DataSrc = await (from x in context.Client
                                        where x.Id == ClientId
                                        select x).FirstOrDefaultAsync();

                return Mapper.Map(DataSrc, new ClientDto());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
