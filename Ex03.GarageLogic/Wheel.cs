using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private String m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;


        /// <summary>
        /// be out not to cross the MaxAirPressure 
        /// </summary>
        /// <param name="i_HowMachMoreAirToAdd"></param>
        private void inflateAction(float i_HowMachMoreAirToAdd)
        {

        }

        public void inflateToMaximum()
        {
            throw new NotImplementedException();
        }
    }

}
