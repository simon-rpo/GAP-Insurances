using Insurances.Dal;
using Insurances.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurances.Rules
{
    public class CoveringTypeRules : ICoveringTypeRules
    {

        #region Vars & Props
        private readonly ICoveringTypeDal CoveringTypeDal;
        #endregion

        #region Constructor
        public CoveringTypeRules(ICoveringTypeDal CoveringTypeDal)
        {
            this.CoveringTypeDal = CoveringTypeDal;
        }
        #endregion

        #region Public Methods
        public async Task<List<CoveringTypeDto>> GetAllCoveringTypes()
        {
            try
            {
                return await CoveringTypeDal.GetAllCoveringTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}