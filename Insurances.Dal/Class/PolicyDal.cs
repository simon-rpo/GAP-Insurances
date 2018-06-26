using AutoMapper;
using Insurances.Dto;
using Insurances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances.Dal
{
    public class PolicyDal : IPolicyDal
    {
        #region Vars & Props
        private readonly InsurancesContext _context;
        #endregion

        #region Constructor
        public PolicyDal(InsurancesContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Public Methods
        public async Task<bool> SavePolicy(PolicyDto dto)
        {
            try
            {
                Policy Data = Mapper.Map<PolicyDto, Policy>(dto);
                _context.Policy.Add(Data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
