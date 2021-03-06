using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private String m_ModelName;
        private String m_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private EnergySource m_Engine;
        private readonly eNumberOfWheel r_NumberOfWheels;

        protected Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_ModelName = i_ModelName;
            r_Wheels = new List<Wheel>();
        }

        internal void InitElectricEngine(float i_MaxTimeOfEngineOperationInHours)
        {
            m_Engine = new Electric(i_MaxTimeOfEngineOperationInHours);
            m_Engine.Type = EnergySource.eTypeOfEnergy.Electric;
        }
        
        internal void InitFuelEngine(Fuel.eFuelType i_WantedFuelType, float i_MaxAmountOfFuelInLiters)
        {
            m_Engine = new Fuel(i_WantedFuelType, i_MaxAmountOfFuelInLiters);
            m_Engine.Type = EnergySource.eTypeOfEnergy.Fuel;

        }

        internal void InitWheels(string i_ManufacturerName, float i_MaxAirPressure, eNumberOfWheel i_NumberOfWheel)
        {
            for(int i = 0; i < (int)i_NumberOfWheel ; i++)
            {
                Wheels.Add(new Wheel(i_ManufacturerName,i_MaxAirPressure));
            }
        }

        internal enum eNumberOfWheel
        {
            Two = 2,
            Four = 4,
            Sixteen = 16 
        }

        internal int NumberOfWheel
        {
            get { return r_Wheels.Count; }
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

       // public abstract void setSpecificMemberAttribute(string i_OptionInString,ref object i_Attribute, int i_MinValue, int i_Maxvalue);

        public abstract void SetExtraDetailsMembers(ref Dictionary<string , string > i_IoDictionaryRef);

        public abstract Dictionary<string , string> GetExtraMembersNamesAndConditions();
        public abstract void GetExtraMembersContent(ref Dictionary<string , object> i_MembersDictionary);

        public void GetWheelsDetails(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            int indexOfWheel = 1;
            foreach(Wheel wheel in r_Wheels)
            {
                i_IoDictionaryRef.Add($"Manufacturer Name of wheel number {indexOfWheel}:",wheel.ManufacturerName);
                i_IoDictionaryRef.Add($"Current Air Pressure of wheel number {indexOfWheel}",wheel.CurrentAirPressure);
                indexOfWheel += 1;
            }
        }
        // ReSharper disable once InconsistentNaming
        public void GetEngineDetails(ref Dictionary<string, object> io_DictionaryRef)
        {
            string typeOfEnergy = this.Engine.Type.ToString();
            io_DictionaryRef.Add("Type", this.Engine.Type);
            string unit = this.Engine.Type == EnergySource.eTypeOfEnergy.Electric ? "Hours" : "Liters";
            io_DictionaryRef.Add($"{typeOfEnergy} Status", $"{this.Engine.RemainingEnergy} {unit}");
        }

      

        public abstract void SetEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser);
        public abstract void SetWheels(string i_ManufacturerName);

    }
}