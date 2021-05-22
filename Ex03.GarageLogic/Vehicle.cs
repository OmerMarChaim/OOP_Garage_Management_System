using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string modelName;
        private string m_licenseNumber;
        private List<Wheel> wheels;
        private EnergySource engine;
        public string LicenseNumber
        {
            get { return m_licenseNumber; }
        }
    }

   
}