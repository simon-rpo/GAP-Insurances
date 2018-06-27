using AutoMapper;
using Insurances.Dto;
using Insurances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Insurances.Dal
{
    public class PolicyDal : IPolicyDal
    {
        #region Vars & Props
        private readonly InsurancesContext context;
        #endregion

        #region Constructor
        public PolicyDal(InsurancesContext context)
        {
            this.context = context;
        }
        #endregion Constructor

        #region Public Methods
        public async Task<bool> SavePolicy(PolicyDto dto)
        {
            try
            {
                Policy Data = Mapper.Map<PolicyDto, Policy>(dto);
                context.Policy.Add(Data);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePolicy(PolicyDto dto)
        {
            try
            {
                Policy Data = Mapper.Map<PolicyDto, Policy>(dto);
                context.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CancelPolicy(PolicyDto dto)
        {
            try
            {
                Policy Data = Mapper.Map<PolicyDto, Policy>(dto);
                Data.Status = StatusEnum.Canceled;
                context.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PolicyDto>> GetPoliciesByClientId(int ClientId)
        {
            try
            {
                List<Policy> Data = await (from x in context.Policy
                                           where x.ClientId == ClientId
                                           && x.Status == StatusEnum.Assign
                                           select x).ToListAsync();

                return Mapper.Map(Data, new List<PolicyDto>());
            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion
    }
}
