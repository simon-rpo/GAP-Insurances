using AutoMapper;
using Insurances.Dto;
using Insurances.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Insurances.Dal
{
    public class CoveringTypeDal : ICoveringTypeDal
    {
        #region Vars & Props
        private readonly InsurancesContext context;
        #endregion

        #region Constructor
        public CoveringTypeDal(InsurancesContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        public async Task<List<CoveringTypeDto>> GetAllCoveringTypes()
        {
            try
            {
                List<CoveringType> DataSrc = await (from x in context.CoveringType
                                                    select x).ToListAsync();

                return Mapper.Map(DataSrc, new List<CoveringTypeDto>());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
