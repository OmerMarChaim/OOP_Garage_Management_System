using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
   public abstract class EnergySource
    {
        private float m_RemainingEnergyPercentage;
        private eTypeOfEnegy m_Type;

        public enum eTypeOfEnegy
        {
            Battary,
            Fuel
        }

        public eTypeOfEnegy Type
        {
            get { return m_Type; }
            
            
        }
        
        public float RemainingEnergyPercentage
        {
            get { return m_RemainingEnergyPercentage; }
        }

    //    public abstract void UpdateAmountOfEnergy(float i_HowManyMoreHoursToAdd);

    }
}
