using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_RemainingEnergy;
        private eTypeOfEnergy m_Type;

        public enum eTypeOfEnergy
        {
            Electric=1,
            Fuel
        }
        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
        }

        public eTypeOfEnergy Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

      
        //    public abstract void UpdateAmountOfEnergy(float i_HowManyMoreHoursToAdd);

        public static string[] GetEnergyOptions()
        {
            return Enum.GetNames(typeof(eTypeOfEnergy));
        }
    }
}