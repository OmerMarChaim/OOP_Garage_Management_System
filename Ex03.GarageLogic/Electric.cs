using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Electric : EnergySource
    {
        private float remainingTimeOfEngineOperationInHours;
        private float maxTimeOfEngineOperationInHours;

        /// <summary>
        /// method that receives how many more hours to add, and charges the battery,
        /// while not crossing the max limit)
        /// </summary>
        /// <param name="i_HowManyMoreHoursToAdd"></param>
        private void rechargeOperation(float i_HowManyMoreHoursToAdd)
        {

        }
    }
}
