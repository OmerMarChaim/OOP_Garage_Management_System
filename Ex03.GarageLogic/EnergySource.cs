using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
   internal abstract class EnergySource
    {
        private float m_RemainingEnergyPercentage;
        private eTypeOfEnegy m_Type;

        protected enum eTypeOfEnegy
        {
            Battary,
            Fual
        }

        public eTypeOfEnegy Type
        {
            get { return m_Type; }
        }
        
        public float RemainingEnergyPercentage
        {
            get { return m_RemainingEnergyPercentage; }
        }
    }
}
