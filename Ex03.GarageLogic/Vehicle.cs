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
        
        protected Vehicle(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>();
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
            get { return m_Engine; }
        }
        protected void InflateTiresToMaximum()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.InflateToMaximum();
            }
        }
        // ReSharper disable once InconsistentNaming
        public abstract void InsertExtraDetailsIntoDict(ref Dictionary<string, object> io_DictionaryRef);
        // ReSharper disable once InconsistentNaming
        public void GetWheelsDetails(ref Dictionary<string, object> io_DictionaryRef)
        {
            foreach(Wheel wheel in Wheels)
            {
                io_DictionaryRef.Add(wheel.ManufacturerName,wheel.CurrentAirPressure);
            }
        }
        // ReSharper disable once InconsistentNaming
        public void GetEngineDetails(ref Dictionary<string, object> io_DictionaryRef)
        {
            string typeOfEnergy = this.Engine.Type.ToString();
            io_DictionaryRef.Add("Type", this.Engine.Type);
            io_DictionaryRef.Add($"{typeOfEnergy} Status", $"{this.Engine.RemainingEnergyPercentage}%");
        }

        public abstract Dictionary<string,object> GetExtraDetailsMembers();
    }
}