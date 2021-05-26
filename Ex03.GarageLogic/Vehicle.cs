using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private String m_ModelName;
        private String m_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private EnergySource m_Engine;
        private readonly eNumberOfWheel r_NumberOfWheels;

        protected Vehicle()
        {
            m_ModelName = String.Empty;
            m_LicenseNumber = String.Empty;
            r_Wheels = new List<Wheel>();
            m_Engine = null;
        }

        internal void SetElectricEngine()
        {
            m_Engine = new Electric();
        }
        
        internal void SetFuelEngine()
        {
            m_Engine = new Fuel();
        }

        internal enum eNumberOfWheel
        {
            Two = 2,
            Four = 4,
            Sixteen = 16 
        }

        internal eNumberOfWheel NumberOfWheel
        {
            get { return NumberOfWheel;  }
        }
        internal String ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }
        internal String LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }
        internal List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        internal EnergySource Engine
        {
            get { return EnergySource m_Engine; }
        }




        protected void InflateTiresToMaximum()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.InflateToMaximum();
            }
        }

        public List<> GetWheelsDetails()
        {
            
        }
    }
}