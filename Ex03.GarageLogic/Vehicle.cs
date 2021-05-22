using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private String m_ModelName;
        private String m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private EnergySource m_Engine;

        private List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }
        private void inflateTiresToMaximum()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.inflateToMaximum();
            }
        }
    }

   
}