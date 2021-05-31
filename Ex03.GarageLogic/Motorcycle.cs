﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int k_MaxAirPressure = 30;
        private const eNumberOfWheel k_NumberOfWheel = eNumberOfWheel.Two;
        private const int k_MaxEngineVolume = 2000;

        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
        }

        private enum eLicenseType
        {
            A = 1,
            B1,
            Aa,
            Bb
        }

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> i_IoIoDictionaryRef)
        {
            string optionEngineVolume = i_IoIoDictionaryRef.ElementAt(0).Value;
            string optionLicenseType = i_IoIoDictionaryRef.ElementAt(1).Value;
            setEngineVolume(optionEngineVolume);
            setLicenseType(optionLicenseType);
        }

        private void setLicenseType(string i_OptionLicenseType)
        {
            bool isNumber = int.TryParse(i_OptionLicenseType, out int optionInt);
            if(isNumber == false)
            {
                throw new FormatException("You didn't enter a Number in License Type");
            }
            else if(optionInt < 1 || optionInt > 4)
            {
                throw new ValueOutOfRangeException(1, 4, "You entered Number Out of Range of License Type");
            }
            else
            {
                m_LicenseType = (eLicenseType)optionInt;
            }
        }

        private void setEngineVolume(string i_OptionEngineVolume)
        {
            bool isNumber = int.TryParse(i_OptionEngineVolume, out int optionEngineVolumeInt);
            if(isNumber == false)
            {
                throw new FormatException("You didn't enter a Number at Engine Volume");
            }
            else if(optionEngineVolumeInt < 0 || optionEngineVolumeInt > k_MaxEngineVolume)
            {
                throw new ValueOutOfRangeException(
                    0,
                    k_MaxEngineVolume,
                    "You enter Number Out of Range at Engine Volume");
            }
            else
            {
                m_EngineVolume = optionEngineVolumeInt;
            }
        }

        public override Dictionary<string, string> GetExtraMembersNamesAndConditions()
        {
            Dictionary<string, string> extraMembers = new Dictionary<string, string>();
            extraMembers.Add("Engine Volume", $"Number between 0-{k_MaxEngineVolume}");
            extraMembers.Add(
                "License Type",
                @" Number as 
1)  A
2)  B1 
3)  AA 
4)  BB ");

            return extraMembers;
        }

        public override void SetEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
        {
            if(i_EnergySourceTypeFromUser == EnergySource.eTypeOfEnergy.Fuel)
            {
                InitFuelEngine(Fuel.eFuelType.Octane98, 6);
            }
            else
            {
                InitElectricEngine(1.8f);
            }
        }

        public override void SetWheels(string i_ManufacturerName)
        {
            InitWheels(i_ManufacturerName, k_MaxAirPressure, k_NumberOfWheel);
        }

        public override void GetExtraMembersContent(ref Dictionary<string, object> i_IoDictionary)
        {
            i_IoDictionary.Add("Engine Volume", m_EngineVolume.ToString());
            i_IoDictionary.Add("License Type", m_LicenseType.ToString());
        }
    }
}